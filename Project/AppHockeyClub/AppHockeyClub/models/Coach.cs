using System;
using System.Collections.Generic;

namespace AppHockeyClub.models;

public partial class Coach
{
    public int CoachId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public DateOnly DateBirthday { get; set; }

    public int ExperienceYears { get; set; }

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
