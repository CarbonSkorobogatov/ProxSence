using System.Net;
using System.Net.Mail;
using System.Text;
using ProxSence.Library.InterfacesLibrary;
using ProxSence.Library.ProxSenceModels;

namespace ProxSence.Library.EFBase
{
    public class MailSettings
    {
        public string EmailAddress = "proxsence@gmail.com";
        public string EmailAddress2 = "nvvnikolenko@gmail.com";
        public bool UseSsl = false; //true
        public string UserName = "nvvnikolenko@gmail.com";  //Azure
        public string Password = "AilTtrkey5failure";
        public int Port = 465; // check 587
        public bool WriteAsFile = false;
        //public string ServerName = "proxsence.azurewebsites.net";
        public string ServerName = "smtp.gmail.com";
        
    }

    public class MailContactForm : IMailSender
    {
        private MailSettings mailSettings;
        public MailContactForm(MailSettings mailS)
        {
            mailSettings = mailS;
        }
        public void MailSender(FeedbackModel feedbackModel)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = mailSettings.UseSsl;
                smtpClient.Host = mailSettings.ServerName;
                smtpClient.Port = mailSettings.Port;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(mailSettings.UserName, mailSettings.Password);
                if(mailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.EnableSsl = false;
                }
                StringBuilder body = new StringBuilder()
                    .AppendLine("Спасибо! Мы с Вами свяжемся.")
                    .AppendLine("-------");
                body.AppendFormat("-------")
                    .AppendLine("-------")
                    .AppendLine(feedbackModel.Name)
                    .AppendLine(feedbackModel.Email)
                    .AppendLine(feedbackModel.Subject)
                    .AppendLine(feedbackModel.Message);
                MailMessage mailMessage = new MailMessage(mailSettings.EmailAddress2, mailSettings.EmailAddress, feedbackModel.Subject, body.ToString());
                if(mailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }
                smtpClient.Send(mailMessage);
            }
        }

    }

}
