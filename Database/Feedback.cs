using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class Feedback
    {
        public uint Id { get; set; }
        public DateTime Datetime { get; set; }
        public int RoundId { get; set; }
        public string KeyName { get; set; } = null!;
        public string KeyType { get; set; } = null!;
        public byte Version { get; set; }
        public string Json { get; set; } = null!;
    }
}
