using System;
using System.Collections.Generic;

namespace AppLicence.DataModels.Models;

public partial class User
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Prenume { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public virtual ICollection<GoalTask> GoalTasks { get; set; } = new List<GoalTask>();

    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();

    public virtual ICollection<Routine> Routines { get; set; } = new List<Routine>();

    public virtual ICollection<UserAchivement> UserAchivements { get; set; } = new List<UserAchivement>();

    public virtual ICollection<UserGoal> UserGoals { get; set; } = new List<UserGoal>();
}
