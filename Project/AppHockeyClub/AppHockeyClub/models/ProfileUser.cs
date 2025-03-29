using System;
using System.Collections.Generic;

namespace AppHockeyClub.models;

public partial class ProfileUser
{
    public int ProfileUserId { get; set; }

    public int UserId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual User User { get; set; } = null!;
}
