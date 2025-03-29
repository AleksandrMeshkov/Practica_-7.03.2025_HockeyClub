using System;
using System.Collections.Generic;

namespace AppHockeyClub.models;

public partial class TrainingSchedule
{
    public int TrainingScheduleId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly TimeStart { get; set; }

    public TimeOnly TimeEnd { get; set; }

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
