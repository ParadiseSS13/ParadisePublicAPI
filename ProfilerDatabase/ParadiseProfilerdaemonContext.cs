using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ParadisePublicAPI.ProfilerDatabase;

public partial class ParadiseProfilerdaemonContext : DbContext
{
    public ParadiseProfilerdaemonContext()
    {
    }

    public ParadiseProfilerdaemonContext(DbContextOptions<ParadiseProfilerdaemonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Proc> Procs { get; set; }

    public virtual DbSet<Sample> Samples { get; set; }

    public virtual DbSet<SendmapsProc> SendmapsProcs { get; set; }

    public virtual DbSet<SendmapsSample> SendmapsSamples { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Proc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("procs");

            entity.HasIndex(e => e.Procpath, "procpath").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.Procpath)
                .HasMaxLength(512)
                .HasColumnName("procpath");
        });

        modelBuilder.Entity<Sample>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("samples");

            entity.HasIndex(e => e.ProcId, "FK1_procId_procs.id");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.Calls)
                .HasColumnType("int(11)")
                .HasColumnName("calls");
            entity.Property(e => e.Over).HasColumnName("over");
            entity.Property(e => e.ProcId)
                .HasColumnType("bigint(20)")
                .HasColumnName("procId");
            entity.Property(e => e.Real).HasColumnName("real");
            entity.Property(e => e.RoundId)
                .HasColumnType("int(11)")
                .HasColumnName("roundId");
            entity.Property(e => e.SampleTime)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("sampleTime");
            entity.Property(e => e.Self).HasColumnName("self");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.Proc).WithMany(p => p.Samples)
                .HasForeignKey(d => d.ProcId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK1_procId_procs.id");
        });

        modelBuilder.Entity<SendmapsProc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sendmaps_procs");

            entity.HasIndex(e => e.Procpath, "procpath").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.Procpath)
                .HasMaxLength(512)
                .HasColumnName("procpath");
        });

        modelBuilder.Entity<SendmapsSample>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sendmaps_samples");

            entity.HasIndex(e => e.ProcId, "FK1_procId_sendmaps_procs.id");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.Calls)
                .HasColumnType("int(11)")
                .HasColumnName("calls");
            entity.Property(e => e.ProcId)
                .HasColumnType("bigint(20)")
                .HasColumnName("procId");
            entity.Property(e => e.RoundId)
                .HasColumnType("int(11)")
                .HasColumnName("roundId");
            entity.Property(e => e.SampleTime)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("sampleTime");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.Proc).WithMany(p => p.SendmapsSamples)
                .HasForeignKey(d => d.ProcId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sendmaps_samples_sendmaps_procs");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
