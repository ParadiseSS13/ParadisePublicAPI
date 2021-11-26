using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class ConnectionLog
    {
        public int Id { get; set; }
        public DateTime Datetime { get; set; }
        public string Ckey { get; set; } = null!;
        public string Ip { get; set; } = null!;
        public string Computerid { get; set; } = null!;
        public string? ServerId { get; set; }
        public string Result { get; set; } = null!;
    }
}
