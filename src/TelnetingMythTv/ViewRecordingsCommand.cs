using System;

namespace TelnetingMythTv
{
    public class ViewRecordingsCommand : Command
    {
        private ServerConnection _connection;
        private string _type;

        public ViewRecordingsCommand(ServerConnection connection, string type)
        {
            _connection = connection;
            _type = type;
        }

        public void Execute()
        {
            Commands.QueryRecordings.format(_type);
        }
    }
}
