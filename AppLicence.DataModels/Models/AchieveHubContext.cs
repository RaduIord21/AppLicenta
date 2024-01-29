using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppLicence.DataModels.Models;

public partial class AchieveHubContext : DbContext
{
    public AchieveHubContext()
    {
    }

    public AchieveHubContext(DbContextOptions<AchieveHubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achivement> Achivements { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<GoalCategory> GoalCategories { get; set; }

    public virtual DbSet<GoalTask> GoalTasks { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Routine> Routines { get; set; }

    public virtual DbSet<RoutineCategory> RoutineCategories { get; set; }

    public virtual DbSet<RoutineTask> RoutineTasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAchivement> UserAchivements { get; set; }

    public virtual DbSet<UserGoal> UserGoals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=AchieveHub;MultipleActiveResultSets=true;User Id=sa;Password=gtyHHu*8;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achivement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("achivements_id_primary");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripton).HasColumnName("descripton");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("goal_id_primary");

            entity.ToTable("Goal");

            entity.HasIndex(e => e.GoalCode, "goal_goal_code_unique").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.GoalCode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Goal_code");
            entity.Property(e => e.GoalName).HasColumnName("Goal_name");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.Category).WithMany(p => p.Goals)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("goal_categoryid_foreign");

            entity.HasOne(d => d.Owner).WithMany(p => p.Goals)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("goal_ownerid_foreign");
        });

        modelBuilder.Entity<GoalCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("goalcategory_id_primary");

            entity.ToTable("GoalCategory");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<GoalTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("goaltask_id_primary");

            entity.ToTable("GoalTask");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");

            entity.HasOne(d => d.Assignee).WithMany(p => p.GoalTasks)
                .HasForeignKey(d => d.AssigneeId)
                .HasConstraintName("goaltask_assigneeid_foreign");

            entity.HasOne(d => d.Goal).WithMany(p => p.GoalTasks)
                .HasForeignKey(d => d.GoalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("goaltask_goalid_foreign");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("notification_id_primary");

            entity.ToTable("Notification");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Content).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Subject).HasMaxLength(255);
        });

        modelBuilder.Entity<Routine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("routine_id_primary");

            entity.ToTable("Routine");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Category).WithMany(p => p.Routines)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("routine_categoryid_foreign");

            entity.HasOne(d => d.User).WithMany(p => p.Routines)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("routine_userid_foreign");
        });

        modelBuilder.Entity<RoutineCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("routinecategory_id_primary");

            entity.ToTable("RoutineCategory");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RoutineTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("routinetask_id_primary");

            entity.ToTable("RoutineTask");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.Routine).WithMany(p => p.RoutineTasks)
                .HasForeignKey(d => d.RoutineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("routinetask_routineid_foreign");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_id_primary");

            entity.ToTable("User");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Prenume).HasMaxLength(255);
        });

        modelBuilder.Entity<UserAchivement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_achivements_id_primary");

            entity.ToTable("User_achivements");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AchivementId).HasColumnName("Achivement_ID");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.Achivement).WithMany(p => p.UserAchivements)
                .HasForeignKey(d => d.AchivementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_achivements_achivement_id_foreign");

            entity.HasOne(d => d.User).WithMany(p => p.UserAchivements)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_achivements_user_id_foreign");
        });

        modelBuilder.Entity<UserGoal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usergoal_id_primary");

            entity.ToTable("UserGoal");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            entity.HasOne(d => d.Goal).WithMany(p => p.UserGoals)
                .HasForeignKey(d => d.GoalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usergoal_goalid_foreign");

            entity.HasOne(d => d.User).WithMany(p => p.UserGoals)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usergoal_userid_foreign");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
