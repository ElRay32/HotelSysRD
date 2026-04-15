using System.Net;
using System.Net.Mail;
using HotelSysRD.Models;
using Microsoft.Extensions.Options;

namespace HotelSysRD.Services
{
    // Servicio encargado de enviar correos electrónicos
    public class EmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task EnviarCorreoAsync(string destinatario, string asunto, string contenidoHtml)
        {
            using var smtp = new SmtpClient(_settings.SmtpServer)
            {
                Port = _settings.Port,
                Credentials = new NetworkCredential(_settings.SenderEmail, _settings.Password),
                EnableSsl = true
            };

            using var mensaje = new MailMessage
            {
                From = new MailAddress(_settings.SenderEmail, _settings.SenderName),
                Subject = asunto,
                Body = contenidoHtml,
                IsBodyHtml = true
            };

            mensaje.To.Add(destinatario);

            await smtp.SendMailAsync(mensaje);
        }
    }
}