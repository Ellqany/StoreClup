namespace WebGUI.Models
{
    public class EmailSettings
    {
        public string MailToAddress = "a@gmail.com";
        public string MailFromAddress = "dollarshave@yahoo.com";
        public bool UseSsl = true;
        public string Username = "dollarshave";
        public string Password = "DOLLARSHAVECLUB@010";
        public string ServerName = "smtp.mail.yahoo.com";
        public int ServerPort = 587;
        public string FileLocation = @"~/Mail";
    }
}