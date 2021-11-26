using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class Memo
    {
        public string Ckey { get; set; } = null!;
        public string Memotext { get; set; } = null!;
        public DateTime Timestamp { get; set; }
        public string? LastEditor { get; set; }
        public string? Edits { get; set; }
    }
}
