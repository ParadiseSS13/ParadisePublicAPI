using System;
using System.Collections.Generic;

namespace ParadisePublicAPI.Database;

public partial class Ticket
{
    public int Id { get; set; }

    public int TicketNum { get; set; }

    public string TicketType { get; set; } = null!;

    public DateTime RealFiletime { get; set; }

    public TimeOnly RelativeFiletime { get; set; }

    public string TicketCreator { get; set; } = null!;

    public string TicketTopic { get; set; } = null!;

    public string? TicketTaker { get; set; }

    public DateTime? TicketTakeTime { get; set; }

    public string? AllResponses { get; set; }

    public string Awho { get; set; } = null!;

    public string EndRoundState { get; set; } = null!;
}
