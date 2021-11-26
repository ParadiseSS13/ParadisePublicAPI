using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class Privacy
    {
        public string Ckey { get; set; } = null!;
        public DateTime Datetime { get; set; }
        public ulong Consent { get; set; }
    }
}
