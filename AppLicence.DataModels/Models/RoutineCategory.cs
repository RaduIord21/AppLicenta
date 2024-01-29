using System;
using System.Collections.Generic;

namespace AppLicence.DataModels.Models;

public partial class RoutineCategory
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Routine> Routines { get; set; } = new List<Routine>();
}
