using System;
using System.Collections.Generic;

namespace AppLicence.Models;

public partial class UserViewModel
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Prenume { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsAdmin { get; set; }
}
