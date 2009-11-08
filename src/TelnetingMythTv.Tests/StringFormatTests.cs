
using System;
using NUnit.Framework;

namespace TelnetingMythTv.Tests
{
	
	[TestFixture]
	public class StringFormatTests
	{
		[Test]
		public void CanReturnAPaddedStringOfCharacters()
		{
			var expected = "20      MYTH_PROTO_VERSION 40";
			var actual = string.Format("{0,-8:G}{1}", "20", "MYTH_PROTO_VERSION 40");
			Assert.AreEqual(expected, actual);
		}
	}
}
