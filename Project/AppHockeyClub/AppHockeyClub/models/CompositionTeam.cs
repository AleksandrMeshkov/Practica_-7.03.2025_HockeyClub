using System;
using System.Collections.Generic;

namespace AppHockeyClub.models;

public partial class CompositionTeam
{
    public int CompositionTeamId { get; set; }

    public int PlayersId { get; set; }

    public int PositionId { get; set; }

    public int AccountantId { get; set; }

    public int StatisticsId { get; set; }

    public int TeamId { get; set; }

    public virtual Accountant Accountant { get; set; } = null!;

    public virtual Player Players { get; set; } = null!;

    public virtual Position Position { get; set; } = null!;

    public virtual Statistic Statistics { get; set; } = null!;

    public virtual Team Team { get; set; } = null!;
}
