using System;
using System.Collections.Generic;
using System.Linq;
using Contract;

namespace EFDatabaseClient
{
    public class EFDatabaseReader : IDatabaseReader
    {
        private readonly EmailContext _db;
        public EFDatabaseReader(string connectionString)
        {
            _db = new EmailContext(connectionString);
        }

        public List<EmailModel> ReadData()
        { 
            return _db.EmailModel.ToList();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
