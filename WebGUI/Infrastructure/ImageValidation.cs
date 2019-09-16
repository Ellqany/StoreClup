using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WebGUI.Infrastructure
{
    public class ImageValidation : ValidationAttribute
    {
        string ComparisonAttribute { get; set; }
        string ImageUrl { get; set; }

        public ImageValidation(string ImageUrl)
        {
            ComparisonAttribute = ImageUrl;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(ComparisonAttribute);
            try
            {
                ImageUrl = property.GetValue(validationContext?.ObjectInstance).ToString();
            }
            catch (System.Exception)
            {
                ImageUrl = null;
            }
            if (value is HttpPostedFileBase Image)
            {
                if (string.IsNullOrEmpty(ImageUrl) && Image == null)
                {
                    return new ValidationResult("Please Upload image");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(ImageUrl))
                {
                    return new ValidationResult("Please Upload image");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
        }

    }
}