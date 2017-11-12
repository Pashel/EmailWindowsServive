using System.Collections.Generic;
using System.Data.Entity;
using Contract;

namespace EFDatabaseClient
{
    class EmailContext : DbContext
    {
        static EmailContext()
        {
            Database.SetInitializer(new EmailInitializer());
        }

        public EmailContext(string connectionString) 
            : base(connectionString)
        { }

        public DbSet<EmailModel> EmailModel { get; set; }
    }

    class EmailInitializer : DropCreateDatabaseAlways<EmailContext>
    {
        protected override void Seed(EmailContext db)
        {
            db.EmailModel.AddRange(new List<EmailModel> {
                new EmailModel {Email = "1@mail.ru", Message = "Hello"},
                new EmailModel {Email = "2@mail.ru", Message = "Good"},
                new EmailModel {Email = "3@mail.ru", Message = "Day"}
            });

            db.SaveChanges();
        }
    }
}
