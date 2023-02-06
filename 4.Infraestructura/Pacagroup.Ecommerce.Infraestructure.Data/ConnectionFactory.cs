﻿using Microsoft.Extensions.Configuration;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Pacagroup.Ecommerce.Infraestructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

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