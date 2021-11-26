using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class Note
    {
        public int Id { get; set; }
        public string Ckey { get; set; } = null!;
        public string Notetext { get; set; } = null!;
        public DateTime Timestamp { get; set; }
        public int? RoundId { get; set; }
        public string Adminckey { get; set; } = null!;
        public string? LastEditor { get; set; }
        public string? Edits { get; set; }
        public string Server { get; set; } = null!;
        public uint? CrewPlaytime { get; set; }
        public byte? Automated { get; set; }
    }
}
