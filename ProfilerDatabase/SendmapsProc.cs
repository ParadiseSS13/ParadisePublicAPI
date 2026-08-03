using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.ProfilerDatabase;

public partial class SendmapsProc
{
    public long Id { get; set; }

    public string Procpath { get; set; } = null!;

    public virtual ICollection<SendmapsSample> SendmapsSamples { get; set; } = new List<SendmapsSample>();
}
