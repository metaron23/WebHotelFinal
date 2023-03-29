﻿using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using WebHotel.DTO;

namespace WebHotel.Repository.EmailRepository
{
    public class MailRepository : IMailRepository
    {
        private readonly IConfiguration _configuration;

        public MailRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool Email(EmailRequestDto mailRequest)
        {
            var check = true;
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["EmailSettings:EmailFrom"]));
            email.To.Add(MailboxAddress.Parse(mailRequest.To));
            email.Subject = mailRequest.Subject;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = mailRequest.Body
            };
            using var smtp = new SmtpClient();
            try
            {
                smtp.Connect(_configuration["EmailSettings:SmtpHost"], 465, SecureSocketOptions.StartTls);
                smtp.Authenticate(_configuration["EmailSettings:SmtpUser"], _configuration["EmailSettings:SmtpPass"]);
                smtp.Send(email);
            }
            catch
            {
                check = false;
            }
            finally
            {
                smtp.Disconnect(true);
            }
            return check;
        }
    }
}
