using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database;

public partial class Admin
{
    public int Id { get; set; }

    public string Ckey { get; set; } = null!;

    public string? DisplayRank { get; set; }

    /// <summary>
    /// Foreign key for admin_ranks.id
    /// </summary>
    public int? PermissionsRank { get; set; }

    public int ExtraPermissions { get; set; }

    public int RemovedPermissions { get; set; }
}
