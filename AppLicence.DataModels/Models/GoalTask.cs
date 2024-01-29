using System;
using System.Collections.Generic;

namespace AppLicence.DataModels.Models;

public partial class GoalTask
{
    public long Id { get; set; }

    public long GoalId { get; set; }

    public long? AssigneeId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? EndDate { get; set; }

    public long Description { get; set; }

    public virtual User? Assignee { get; set; }

    public virtual Goal Goal { get; set; } = null!;
}
