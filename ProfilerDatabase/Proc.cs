using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.ProfilerDatabase
{
    public partial class Proc
    {
        public Proc()
        {
            Samples = new HashSet<Sample>();
        }

        public long Id { get; set; }
        public string Procpath { get; set; } = null!;

        public virtual ICollection<Sample> Samples { get; set; }
    }
}
