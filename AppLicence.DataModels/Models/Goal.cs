using System;
using System.Collections.Generic;

namespace AppLicence.DataModels.Models;

public partial class Goal
{
    public long Id { get; set; }

    public long GoalName { get; set; }

    public long UserId { get; set; }

    public long Percentage { get; set; }

    public string GoalCode { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime? EndDate { get; set; }

    public long CategoryId { get; set; }

    public long OwnerId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual GoalCategory Category { get; set; } = null!;

    public virtual ICollection<GoalTask> GoalTasks { get; set; } = new List<GoalTask>();

    public virtual User Owner { get; set; } = null!;

    public virtual ICollection<UserGoal> UserGoals { get; set; } = new List<UserGoal>();
}
