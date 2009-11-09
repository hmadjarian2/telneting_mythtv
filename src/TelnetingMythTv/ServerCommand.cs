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

        public string Execute()
        {
            var message = BuildMessage();
            var stream = _connection.GetStream();

            //var reader = new StreamReader(stream);
            //var writer = new StreamWriter(stream);

            //writer.WriteLine(message);
            //writer.Flush();

			var sendBytes = Encoding.ASCII.GetBytes(message);
			
        	stream.Write(sendBytes, 0, sendBytes.Length);
        	
            var result = string.Empty;

            var buffer = new byte[100];
            var bytesRead = 0; //stream.Read(buffer, 0, buffer.Length);
            
			while (stream.DataAvailable && (bytesRead = stream.Read(buffer, 0, 100)) > 0)
			{
				result += Encoding.ASCII.GetString(buffer);
			}
			
            return result;
        }

        private string BuildMessage()
        {
            var messageFormat = "{0,-8:G}{1}";
            return string.Format(messageFormat, CommandText.Length, CommandText);
        }
    }
}
