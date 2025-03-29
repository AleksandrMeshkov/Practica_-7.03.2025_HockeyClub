using System;
using System.Collections.Generic;

namespace AppHockeyClub.models;

public partial class Statistic
{
    public int StatisticsId { get; set; }

    public int NumberHeads { get; set; }

    public int Assist { get; set; }

    public TimeSpan GameTime { get; set; }

    public TimeSpan PenaltyTime { get; set; }

    public virtual ICollection<CompositionTeam> CompositionTeams { get; set; } = new List<CompositionTeam>();
}
