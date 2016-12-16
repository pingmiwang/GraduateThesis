using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms1
{
    class OrderInfo
    {
        public OrderInfo(string d)
        {
            this.len = d.Length;
            this.dicWord = d;
        }
        public string dicWord { get; set; }
        public int len { get; set; }

    }
}
