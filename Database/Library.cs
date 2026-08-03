using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database;

public partial class Library
{
    public int Id { get; set; }

    public string Author { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string Ckey { get; set; } = null!;

    public string Reports { get; set; } = null!;

    public string Summary { get; set; } = null!;

    public double? Rating { get; set; }

    public string Raters { get; set; } = null!;

    public int? PrimaryCategory { get; set; }

    public int SecondaryCategory { get; set; }

    public int? TertiaryCategory { get; set; }
}
