using System;
using System.Collections.Generic;

namespace AppHockeyClub.models;

public partial class Arena
{
    public int ArenaId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Capacity { get; set; }

    public string City { get; set; } = null!;

    public virtual ICollection<GameSchedule> GameSchedules { get; set; } = new List<GameSchedule>();
}
