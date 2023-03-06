using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_PS.Models
{
    public class logs
    {
        public string name { get; set; }
        public string source { get; set; }
        public string target { get; set; }
        public string size { get; set; }
        public string transfertTime { get; set; }
        public string time { get; set; }

        public logs(string _name, string _source, string _target, string _size, string _transfertTime)
        {
            this.name = _name;
            this.source = _source;
            this.target = _target;
            this.size = _size;
            this.transfertTime = _transfertTime;
            this.time = DateTime.Now.ToString();
        }
    }
}
