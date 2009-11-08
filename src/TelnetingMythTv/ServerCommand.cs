using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TelnetingMythTv
{
    public class ServerCommand
    {
        private ServerConnection _connection;

        public ServerCommand(ServerConnection connection)
        {
            _connection = connection;
        }

        public string CommandText { get; set; }

        public void Execute()
        {
            var message = BuildMessage();
            var stream = _connection.GetStream();

            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);

            writer.WriteLine(message);
            writer.Flush();

            var result = string.Empty;

            var buffer = new byte[100];
            int bytes = stream.Read(buffer, 0, buffer.Length);
            for (int i = 0; i < bytes; i++)
                result += (Convert.ToChar(buffer[i]));

        }

        private string BuildMessage()
        {
            var messageFormat = "{0,-8:G}{1}";
            return string.Format(messageFormat, CommandText.Length, CommandText);
        }
    }
}
