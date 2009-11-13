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

			var sendBytes = Encoding.ASCII.GetBytes(message);
			
        	stream.Write(sendBytes, 0, sendBytes.Length);
        	
            var buffer = new byte[1024];
            stream.Read(buffer, 0, 8);
            var result = Encoding.ASCII.GetString(buffer, 0, 8);

            if (result.ToUpper() == "OK")
            {
                return "";
            }

            var byteCount = int.Parse(result);

            var bufferBytes = new Byte[byteCount];

            stream.Read(bufferBytes, 0, byteCount);

            result = Encoding.ASCII.GetString(bufferBytes, 0, byteCount);

            return result;
        }

        private string BuildMessage()
        {
            var messageFormat = "{0,-8:G}{1}";
            return string.Format(messageFormat, CommandText.Length, CommandText);
        }
    }
}
