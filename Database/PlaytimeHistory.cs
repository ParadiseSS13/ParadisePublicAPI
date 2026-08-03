using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database;

public partial class PlaytimeHistory
{
    public string Ckey { get; set; } = null!;

    public DateOnly Date { get; set; }

    public short TimeLiving { get; set; }

    public short TimeCrew { get; set; }

    public short TimeSpecial { get; set; }

    public short TimeGhost { get; set; }

    public short TimeCommand { get; set; }

    public short TimeEngineering { get; set; }

    public short TimeMedical { get; set; }

    public short TimeScience { get; set; }

    public short TimeSupply { get; set; }

    public short TimeSecurity { get; set; }

    public short TimeSilicon { get; set; }

    public short TimeService { get; set; }
}
