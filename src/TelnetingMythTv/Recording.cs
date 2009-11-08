using System;
using System.Collections.Generic;
using System.Text;

namespace TelnetingMythTv 
{
	public class Recording
	{
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public int ChannelId { get; set; }
        public string ChannelNumber { get; set; }
        public string ChannelSign { get; set; }
        public string PathName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
	}
}