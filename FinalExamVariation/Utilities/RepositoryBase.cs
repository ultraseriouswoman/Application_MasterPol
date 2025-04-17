using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamVariation.Utilities
{
    public abstract class RepositoryBase
    {
        private string _connectionString;

        public RepositoryBase() 
        {
            _connectionString = "Server=.\\SQLEXPRESS;Database=DB_Test;Encrypt=False;Trusted_Connection=True";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
