namespace ImproveSales.Resources
{
    using Microsoft.AspNetCore.Identity.UI.Services;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System;
    using System.Threading.Tasks;

    public class EmailSender : IEmailSender
    {
        public static async Task Execute(string toEmail, string subject, string message)
        {
            //TO DO Should put the key here
            var apiKey = "";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("s.improve@yahoo.com", "Improve Sales");
            var _subject = string.IsNullOrEmpty(subject) ? "Потвърждение на имейл" : subject;
            var to = new EmailAddress(toEmail);
            var plainTextContent = string.IsNullOrEmpty(message) ? "Здравейте, моля натиснете този линк, за да потвърдите вашия имейл: " : message;
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, _subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(email, subject, message);
        }
    }
}
