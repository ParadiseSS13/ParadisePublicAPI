using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class Karma
    {
        public int Id { get; set; }
        public string Spendername { get; set; } = null!;
        public string Spenderkey { get; set; } = null!;
        public string Receivername { get; set; } = null!;
        public string Receiverkey { get; set; } = null!;
        public string? Receiverrole { get; set; }
        public string? Receiverspecial { get; set; }
        public bool? Isnegative { get; set; }
        public string Spenderip { get; set; } = null!;
        public string? ServerId { get; set; }
        public DateTime Time { get; set; }
    }
}
