using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfDemoMail.Mail;

namespace WcfDemoMail
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BussinesDemoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BussinesDemoService.svc or BussinesDemoService.svc.cs at the Solution Explorer and start debugging.
    public class BussinesDemoService : IBussinesDemoService
    {
        public void DoWork()
        {
            var data = new WelcomeDetails()
            {
                Name = "Jesus Angulo",
                Date = DateTime.Now.ToLongDateString(),
                Message = "Bienvenido a nuestro sistema Mail.NET"
            };

            var bodyHtml = MailGenerator.GetHtml(data, "Welcome.html");

            var smtpClient = new SmtpClient();
            var message = new MailMessage("no-reply@somostechies.com", "alguien@outlook.com")
            {
                Subject = "Bienvenido",
                Body = bodyHtml,
                IsBodyHtml = true
            };

            smtpClient.Send(message);            
        }
    }

    public class WelcomeDetails
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Message { get; set; }
    }
}
