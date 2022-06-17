using System;
namespace Z33xClient.Models
{
	public class Record
	{
        public long id { get; set; }
        public long year { get; set; }
        public long length { get; set; }
        public string title { get; set; }
        public string subject { get; set; }
        public string actor { get; set; }
        public string actress { get; set; }
        public string director { get; set; }
        public long popularity { get; set; }
        public bool awards { get; set; }
        public string image { get; set; }
    }
}

