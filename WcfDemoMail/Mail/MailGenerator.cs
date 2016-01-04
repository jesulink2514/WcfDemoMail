using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using HandlebarsDotNet;

namespace WcfDemoMail.Mail
{
    public static class MailGenerator
    {
        public static string TemplateFolder = "~/templates";
        public static string GetHtml<T>(T data,string templateName)
        {
            var basePath = System.Web.Hosting.HostingEnvironment.MapPath(TemplateFolder);
            var totalPath = Path.Combine(basePath, templateName);

            if (!File.Exists(totalPath))
                throw new InvalidOperationException("La plantilla {0} no se ha encontrado en el folder de plantillas.");

            var templateText = File.ReadAllText(totalPath);

            var template = Handlebars.Compile(templateText);

            var result = template(data);

            return result;
        }
    }
}