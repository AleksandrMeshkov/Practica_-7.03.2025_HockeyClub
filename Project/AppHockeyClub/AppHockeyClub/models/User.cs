using System;
using System.Collections.Generic;

namespace AppHockeyClub.models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public virtual ICollection<ProfileUser> ProfileUsers { get; set; } = new List<ProfileUser>();
}
