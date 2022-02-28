using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ParadisePublicAPI.ProfilerDatabase
{
    public partial class paradise_profilerdaemonContext : DbContext
    {
        public paradise_profilerdaemonContext()
        {
        }

        public paradise_profilerdaemonContext(DbContextOptions<paradise_profilerdaemonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Proc> Procs { get; set; } = null!;
        public virtual DbSet<Sample> Samples { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Proc>(entity =>
            {
                entity.ToTable("procs");

                entity.HasIndex(e => e.Procpath, "procpath")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Procpath)
                    .HasMaxLength(512)
                    .HasColumnName("procpath");
            });

            modelBuilder.Entity<Sample>(entity =>
            {
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
                    .HasColumnType("datetime")
                    .HasColumnName("sampleTime")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Self).HasColumnName("self");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.Proc)
                    .WithMany(p => p.Samples)
                    .HasForeignKey(d => d.ProcId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1_procId_procs.id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
