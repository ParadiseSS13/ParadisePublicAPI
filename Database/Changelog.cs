using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class Changelog
    {
        public int Id { get; set; }
        public int PrNumber { get; set; }
        public DateTime DateMerged { get; set; }
        public string Author { get; set; } = null!;
        public string ClType { get; set; } = null!;
        public string ClEntry { get; set; } = null!;
    }
}
