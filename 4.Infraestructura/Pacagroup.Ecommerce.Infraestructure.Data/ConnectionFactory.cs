
namespace Pacagroup.Ecommerce.Infraestructure.Data
{
    using Microsoft.Extensions.Configuration;
    using Pacagroup.Ecommerce.Transversal.Common;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// 
    /// </summary>
    public class ConnectionFactory : IConnectionFactory
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public ConnectionFactory(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();
                if (sqlConnection == null) return null;

                sqlConnection.ConnectionString = _configuration.GetConnectionString("NothwindConnection");
                sqlConnection.Open();
                return sqlConnection;
            }
        }
    }
}
