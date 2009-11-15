using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TelnetingMythTv
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        //private ConnectionStringSettings settings;
        //private DbProviderFactory provider_factory;

        public DbConnectionFactory()
        {
            //settings = ConfigurationManager.ConnectionStrings["Store"];
            //provider_factory = DbProviderFactories.GetFactory(settings.ProviderName);
        }

        public IDbConnection create()
        {
            //var connection = provider_factory.CreateConnection();
            //connection.ConnectionString = settings.ConnectionString;
            //return connection;
            return null;
        }
    }
}
