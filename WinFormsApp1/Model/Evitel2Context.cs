using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WinFormsApp1.Model
{
    public partial class Evitel2Context : DbContext
    {
        public Evitel2Context()
        {
        }

        public Evitel2Context(DbContextOptions<Evitel2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<LoginAccess> LoginAccesses { get; set; }
        public virtual DbSet<LoginAccessUser> LoginAccessUsers { get; set; }
        public virtual DbSet<LoginUser> LoginUsers { get; set; }
        public virtual DbSet<MainEventLog> MainEventLogs { get; set; }
        public virtual DbSet<MainSetting> MainSettings { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<WMainEventLog> WMainEventLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Evitel2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Czech_CI_AS");

            modelBuilder.Entity<LoginAccess>(entity =>
            {
                entity.Property(e => e.AccessName).HasMaxLength(50);
            });

            modelBuilder.Entity<LoginAccessUser>(entity =>
            {
                entity.HasIndex(e => e.LoginUserId, "IX_LoginAccessUsers_LoginUserId");

                entity.HasOne(d => d.LoginUser)
                    .WithMany(p => p.LoginAccessUsers)
                    .HasForeignKey(d => d.LoginUserId);
            });

            modelBuilder.Entity<LoginUser>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.LoginPassword).HasMaxLength(50);
            });

            modelBuilder.Entity<MainEventLog>(entity =>
            {
                entity.Property(e => e.DtCreate).HasColumnName("dtCreate");

                entity.Property(e => e.EventCode).HasColumnName("eventCode");

                entity.Property(e => e.EventSubCode).HasColumnName("eventSubCode");

                entity.Property(e => e.Program).HasMaxLength(50);
            });

            modelBuilder.Entity<MainSetting>(entity =>
            {
                entity.Property(e => e.DValue).HasColumnName("dValue");

                entity.Property(e => e.IValue).HasColumnName("iValue");

                entity.Property(e => e.SValue).HasColumnName("sValue");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.DescriptionType).HasMaxLength(50);

                entity.Property(e => e.DescriptionValue).HasMaxLength(50);

                entity.Property(e => e.Ewfewfwef)
                    .HasMaxLength(10)
                    .HasColumnName("ewfewfwef")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<WMainEventLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("wMainEventLogs");

                entity.Property(e => e.CodeText).HasMaxLength(50);

                entity.Property(e => e.DtCreate).HasColumnName("dtCreate");

                entity.Property(e => e.EventCode).HasColumnName("eventCode");

                entity.Property(e => e.EventSubCode).HasColumnName("eventSubCode");

                entity.Property(e => e.Program).HasMaxLength(50);

                entity.Property(e => e.SubCodeText).HasMaxLength(50);

                entity.Property(e => e.UserFirstName).HasMaxLength(50);

                entity.Property(e => e.UserLastName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
