using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class PaiSafe
    {
        public int Id { get; set; }
        public string Ckey { get; set; } = null!;
        public string? PaiName { get; set; }
        public string? Description { get; set; }
        public string? PreferredRole { get; set; }
        public string? OocComments { get; set; }
    }
}
