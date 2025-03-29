using System;
using System.Collections.Generic;

namespace AppHockeyClub.models;

public partial class Ticket
{
    public int TicketsId { get; set; }

    public int ProfileUserId { get; set; }

    public decimal Price { get; set; }

    public string Category { get; set; } = null!;

    public virtual ICollection<GameSchedule> GameSchedules { get; set; } = new List<GameSchedule>();

    public virtual ProfileUser ProfileUser { get; set; } = null!;
}
