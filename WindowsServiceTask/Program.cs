using System;
using System.Configuration;
using System.IO;
using Topshelf;
using Topshelf.Runtime;
using Contract;
using EFDatabaseClient;
using EmailSender;

namespace WindowsServiceTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory(@"C:/Emails");
            var emailAddress = ConfigurationManager.AppSettings["email"];

            IDatabaseReader reader = new EFDatabaseReader("DefaultConnection");
            IEmailSender sender = new StandardEmailSender(emailAddress);
            
            HostFactory.Run(
                x => x.Service<EmailService>(conf => {
                    conf.ConstructUsing(() => new EmailService(reader, sender));
                    conf.WhenStarted(s => s.Start());
                    conf.WhenStopped(s => s.Stop());
                }));
        }
    }
}
