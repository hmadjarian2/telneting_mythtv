using System;
using System.Net.Sockets;
using System.Text;

namespace TelnetingMythTv.ConsoleApp
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var connection = new ServerConnection("192.168.1.10", 6543);
			connection.Open();
			
			var command = new ServerCommand(connection) {CommandText = "MYTH_PROTO_VERSION 40"};
		    var result = command.Execute();	
			Console.WriteLine(result);
			
			command.CommandText = "ANN Monitor Cena 0";
			result = command.Execute();
			Console.WriteLine(result);
			
			command.CommandText = "QUERY_RECORDINGS Delete";
			result = command.Execute();
			Console.WriteLine(result);

            CreateRecordings(result);

			command.CommandText = "DONE";
			result = command.Execute();
			Console.WriteLine(result);

            Console.ReadLine();
		}
		
        private static void CreateRecordings(string[] results)
        {
            var recordingsCount = int.Parse(results[0]);

            var recordings = new string[recordingsCount, 46];

            var someOtherIndex = 1;

            for (var index = 0; index < recordingsCount; index++)
            {
                for (var field = 0; field < 46; field++)
                {
                    recordings[index, field] = results[someOtherIndex];
                    someOtherIndex++;
                }
            }
        }
    }
}