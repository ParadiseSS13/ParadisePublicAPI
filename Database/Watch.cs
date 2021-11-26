using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class Watch
    {
        public string Ckey { get; set; } = null!;
        public string Reason { get; set; } = null!;
        public DateTime Timestamp { get; set; }
        public string Adminckey { get; set; } = null!;
        public string? LastEditor { get; set; }
        public string? Edits { get; set; }
    }
}
