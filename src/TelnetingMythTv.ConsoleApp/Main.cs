using System;
using System.Net.Sockets;
using System.Text;
using TelnetingMythTv;

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
			Console.WriteLine(string.Format("{0}:{1}", result[0], result[1]));
			
			command.CommandText = "ANN Monitor Cena 0";
			result = command.Execute();
			Console.WriteLine(result[0]);
			
			command.CommandText = "QUERY_RECORDINGS Delete";
			result = command.Execute();
			Console.WriteLine(result.Length);

            var recordings = CreateRecordings(result);
			for (var recording = 0; recording < recordings.GetLength(0); recording++)
			{
				for (var field = 0; field < recordings.GetLength(1); field++)
				{
					Console.Write(recordings[recording, field] + "\t");
				}
				Console.Write("\n");
			}
			
			command.CommandText = "DONE";
			result = command.Execute();
			Console.WriteLine(result);

            Console.ReadLine();
		}
		
        private static string[,] CreateRecordings(string[] results)
        {
            var recordingsCount = int.Parse(results[0]);

            var recordings = new string[recordingsCount, 46];

            var arrayIndex = 1;

            for (var index = 0; index < recordingsCount; index++)
            {
                for (var field = 0; field < 46; field++)
                {
                    recordings[index, field] = results[arrayIndex];
                    arrayIndex++;
                }
            }
			
			return recordings;
		}
    }
}