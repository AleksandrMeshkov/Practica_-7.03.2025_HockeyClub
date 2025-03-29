using System;
using System.Collections.Generic;

namespace AppHockeyClub.models;

public partial class GameSchedule
{
    public int GameScheduleId { get; set; }

    public int TicketsId { get; set; }

    public int ArenaId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly TimeStart { get; set; }

    public TimeOnly TimeEnd { get; set; }

    public virtual Arena Arena { get; set; } = null!;

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

    public virtual Ticket Tickets { get; set; } = null!;
}
