using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.ProfilerDatabase
{
    public partial class Sample
    {
        public long Id { get; set; }
        public int RoundId { get; set; }
        public DateTime SampleTime { get; set; }
        public long ProcId { get; set; }
        public double Self { get; set; }
        public double Total { get; set; }
        public double Real { get; set; }
        public double Over { get; set; }
        public int Calls { get; set; }

        public virtual Proc Proc { get; set; } = null!;
    }
}
