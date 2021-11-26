using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class Ip2group
    {
        public string Ip { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Groupstr { get; set; } = null!;
    }
}
