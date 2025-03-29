using System;
using System.Collections.Generic;

namespace AppHockeyClub.models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Post { get; set; } = null!;

    public DateOnly HireDate { get; set; }

    public DateOnly DateBirthday { get; set; }

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
