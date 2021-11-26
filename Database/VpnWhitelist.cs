using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class VpnWhitelist
    {
        public string Ckey { get; set; } = null!;
        public string? Reason { get; set; }
    }
}
