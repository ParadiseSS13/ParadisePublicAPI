using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database;

public partial class Ip2group
{
    public uint Ip { get; set; }

    public DateTime Date { get; set; }

    public uint Groupstr { get; set; }
}
