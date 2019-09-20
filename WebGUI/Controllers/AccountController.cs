using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebGUI.Infrastructure;
using WebGUI.Models;
using WebGUI.Repository;

namespace WebGUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        #region PrivateVariables
        readonly IMailConfirmation MailConfirmation;
        IAuthenticationManager AuthManager =>
            HttpContext.GetOwinContext().Authentication;
        AppUserManager UserManager =>
            HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
        Task<AppUser> CurrentUser =>
            UserManager.FindByNameAsync(HttpContext.User.Identity.Name);
        ApplicationSignInManager SignInManager =>
            HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
        #endregion

        #region Constractor
        public AccountController(IMailConfirmation mailConfirmation) =>
            MailConfirmation = mailConfirmation;
        #endregion

        [HttpGet]
        public async Task<ActionResult> Manage() => View(await CurrentUser);
        [HttpPost]
        public async Task<ActionResult> Edit(Manage manage)
        {
            AppUser user = await CurrentUser;
            if (ModelState.IsValid)
            {
                user.Billing = manage.Billing;
                user.PhoneNumber = manage.PhoneNumber;
                user.Address = manage.Address;
                user.Email = manage.Email;
                await UserManager.UpdateAsync(user);
            }
            return PartialView("_manage", user);
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View("Error", new string[] { "Access Denied" });
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(UserLogin model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.FirstName + " " + model.LastName,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber
                };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    user = await UserManager.FindAsync(user.UserName, model.Password);
                    await SendEmailConfirmationTokenAsync(user.Email, user.Id, "Confirm your account");
                    string message = "please confirme your email to log on.\nThe confirmation token has been resent to your email account.";
                    return RedirectToAction("Info", new { message });
                }
                else
                {
                    ViewBag.Errors = AddErrorsFromResult(result);
                }
            }
            return View(model);
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult ChangPassword()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> ChangPassword(ForgetPassword manage)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await UserManager.FindByEmailAsync(manage.Email);
                if (user != null)
                {
                    if (!await UserManager.IsEmailConfirmedAsync(user.Id))
                    {
                        await SendEmailConfirmationTokenAsync(user.Email, user.Id, "Confirm your account-Resend");
                        string message = "You must have a confirmed email to log on.\nThe confirmation token has been resent to your email account.";
                        return RedirectToAction("Info", new
                        {
                            message
                        });
                    }
                    var password = RandomPassword();
                    await MailConfirmation.SendMessage(new IdentityMessage
                    {
                        Subject = "Reset your password",
                        Destination = manage.Email,
                        Body = "Your new password is " + password
                    });
                    var es = await UserManager.RemovePasswordAsync(user.Id);
                    if (es.Succeeded)
                    {
                        await UserManager.AddPasswordAsync(user.Id, password);
                        return RedirectToAction(nameof(Logout));
                    }
                    else
                    {
                        AddErrorsFromResult(es);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Email.");
            }
            return View(manage);
        }
        [AllowAnonymous]
        public ActionResult Login(string returnurl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View("Error", new string[] { "Access Denied" });
            }
            ViewBag.returnUrl = returnurl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await UserManager.FindAsync(details.Email, details.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid name or password.");
                }
                else
                {
                    if (!await UserManager.IsEmailConfirmedAsync(user.Id))
                    {
                        await SendEmailConfirmationTokenAsync(user.Email, user.Id, "Confirm your account-Resend");
                        string message = "You must have a confirmed email to log on.\nThe confirmation token has been resent to your email account.";
                        return RedirectToAction("Info", new { message });
                    }
                    ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = false
                    }, ident);
                    if (returnUrl == string.Empty)
                        return RedirectToAction("Index", "Home", new { area = "" });
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public ActionResult Logout()
        {
            HttpContext.Response.Cookies.Clear();
            HttpContext.Request.Cookies.Clear();
            AuthManager.SignOut();
            return RedirectToAction(nameof(Login));
        }

        #region Login Vie FaceBook
        [HttpPost]
        [AllowAnonymous]
        public ActionResult FaceBookLogin(string returnUrl)
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("FaceBookLoginCallback", new { returnUrl })
            };
            HttpContext.GetOwinContext().Authentication.Challenge(properties, "Facebook");
            return new HttpUnauthorizedResult();
        }
        [AllowAnonymous]
        public async Task<ActionResult> FaceBookLoginCallback(string returnUrl)
        {
            ExternalLoginInfo loginInfo = await AuthManager.GetExternalLoginInfoAsync();
            AppUser user = await UserManager.FindAsync(loginInfo.Login);
            if (user == null)
            {
                user = new AppUser
                {
                    Email = loginInfo.Email,
                    UserName = loginInfo.DefaultUserName,
                    Name = loginInfo.DefaultUserName
                };
                IdentityResult result = await UserManager.CreateAsync(user);
                if (!result.Succeeded)
                {
                    return View("Error", result.Errors);
                }
                else
                {
                    result = await UserManager.AddLoginAsync(user.Id, loginInfo.Login);
                    if (!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }
            }
            ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
            DefaultAuthenticationTypes.ApplicationCookie);
            ident.AddClaims(loginInfo.ExternalIdentity.Claims);
            AuthManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = false
            }, ident);
            return Redirect(returnUrl ?? "/");
        }
        #endregion

        #region Code
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var provider = new DpapiDataProtectionProvider("trialAccount");
            UserManager.UserTokenProvider = new DataProtectorTokenProvider<AppUser>(
                provider.Create("EmailConfirmation"));
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, model.ReturnUrl, model.RememberMe });
        }
        [AllowAnonymous]
        public ActionResult Info(string message) => View(model: message);
        #endregion

        #region Private Methods
        List<string> AddErrorsFromResult(IdentityResult result)
        {
            var error = result.Errors;
            return error.ToList();
        }

        async Task<string> SendEmailConfirmationTokenAsync(string Email, string userID, string subject)
        {
            var provider = new DpapiDataProtectionProvider("trialAccount");
            UserManager.UserTokenProvider = new DataProtectorTokenProvider<AppUser>(
                provider.Create("EmailConfirmation"));
            string code = await UserManager.GenerateEmailConfirmationTokenAsync(userID);
            var callbackUrl = Url.Action("ConfirmEmail", "Account",
               new { userId = userID, code }, protocol: Request.Url.Scheme);
            IdentityMessage message = new IdentityMessage()
            {
                Body = "Please confirm your account by clicking <a class= \"btn btn-primary\" href=\"" + callbackUrl + "\">here</a>",
                Subject = subject,
                Destination = Email
            };
            await MailConfirmation.SendMessage(message);
            return callbackUrl;
        }

        string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }
        #endregion
    }
}