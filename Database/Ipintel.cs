using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class Ipintel
    {
        public uint Ip { get; set; }
        public DateTime Date { get; set; }
        public double Intel { get; set; }
    }
}
