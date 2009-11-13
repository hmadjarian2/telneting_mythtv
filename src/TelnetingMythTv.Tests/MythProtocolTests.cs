using System;
using System.Collections.Generic;
using System.Text;
using TelnetingMythTv;
using NUnit.Framework;

namespace TelnetingMythTv.Tests 
{
    [TestFixture]
	public class MythProtocolTests
	{
        [Test]
        public void CanConnectToMythBackend()
        {
            var connection = new ServerConnection("192.168.1.10", 6543);
            connection.Open();
            Assert.AreEqual(true, connection.Connected);
        }

        [Test]
        public void CanSendCommand()
        {
            var connection = new ServerConnection("192.168.1.10");
            connection.Open();

            var command = new ServerCommand(connection);
            command.CommandText = "MYTH_PROTO_VERSION 40";
            var result = command.Execute();
            Console.WriteLine(result);

            command.CommandText = "ANN Monitor Cena 0";
            result = command.Execute();
            Console.WriteLine(result);

            command.CommandText = "QUERY_RECORDINGS Play";
            result = command.Execute();
            Console.WriteLine(result);

            command.CommandText = "DONE";
            result = command.Execute();
            Console.WriteLine(result);

		}

        [Test]
        public void CanConvertResultToRecording()
        {
            var connection = new ServerConnection("192.168.1.10");
            connection.Open();

            var command = new ServerCommand(connection);
            command.CommandText = "MYTH_PROTO_VERSION 40";
            var result = command.Execute();
            Console.WriteLine(result);

            command.CommandText = "ANN Monitor Cena 0";
            result = command.Execute();
            Console.WriteLine(result);

            command.CommandText = "QUERY_RECORDINGS Play";
            result = command.Execute();
            Console.WriteLine(result);
            
            command.CommandText = "DONE";
            command.Execute();
        }
	}
}
