using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using SpaceFork.eShop.Ordering.Core.Contracts.Infrastructure;
using SpaceFork.eShop.Ordering.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFork.eShop.Ordering.Infrastructure
{
    public class EmailService : IEmailService
    {

        private readonly IOptions<EmailSettings> _emailSettings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailSettings> options, ILogger<EmailService> logger)
        {
            _emailSettings = options;
            _logger = logger;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var emailSettingsValue = _emailSettings.Value;
            var client = new SendGridClient(new SendGridClientOptions()
            {
                ApiKey = emailSettingsValue.ApiKey,
            });

            var senderEmailAddress = new EmailAddress()
            {
                Email = emailSettingsValue.FromAddress,
                Name = emailSettingsValue.FromName,
            };

            var reciverEmailAddress = new EmailAddress()
            {
                Email = email.To
            };
            try
            {
                var sendGridMessage = MailHelper.CreateSingleEmail(senderEmailAddress, reciverEmailAddress, email.Subject, email.Body, email.Body);
                var sendingEmail = await client.SendEmailAsync(sendGridMessage);

                _logger.LogInformation($"Email Sent to {email.To} that Order has been Done.");

                return sendingEmail.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception has been happened while sending Email ");
                throw;
            }
        }
    }
}
