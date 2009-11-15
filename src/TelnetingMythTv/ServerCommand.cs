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

        public string[] Execute()
        {
            var message = BuildMessage();
            var stream = _connection.GetStream();

			var sendBytes = Encoding.ASCII.GetBytes(message);
			
        	stream.Write(sendBytes, 0, sendBytes.Length);
        	
            var buffer = new byte[8];
            var bytesRead = stream.Read(buffer, 0, 8);
            
            if (bytesRead == 0)
            {
                return new[] { "" };
            }
            
            var result = Encoding.ASCII.GetString(buffer, 0, 8);

			var bytesAvailable = int.Parse(result);
			var readBytes = new Byte[bytesAvailable];
			
			var totalBytesRead = 0;
			result = string.Empty;
			
			while (totalBytesRead < bytesAvailable)
			{
            	bytesRead = stream.Read(readBytes, 0, bytesAvailable);
				totalBytesRead += bytesRead;
			
            	result += Encoding.ASCII.GetString(readBytes, 0, bytesRead);
			}
			
            return result.Split(new[] { MythProtocolExtensions.Delimiter }, StringSplitOptions.None);;
        }

        private string BuildMessage()
        {
            var messageFormat = "{0,-8:G}{1}";
            return string.Format(messageFormat, CommandText.Length, CommandText);
        }
    }
}
