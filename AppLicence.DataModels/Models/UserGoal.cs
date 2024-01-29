using System;
using System.Collections.Generic;

namespace AppLicence.DataModels.Models;

public partial class UserGoal
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long GoalId { get; set; }

    public virtual Goal Goal { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
