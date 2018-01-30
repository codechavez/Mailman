﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
#if NETCOREAPP2_0
    using Microsoft.Extensions.Configuration;
#else
     using System.Configuration; 
#endif


namespace Mailman
{
    public class Mailman : IMailmanHeader, IMailmanBody, IMailman
    {
        private readonly MailMessage mail = new MailMessage();
        private readonly SmtpClient smtp = new SmtpClient();
        
#if NETCOREAPP2_0
        public static IConfiguration Configuration { get; set; }
#else
            
#endif
        private void Config()
        {

#if NETCOREAPP2_0
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            
            if (Configuration["SMTPClient:Host"] == null)
                throw new Exception("SMTP host is missing from the configuration file");
            smtp.Host = Configuration["SMTPClient:Host"];
            
            if (Configuration["SMTP:Useremail"] == null || Configuration["SMTP:Userpwd"] == null)
                smtp.Credentials = CredentialCache.DefaultNetworkCredentials;
            else
                smtp.Credentials = new NetworkCredential(Configuration["SMTP:Useremail"], Configuration["SMTP:Userpwd"]);

            if(Configuration["SMTP:Port"] != null)
                smtp.Port = int.Parse(Configuration["SMTP:Port"]);
#else
            if (ConfigurationManager.AppSettings["SMTPClient:Host"] == null)
                throw new Exception("SMTP host is missing from the configuration file");
            smtp.Host = ConfigurationManager.AppSettings["SMTPClient:Host"];

            if (ConfigurationManager.AppSettings["SMTP:Useremail"] == null || ConfigurationManager.AppSettings["SMTP:Userpwd"] == null)
                smtp.Credentials = CredentialCache.DefaultNetworkCredentials;
            else
                smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SMTP:Useremail"], ConfigurationManager.AppSettings["SMTP:Userpwd"]);

            if (ConfigurationManager.AppSettings["SMTP:Port"] != null)
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["SMTP:Port"]);       
#endif


        }

        private Mailman(MailAddress fromemail)
        {
            try
            {
                Config();
                mail.From = fromemail;
            }
            catch
            {
                throw;
            }
        }

        public static IMailmanHeader From(MailAddress from)
        {
            return new Mailman(from);
        }
             

        public IMailmanHeader To(params string[] toEmails)
        {
            foreach (var email in toEmails)
                mail.To.Add(email);

            return this;
        }

        public IMailmanBody WithSubject(string subject)
        {
            mail.Subject = subject;
            return this;
        }

        public IMailmanBody IsHtml(bool ishtml = true)
        {
            mail.IsBodyHtml = ishtml;
            return this;
        }

        public IMailman WithBody(string body)
        {
            mail.Body = body;
            return this;
        }

        public IMailman CC(params string[] ccEmails)
        {
            foreach (var cc in ccEmails)
                mail.CC.Add(cc);

            return this;
        }

        public IMailman BCC(params string[] BCCEmails)
        {
            foreach (var bcc in BCCEmails)
                mail.Bcc.Add(bcc);

            return this;
        }

        public IMailman Attachments(params string[] attachmentsFullPaths)
        {
            foreach (var attach in attachmentsFullPaths)
                mail.Attachments.Add(new Attachment(attach));

            return this;
        }

        public void Deliver()
        {
            try
            {
                smtp.Send(mail);
            }
            catch
            {
                throw;
            }
        }
    }
}
