using System;
using System.Collections.Generic;

namespace AppHockeyClub.models;

public partial class Position
{
    public int PositionId { get; set; }

    public string Name { get; set; } = null!;

    public int PlayersNumber { get; set; }

    public int SizeSkates { get; set; }

    public bool ClubGrip { get; set; }

    public virtual ICollection<CompositionTeam> CompositionTeams { get; set; } = new List<CompositionTeam>();
}
