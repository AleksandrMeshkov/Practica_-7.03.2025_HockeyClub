using System;
using System.Collections.Generic;

namespace AppHockeyClub.models;

public partial class Player
{
    public int PlayersId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public DateOnly DateBirthday { get; set; }

    public int Height { get; set; }

    public int Weight { get; set; }

    public virtual ICollection<CompositionTeam> CompositionTeams { get; set; } = new List<CompositionTeam>();
}
