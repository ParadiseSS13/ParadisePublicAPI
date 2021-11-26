using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class AdminLog
    {
        public int Id { get; set; }
        public DateTime Datetime { get; set; }
        public string Adminckey { get; set; } = null!;
        public string Adminip { get; set; } = null!;
        public string Log { get; set; } = null!;
    }
}
