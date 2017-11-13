using System;
using System.Collections.Generic;

namespace Contract
{
    public interface IEmailSender : IDisposable
    {
        void Send(List<EmailModel> emailList);
    }
}
