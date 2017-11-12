using System.Configuration;
using Topshelf;
using Contract;
using EFDatabaseClient;

namespace WindowsServiceTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var emailAddress = ConfigurationManager.AppSettings["email"];

            IDatabaseReader reader = new EFDatabaseReader("DefaultConnection");
            var data = reader.ReadData();

            //HostFactory.Run(x => x.Service<EmailService>());
        }
    }
}
