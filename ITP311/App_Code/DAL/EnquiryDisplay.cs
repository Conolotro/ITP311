using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITP311
{
    public class EnquiryDisplay
    {

        public int id { get; set; }
        public string name { get; set; }
        public string dateTime { get; set; }

        public EnquiryDisplay(int id, string name, string dateTime)
        {
            this.id = id;
            this.name = name;
            this.dateTime = dateTime;
        }

        public EnquiryDisplay()
        {

        }
    }
}