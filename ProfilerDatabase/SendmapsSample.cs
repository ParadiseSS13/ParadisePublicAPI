using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.ProfilerDatabase;

public partial class SendmapsSample
{
    public long Id { get; set; }

    public int RoundId { get; set; }

    public DateTime SampleTime { get; set; }

    public long ProcId { get; set; }

    public double? Value { get; set; }

    public int Calls { get; set; }

    public virtual SendmapsProc Proc { get; set; } = null!;
}
