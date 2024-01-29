using System;
using System.Collections.Generic;

namespace AppLicence.DataModels.Models;

public partial class GoalCategory
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();
}
