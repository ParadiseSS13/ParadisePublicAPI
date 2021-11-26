using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class _2faSecret
    {
        public string Ckey { get; set; } = null!;
        public string Secret { get; set; } = null!;
        public DateTime DateSetup { get; set; }
        public DateTime? LastTime { get; set; }
    }
}
