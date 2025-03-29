using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppHockeyClub.models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accountant> Accountants { get; set; }

    public virtual DbSet<Arena> Arenas { get; set; }

    public virtual DbSet<Coach> Coaches { get; set; }

    public virtual DbSet<CompositionTeam> CompositionTeams { get; set; }

    public virtual DbSet<GameSchedule> GameSchedules { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<ProfileUser> ProfileUsers { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Statistic> Statistics { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TrainingSchedule> TrainingSchedules { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Practica_HockeyClub;Username=Ackerman;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accountant>(entity =>
        {
            entity.HasKey(e => e.AccountantId).HasName("accountant_pkey");

            entity.ToTable("accountant");

            entity.Property(e => e.AccountantId)
                .HasDefaultValueSql("nextval('accountant_accountantid_seq'::regclass)")
                .HasColumnName("accountant_id");
            entity.Property(e => e.Fine)
                .HasPrecision(10, 2)
                .HasColumnName("fine");
            entity.Property(e => e.Prize)
                .HasPrecision(10, 2)
                .HasColumnName("prize");
            entity.Property(e => e.Salary)
                .HasPrecision(10, 2)
                .HasColumnName("salary");
        });

        modelBuilder.Entity<Arena>(entity =>
        {
            entity.HasKey(e => e.ArenaId).HasName("arena_pkey");

            entity.ToTable("arena");

            entity.Property(e => e.ArenaId)
                .HasDefaultValueSql("nextval('arena_arenaid_seq'::regclass)")
                .HasColumnName("arena_id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Coach>(entity =>
        {
            entity.HasKey(e => e.CoachId).HasName("coaches_pkey");

            entity.ToTable("coaches");

            entity.Property(e => e.CoachId)
                .HasDefaultValueSql("nextval('coaches_coachid_seq'::regclass)")
                .HasColumnName("coach_id");
            entity.Property(e => e.DateBirthday).HasColumnName("date_birthday");
            entity.Property(e => e.ExperienceYears).HasColumnName("experience_years");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(30)
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasMaxLength(20)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<CompositionTeam>(entity =>
        {
            entity.HasKey(e => e.CompositionTeamId).HasName("compositionteam_pkey");

            entity.ToTable("composition_team");

            entity.Property(e => e.CompositionTeamId)
                .HasDefaultValueSql("nextval('compositionteam_compositionteamid_seq'::regclass)")
                .HasColumnName("composition_team_id");
            entity.Property(e => e.AccountantId).HasColumnName("accountant_id");
            entity.Property(e => e.PlayersId).HasColumnName("players_id");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.StatisticsId).HasColumnName("statistics_id");
            entity.Property(e => e.TeamId).HasColumnName("team_id");

            entity.HasOne(d => d.Accountant).WithMany(p => p.CompositionTeams)
                .HasForeignKey(d => d.AccountantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("compositionteam_accountantid_fkey");

            entity.HasOne(d => d.Players).WithMany(p => p.CompositionTeams)
                .HasForeignKey(d => d.PlayersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("compositionteam_playersid_fkey");

            entity.HasOne(d => d.Position).WithMany(p => p.CompositionTeams)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("compositionteam_positionid_fkey");

            entity.HasOne(d => d.Statistics).WithMany(p => p.CompositionTeams)
                .HasForeignKey(d => d.StatisticsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("compositionteam_statisticsid_fkey");

            entity.HasOne(d => d.Team).WithMany(p => p.CompositionTeams)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_team");
        });

        modelBuilder.Entity<GameSchedule>(entity =>
        {
            entity.HasKey(e => e.GameScheduleId).HasName("gameschedule_pkey");

            entity.ToTable("game_schedule");

            entity.Property(e => e.GameScheduleId)
                .HasDefaultValueSql("nextval('gameschedule_gamescheduleid_seq'::regclass)")
                .HasColumnName("game_schedule_id");
            entity.Property(e => e.ArenaId).HasColumnName("arena_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.TicketsId).HasColumnName("tickets_id");
            entity.Property(e => e.TimeEnd).HasColumnName("time_end");
            entity.Property(e => e.TimeStart).HasColumnName("time_start");

            entity.HasOne(d => d.Arena).WithMany(p => p.GameSchedules)
                .HasForeignKey(d => d.ArenaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("gameschedule_arenaid_fkey");

            entity.HasOne(d => d.Tickets).WithMany(p => p.GameSchedules)
                .HasForeignKey(d => d.TicketsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("gameschedule_ticketsid_fkey");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PlayersId).HasName("players_pkey");

            entity.ToTable("players");

            entity.Property(e => e.PlayersId)
                .HasDefaultValueSql("nextval('players_playersid_seq'::regclass)")
                .HasColumnName("players_id");
            entity.Property(e => e.DateBirthday).HasColumnName("date_birthday");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(30)
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .HasColumnName("surname");
            entity.Property(e => e.Weight).HasColumnName("weight");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("position_pkey");

            entity.ToTable("position");

            entity.Property(e => e.PositionId)
                .HasDefaultValueSql("nextval('position_positionid_seq'::regclass)")
                .HasColumnName("position_id");
            entity.Property(e => e.ClubGrip).HasColumnName("club_grip");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.PlayersNumber).HasColumnName("players_number");
            entity.Property(e => e.SizeSkates).HasColumnName("size_skates");
        });

        modelBuilder.Entity<ProfileUser>(entity =>
        {
            entity.HasKey(e => e.ProfileUserId).HasName("profileusers_pkey");

            entity.ToTable("profile_users");

            entity.Property(e => e.ProfileUserId)
                .HasDefaultValueSql("nextval('profileusers_profileuserid_seq'::regclass)")
                .HasColumnName("profile_user_id");
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.ProfileUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("profileusers_userid_fkey");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("staff_pkey");

            entity.ToTable("staff");

            entity.Property(e => e.StaffId)
                .HasDefaultValueSql("nextval('staff_staffid_seq'::regclass)")
                .HasColumnName("staff_id");
            entity.Property(e => e.DateBirthday).HasColumnName("date_birthday");
            entity.Property(e => e.HireDate).HasColumnName("hire_date");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(30)
                .HasColumnName("patronymic");
            entity.Property(e => e.Post)
                .HasMaxLength(30)
                .HasColumnName("post");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Statistic>(entity =>
        {
            entity.HasKey(e => e.StatisticsId).HasName("statistics_pkey");

            entity.ToTable("statistics");

            entity.Property(e => e.StatisticsId)
                .HasDefaultValueSql("nextval('statistics_statisticsid_seq'::regclass)")
                .HasColumnName("statistics_id");
            entity.Property(e => e.Assist).HasColumnName("assist");
            entity.Property(e => e.GameTime).HasColumnName("game_time");
            entity.Property(e => e.NumberHeads).HasColumnName("number_heads");
            entity.Property(e => e.PenaltyTime).HasColumnName("penalty_time");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("teams_pkey");

            entity.ToTable("teams");

            entity.HasIndex(e => e.GameScheduleId, "fki_gs_team_fkey");

            entity.HasIndex(e => e.TeamId, "fki_teams_composition_fkey");

            entity.Property(e => e.TeamId)
                .HasDefaultValueSql("nextval('teams_teamid_seq'::regclass)")
                .HasColumnName("team_id");
            entity.Property(e => e.CoachId).HasColumnName("coach_id");
            entity.Property(e => e.GameScheduleId).HasColumnName("game_schedule_id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.QuantityPlayers).HasColumnName("quantity_players");
            entity.Property(e => e.StaffId).HasColumnName("staff_id");
            entity.Property(e => e.TrainingScheduleId).HasColumnName("training_schedule_id");

            entity.HasOne(d => d.Coach).WithMany(p => p.Teams)
                .HasForeignKey(d => d.CoachId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teams_coachid_fkey");

            entity.HasOne(d => d.GameSchedule).WithMany(p => p.Teams)
                .HasForeignKey(d => d.GameScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("gs_team_fkey");

            entity.HasOne(d => d.Staff).WithMany(p => p.Teams)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teams_staffid_fkey");

            entity.HasOne(d => d.TrainingSchedule).WithMany(p => p.Teams)
                .HasForeignKey(d => d.TrainingScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teams_trainingscheduleid_fkey");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketsId).HasName("tickets_pkey");

            entity.ToTable("tickets");

            entity.Property(e => e.TicketsId)
                .HasDefaultValueSql("nextval('tickets_ticketsid_seq'::regclass)")
                .HasColumnName("tickets_id");
            entity.Property(e => e.Category)
                .HasMaxLength(30)
                .HasColumnName("category");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.ProfileUserId).HasColumnName("profile_user_id");

            entity.HasOne(d => d.ProfileUser).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ProfileUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tickets_profileuserid_fkey");
        });

        modelBuilder.Entity<TrainingSchedule>(entity =>
        {
            entity.HasKey(e => e.TrainingScheduleId).HasName("trainingschedule_pkey");

            entity.ToTable("training_schedule");

            entity.Property(e => e.TrainingScheduleId)
                .HasDefaultValueSql("nextval('trainingschedule_trainingscheduleid_seq'::regclass)")
                .HasColumnName("training_schedule_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.TimeEnd).HasColumnName("time_end");
            entity.Property(e => e.TimeStart).HasColumnName("time_start");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("nextval('users_userid_seq'::regclass)")
                .HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(30)
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasMaxLength(13)
                .HasColumnName("phone");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .HasColumnName("surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
