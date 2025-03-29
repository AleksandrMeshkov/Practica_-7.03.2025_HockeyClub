using System;
using System.Collections.Generic;

namespace AppHockeyClub.models;

public partial class Team
{
    public int TeamId { get; set; }

    public int CoachId { get; set; }

    public int TrainingScheduleId { get; set; }

    public int StaffId { get; set; }

    public string Name { get; set; } = null!;

    public int QuantityPlayers { get; set; }

    public int GameScheduleId { get; set; }

    public virtual Coach Coach { get; set; } = null!;

    public virtual ICollection<CompositionTeam> CompositionTeams { get; set; } = new List<CompositionTeam>();

    public virtual GameSchedule GameSchedule { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;

    public virtual TrainingSchedule TrainingSchedule { get; set; } = null!;
}
