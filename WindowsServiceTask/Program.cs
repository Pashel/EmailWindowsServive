using System.Configuration;
using Topshelf;

namespace WindowsServiceTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var emailAddress = ConfigurationManager.AppSettings["address"];

            HostFactory.Run(x => x.Service<EmailService>());
        }
    }
}
