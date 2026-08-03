using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database;

public partial class JsonDatumSafe
{
    public int Id { get; set; }

    public string Ckey { get; set; } = null!;

    public string Slotname { get; set; } = null!;

    public string Slotjson { get; set; } = null!;

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }
}
