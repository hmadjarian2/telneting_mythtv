using System.Data;

namespace TelnetingMythTv
{
    public class ConnectionFactory : IConnectionFactory
    {
        private IDbConnectionFactory db_connection_factory;

        public ConnectionFactory(IDbConnectionFactory db_connection_factory)
        {
            this.db_connection_factory = db_connection_factory;
        }

        public IConnection create()
        {
            return new Connection(db_connection_factory.create());
        }
    }
}
