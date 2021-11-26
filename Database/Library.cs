using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class Library
    {
        public int Id { get; set; }
        public string Author { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Ckey { get; set; } = null!;
        public int Flagged { get; set; }
    }
}
