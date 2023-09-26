using CarRentalManagement.Common;
using CarRentalManagement.Models;
using CarRentalManagement.Models.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace CarRentalManagement.Services;

public interface IEmailService : IScopedService
{
    Task SendEmailAsync(MailRequest mailRequest);
}

public class EmailService : IEmailService
{
    private readonly MailSettings _mailSettings;
    public EmailService(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }

    public async Task SendEmailAsync(MailRequest mailRequest)
    {
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
        email.Subject = mailRequest.Subject;
        var builder = new BodyBuilder();

        foreach (var file in mailRequest.Attachments.Where(x => x.Length > 0))
        {
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var fileBytes = ms.ToArray();
            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
        }
        
        builder.HtmlBody = mailRequest.Body;
        email.Body = builder.ToMessageBody();
        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password).ConfigureAwait(false);
        await smtp.SendAsync(email).ConfigureAwait(false);
        await smtp.DisconnectAsync(true).ConfigureAwait(false);
    }
}