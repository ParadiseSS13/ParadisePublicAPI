using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database;

public partial class BugReport
{
    public int Id { get; set; }

    public DateTime Filetime { get; set; }

    public string AuthorCkey { get; set; } = null!;

    public string? Title { get; set; }

    public int RoundId { get; set; }

    public string? ContentsJson { get; set; }

    public ulong Submitted { get; set; }

    public string ApproverCkey { get; set; } = null!;
}
