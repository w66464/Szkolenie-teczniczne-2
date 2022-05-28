using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BiuroPracy.BusinessLogic.Logic.Interface;

namespace BiuroPracy.BusinessLogic.Logic
{
    public class EmailManager : IEmailManager
    {
        public bool SendEmail(string title, string contents, string emailTo)
        {
            using (SmtpClient client = new SmtpClient())
            using (MailMessage message = new MailMessage())
            {
                message.To.Add(emailTo);
                message.IsBodyHtml = true;
                message.Subject = title;
                message.Body = contents;

                try
                {
                    client.Send(message);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}


