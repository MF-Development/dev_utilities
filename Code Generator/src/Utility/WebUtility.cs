using System;
using System.Net.Mail;
using System.Net;

namespace MyApplication.Utility
{
    public class WebUtility
    {
        #region Methods
        /// <summary>
        /// Sends the Email
        /// </summary>
        public static void Email(string sendTo, string sentFrom, string subject, string body, string server)
        {
            MailMessage message = new MailMessage(sendTo, sentFrom, subject, body);
            SmtpClient client = new SmtpClient(server);
            // Add credentials if the SMTP server requires them.
            client.Credentials = CredentialCache.DefaultNetworkCredentials;
            client.Send(message);
        }
        #endregion

    }
}
