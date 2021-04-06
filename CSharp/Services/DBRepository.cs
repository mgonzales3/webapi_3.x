using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CSharp.Services
{
    public class DBRepository : IDisposable
    {
        public readonly IDbConnection ConnectionString;

        public DBRepository(string value)
        {
            this.ConnectionString = new SqlConnection(value);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
