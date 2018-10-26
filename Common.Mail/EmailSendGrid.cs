using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace Common.Mail
{
    public class EmailSendGrid
    {

        private string smtpServer;
        private string smtpPassword;
        private string smtpUser;
        private List<MailAddress> addressFrom;
        private List<MailAddress> addressTo;


        public EmailSendGrid()
        {
            this.addressFrom = new List<MailAddress>();
            this.addressTo = new List<MailAddress>();
        }

        public void Config(string smtpServer, string smtpUser, string smtpPassword, int smtpPortNumber = 587, string textFormat = "HTML")
        {

            this.smtpServer = smtpServer;
            this.smtpUser = smtpUser;
            this.smtpPassword = smtpPassword;

        }

        public void AddAddressFrom(string name, string email)
        {
            this.addressFrom.Add(new MailAddress(email, name));
        }

        public void AddAddressTo(string name, string email)
        {
            this.addressTo.Add(new MailAddress(email, name));
        }

        //public void Send(String subject, String content)
        //{
        //    try
        //    {
        //        var client = new SendGridClient(this.smtpUser);
        //        var from = this.addressFrom.FirstOrDefault();
        //        var to =  this.addressTo.FirstOrDefault();
        //        var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
        //        var response = client.SendEmailAsync(msg).Result;
        //        if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
        //            throw new InvalidOperationException("Erro ao enviar e-mail");


        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
