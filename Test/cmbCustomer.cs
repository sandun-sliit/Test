using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class cmbCustomer
    {
        public int DCLink { get; set; }
        public string Name { get; set; }
        public string Physical1 { get; set; }
        public string Physical2 { get; set; }
        public string Physical3 { get; set; }
        public string Physical4 { get; set; }
        public string Post4 { get; set; }
        public string Post5 { get; set; }
        public string PhysicalPC { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
