using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database
{
    public partial class Donator
    {
        public string PatreonName { get; set; } = null!;
        public int? Tier { get; set; }
        /// <summary>
        /// Manual Field
        /// </summary>
        public string? Ckey { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Active { get; set; }
    }
}
