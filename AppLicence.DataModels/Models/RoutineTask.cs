using System;
using System.Collections.Generic;

namespace AppLicence.DataModels.Models;

public partial class RoutineTask
{
    public long Id { get; set; }

    public long RoutineId { get; set; }

    public bool Optional { get; set; }

    public string Status { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual Routine Routine { get; set; } = null!;
}
