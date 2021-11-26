using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class Whitelist
    {
        public int Id { get; set; }
        public string Ckey { get; set; } = null!;
        public string? Job { get; set; }
        public string? Species { get; set; }
    }
}
