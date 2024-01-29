using System;
using System.Collections.Generic;

namespace AppLicence.DataModels.Models;

public partial class Routine
{
    public long Id { get; set; }

    public long CategoryId { get; set; }

    public long UserId { get; set; }

    public long Frequency { get; set; }

    public string Name { get; set; } = null!;

    public virtual RoutineCategory Category { get; set; } = null!;

    public virtual ICollection<RoutineTask> RoutineTasks { get; set; } = new List<RoutineTask>();

    public virtual User User { get; set; } = null!;
}
