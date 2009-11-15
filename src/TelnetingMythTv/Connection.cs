using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TelnetingMythTv
{
    public class Connection : IConnection
    {
        private readonly IDbConnection underlying_connection;

        public Connection(IDbConnection connection)
        {
            underlying_connection = connection;
            underlying_connection.Open();
        }

        //public IDbCommand create_command_to_run(IQuery query)
        //{
        //    var command = underlying_connection.CreateCommand();
        //    query.prepare(command);
        //    return command;
        //}

        public void Dispose()
        {
            underlying_connection.Dispose();
        }
    }
}
