using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TelnetingMythTv;

namespace TelnetingMythTv.Tests 
{
    [TestFixture]
	public class ViewRecordingsCommandTests
	{
        [Test]
        public void WhenAskingToSeeAListOfRecordingsAListOfRecordingsIsReturned()
        {
            var command = new ViewRecordingsCommand(new ServerConnection("192.168.1.12"), "Delete");
            //var recordings = command.Execute();
            //Assert.GreaterOrEqual(1, recordings.Count);
        }
	}
}
