using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoderDojoBot.Models
{
    public class Dojo
    {
        public string Company { get; set; }
        public string Adress { get; set; }
        public DateTime Start { get; set; }

        private DateTime _end;
        public DateTime End
        {
            get
            {
                return _end != null ? _end : Start.AddHours(2);
            }
            set { _end = value; }
        }

        public bool IsFuture => Start.Ticks > DateTime.Now.Ticks;
    }
}