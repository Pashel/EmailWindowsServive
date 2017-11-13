using System;
using Contract;
using System.Net;
using System.Collections.Generic;
using System.Net.Mail;

namespace EmailSender
{
    public class StandardEmailSender : IEmailSender
    {
        private readonly SmtpClient _client;
        private readonly string _recieverAddress;

        public StandardEmailSender(string recieverAddress)
        {
            _client = new SmtpClient();
            _recieverAddress = recieverAddress;
        }

        public void Send(List<EmailModel> emailList)
        {
            foreach (var model in emailList) {
                using (var mail = new MailMessage(model.Email, _recieverAddress, "Email windows service", model.Message)) {
                    _client.Send(mail);
                }
            }
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
