using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class PlaytimeHistory
    {
        public string Ckey { get; set; } = null!;
        public DateOnly Date { get; set; }
        public short TimeLiving { get; set; }
        public short TimeGhost { get; set; }
    }
}
