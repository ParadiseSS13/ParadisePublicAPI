using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database;

public partial class AdminRank
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DefaultPermissions { get; set; }
}
