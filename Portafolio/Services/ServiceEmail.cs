using Portafolio.Models;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.Security.Cryptography;

namespace Portafolio.Services
{
   
    public interface IServiceEmail
    {
        void SendEmail(ContactoViewModel contacto);
    }

    public class ServiceEmail:IServiceEmail
    {
        private readonly ConfigEmail configEmail;
        private readonly ConfigSendEmail configSendEmail;
        private readonly string _sendEmail;
        private readonly string _sendName;

        public ServiceEmail(IConfiguration _configuration)
        {
            //Config email
            configEmail = new ConfigEmail();
            _configuration.Bind(key: "ConfigEmail", configEmail);
            //Config send email
            configSendEmail = new ConfigSendEmail();
            _configuration.Bind(key: "ConfigSendEmail", configSendEmail);
            //Email to
            _sendEmail =  _configuration.GetValue<string>("SendTo:Email");
            _sendName = _configuration.GetValue<string>("SendTo:name");
        }
        public void SendEmail(ContactoViewModel contacto)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(configSendEmail.Name, configSendEmail.Email));
            message.To.Add(new MailboxAddress(_sendName,_sendEmail));
            message.Subject = $"{contacto.Nombre} te quiere contactar su correo es {contacto.Email}";
            message.Body = new TextPart("plain")
            {
                Text = contacto.Mensaje
            };

            using var smtpClient = new SmtpClient();
            smtpClient.Connect(configEmail.SMTP, configEmail.PORT, configEmail.SSL);
            smtpClient.Authenticate(configSendEmail.Email, configSendEmail.Password);
            smtpClient.Send(message);

            smtpClient.Disconnect(true);

        }
    }
}
