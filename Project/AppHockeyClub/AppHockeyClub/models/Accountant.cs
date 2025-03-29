using System;
using System.Collections.Generic;

namespace AppHockeyClub.models;

public partial class Accountant
{
    public int AccountantId { get; set; }

    public decimal Salary { get; set; }

    public decimal Prize { get; set; }

    public decimal Fine { get; set; }

    public virtual ICollection<CompositionTeam> CompositionTeams { get; set; } = new List<CompositionTeam>();
}
