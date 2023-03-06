using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave_2._0.Models
{
    public class logs
    {
        public string name { get; set; }
        public string source { get; set; }
        public string target { get; set; }
        public string size { get; set; }
        public string transfertTime { get; set; }
        public string cryptTime { get; set; }
        public string time { get; set; }

        private logs() {}

        public logs(string _name, string _source, string _target, string _size, string _transfertTime, string _cryptTime)
        {
            this.name = _name;
            this.source = _source;
            this.target = _target;
            this.size = _size;
            this.transfertTime = _transfertTime;
            this.cryptTime = _cryptTime;
            this.time = DateTime.Now.ToString();
        }
    }
}
