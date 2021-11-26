using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string Ckey { get; set; } = null!;
        public string AdminRank { get; set; } = null!;
        public int Level { get; set; }
        public int Flags { get; set; }
    }
}
