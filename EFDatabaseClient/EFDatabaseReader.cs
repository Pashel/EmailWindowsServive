using System.Collections.Generic;
using System.Linq;
using Contract;

namespace EFDatabaseClient
{
    public class EFDatabaseReader : IDatabaseReader
    {
        private readonly string _connectionString;
        public EFDatabaseReader(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<EmailModel> ReadData()
        {
            using (var db = new EmailContext(_connectionString)) {
                return db.EmailModel.ToList();
            }
        }
    }
}
