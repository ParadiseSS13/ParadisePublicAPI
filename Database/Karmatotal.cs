using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class Karmatotal
    {
        public int Id { get; set; }
        public string Byondkey { get; set; } = null!;
        public int Karma { get; set; }
        public int Karmaspent { get; set; }
    }
}
