using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class Death
    {
        public int Id { get; set; }
        /// <summary>
        /// Place of death
        /// </summary>
        public string Pod { get; set; } = null!;
        /// <summary>
        /// X, Y, Z POD
        /// </summary>
        public string Coord { get; set; } = null!;
        /// <summary>
        /// Time of death
        /// </summary>
        public DateTime Tod { get; set; }
        public string? ServerId { get; set; }
        public string Job { get; set; } = null!;
        public string Special { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Byondkey { get; set; } = null!;
        /// <summary>
        /// Last attacker name
        /// </summary>
        public string Laname { get; set; } = null!;
        /// <summary>
        /// Last attacker key
        /// </summary>
        public string Lakey { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public int Bruteloss { get; set; }
        public int Brainloss { get; set; }
        public int Fireloss { get; set; }
        public int Oxyloss { get; set; }
    }
}
