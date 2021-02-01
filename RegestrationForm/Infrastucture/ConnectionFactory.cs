using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace RegestrationForm.Infrastucture
{
    //public interface IConnectionFactory
    //{
    //    SqlConnection GetConnection { get; }
    //}
    //public class ConnectionFactory : IConnectionFactory 
    //{
    //    private readonly IConfiguration Configuration;

    //    public ConnectionFactory(IConfiguration configuration)
    //    {
    //        Configuration = configuration;
    //    }

    //    public SqlConnection GetConnection
    //    {
    //        get
    //        {
    //            var connectionString = Configuration.GetConnectionString("DefaultConnection") as string;
    //            return new SqlConnection(connectionString);
    //        }
    //    }
    //}
}
