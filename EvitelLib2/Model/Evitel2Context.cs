using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EvitelLib2.Model
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

        public virtual DbSet<Call> Calls { get; set; }
        public virtual DbSet<DataDq> DataDqs { get; set; }
        public virtual DbSet<EDruhIntervence> EDruhIntervences { get; set; }
        public virtual DbSet<ESex> ESexes { get; set; }
        public virtual DbSet<ESubTypeIntervence> ESubTypeIntervences { get; set; }
        public virtual DbSet<ETypeIntervence> ETypeIntervences { get; set; }
        public virtual DbSet<ETypeParty> ETypeParties { get; set; }
        public virtual DbSet<Intervent> Intervents { get; set; }
        public virtual DbSet<Likoincident> Likoincidents { get; set; }
        public virtual DbSet<Likointervence> Likointervences { get; set; }
        public virtual DbSet<Likoparticipant> Likoparticipants { get; set; }
        public virtual DbSet<List1> List1s { get; set; }
        public virtual DbSet<LoginAccess> LoginAccesses { get; set; }
        public virtual DbSet<LoginAccessUser> LoginAccessUsers { get; set; }
        public virtual DbSet<LoginUser> LoginUsers { get; set; }
        public virtual DbSet<MainEventLog> MainEventLogs { get; set; }
        public virtual DbSet<MainSetting> MainSettings { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<WIntervent> WIntervents { get; set; }
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

            modelBuilder.Entity<Call>(entity =>
            {
                entity.Property(e => e.DtEndCall).HasColumnName("dtEndCall");

                entity.Property(e => e.DtStartCall).HasColumnName("dtStartCall");

                entity.HasOne(d => d.LoginUser)
                    .WithMany(p => p.Calls)
                    .HasForeignKey(d => d.LoginUserId)
                    .HasConstraintName("FK_Calls_LoginUsers");
            });

            modelBuilder.Entity<DataDq>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Data_dq");

                entity.Property(e => e.F10).HasMaxLength(255);

                entity.Property(e => e.F2).HasMaxLength(255);

                entity.Property(e => e.F3).HasMaxLength(255);

                entity.Property(e => e.F4).HasMaxLength(255);

                entity.Property(e => e.F5).HasMaxLength(255);

                entity.Property(e => e.F7).HasMaxLength(255);

                entity.Property(e => e.F8).HasMaxLength(255);

                entity.Property(e => e.F9).HasMaxLength(255);

                entity.Property(e => e._1Praha)
                    .HasMaxLength(255)
                    .HasColumnName("1  PRAHA");
            });

            modelBuilder.Entity<EDruhIntervence>(entity =>
            {
                entity.HasKey(e => e.DruhIntervenceId);

                entity.ToTable("eDruhIntervence");

                entity.Property(e => e.DtDeleted)
                    .HasColumnType("datetime")
                    .HasColumnName("dtDeleted");

                entity.Property(e => e.Text).HasMaxLength(50);
            });

            modelBuilder.Entity<ESex>(entity =>
            {
                entity.HasKey(e => e.SexId);

                entity.ToTable("eSex");

                entity.Property(e => e.DtDelete)
                    .HasColumnType("datetime")
                    .HasColumnName("dtDelete");

                entity.Property(e => e.Text).HasMaxLength(50);
            });

            modelBuilder.Entity<ESubTypeIntervence>(entity =>
            {
                entity.HasKey(e => e.SubTypeIntervenceId)
                    .HasName("PK_eSubEvent");

                entity.ToTable("eSubTypeIntervence");

                entity.Property(e => e.DtDeleted)
                    .HasColumnType("datetime")
                    .HasColumnName("dtDeleted");

                entity.Property(e => e.Kategorie).HasMaxLength(50);

                entity.Property(e => e.Text).HasMaxLength(255);

                entity.HasOne(d => d.TypeIntervence)
                    .WithMany(p => p.ESubTypeIntervences)
                    .HasForeignKey(d => d.TypeIntervenceId)
                    .HasConstraintName("FK_eSubTypeIntevence_eTypeIntervence");
            });

            modelBuilder.Entity<ETypeIntervence>(entity =>
            {
                entity.HasKey(e => e.TypeIntervenceId)
                    .HasName("PK_eEvent");

                entity.ToTable("eTypeIntervence");

                entity.Property(e => e.DtDeleted)
                    .HasColumnType("datetime")
                    .HasColumnName("dtDeleted");

                entity.Property(e => e.ShortText).HasMaxLength(5);

                entity.Property(e => e.Text).HasMaxLength(50);
            });

            modelBuilder.Entity<ETypeParty>(entity =>
            {
                entity.HasKey(e => e.TypePartyId);

                entity.ToTable("eTypeParty");

                entity.Property(e => e.DtDelete)
                    .HasColumnType("datetime")
                    .HasColumnName("dtDelete");

                entity.Property(e => e.Text).HasMaxLength(50);
            });

            modelBuilder.Entity<Intervent>(entity =>
            {
                entity.Property(e => e.DtDeleted).HasColumnName("dtDeleted");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.MobilPhone).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.PrivatePhone).HasMaxLength(20);

                entity.Property(e => e.Rank).HasMaxLength(50);

                entity.Property(e => e.SurName).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(20);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Intervents)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK_Intervents_Regions");
            });

            modelBuilder.Entity<Likoincident>(entity =>
            {
                entity.ToTable("LIKOIncidents");

                entity.Property(e => e.LikoincidentId).HasColumnName("LIKOIncidentId");

                entity.Property(e => e.DtDeleted)
                    .HasColumnType("datetime")
                    .HasColumnName("dtDeleted");

                entity.Property(e => e.DtIncident)
                    .HasColumnType("datetime")
                    .HasColumnName("dtIncident");

                entity.Property(e => e.LikoincidentIdMaster).HasColumnName("LIKOIncidentIdMaster");

                entity.Property(e => e.PokusPriprava).HasColumnName("Pokus_Priprava");

                entity.Property(e => e.SubTypeIntervenceEid).HasColumnName("SubTypeIntervenceEID");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.LikoincidentIdMasterNavigation)
                    .WithMany(p => p.InverseLikoincidentIdMasterNavigation)
                    .HasForeignKey(d => d.LikoincidentIdMaster)
                    .HasConstraintName("FK_LIKOIncidents_LIKOIncidents");

                entity.HasOne(d => d.SubTypeIntervenceE)
                    .WithMany(p => p.Likoincidents)
                    .HasForeignKey(d => d.SubTypeIntervenceEid)
                    .HasConstraintName("FK_LIKOIncidents_eSubTypeIntervence");
            });

            modelBuilder.Entity<Likointervence>(entity =>
            {
                entity.HasKey(e => e.IntervenceId);

                entity.ToTable("LIKOIntervence");

                entity.Property(e => e.DtEndIntervence).HasColumnName("dtEndIntervence");

                entity.Property(e => e.DtStartIntervence).HasColumnName("dtStartIntervence");

                entity.Property(e => e.LikoincidentId).HasColumnName("LIKOIncidentId");

                entity.HasOne(d => d.Call)
                    .WithMany(p => p.Likointervences)
                    .HasForeignKey(d => d.CallId)
                    .HasConstraintName("FK_LIKOIntervence_Calls");

                entity.HasOne(d => d.Likoincident)
                    .WithMany(p => p.Likointervences)
                    .HasForeignKey(d => d.LikoincidentId)
                    .HasConstraintName("FK_LIKOIntervence_LIKOIncidents");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Likointervences)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK_LIKOIntervence_Regions");
            });

            modelBuilder.Entity<Likoparticipant>(entity =>
            {
                entity.ToTable("LIKOParticipant");

                entity.Property(e => e.LikoparticipantId).HasColumnName("LIKOParticipantId");

                entity.Property(e => e.DruhIntervenceEid).HasColumnName("DruhIntervenceEID");

                entity.Property(e => e.LikoincidentId).HasColumnName("LIKOIncidentId");

                entity.Property(e => e.Organization).HasMaxLength(255);

                entity.Property(e => e.SexEid).HasColumnName("SexEID");

                entity.Property(e => e.TypePartyEid).HasColumnName("TypePartyEID");

                entity.HasOne(d => d.DruhIntervenceE)
                    .WithMany(p => p.Likoparticipants)
                    .HasForeignKey(d => d.DruhIntervenceEid)
                    .HasConstraintName("FK_LIKOParticipant_eDruhIntervence");

                entity.HasOne(d => d.Intervent)
                    .WithMany(p => p.Likoparticipants)
                    .HasForeignKey(d => d.InterventId)
                    .HasConstraintName("FK_LIKOParticipant_LIKOParticipant1");

                entity.HasOne(d => d.Likoincident)
                    .WithMany(p => p.Likoparticipants)
                    .HasForeignKey(d => d.LikoincidentId)
                    .HasConstraintName("FK_LIKOParticipant_LIKOIncidents");

                entity.HasOne(d => d.SexE)
                    .WithMany(p => p.Likoparticipants)
                    .HasForeignKey(d => d.SexEid)
                    .HasConstraintName("FK_LIKOParticipant_eSex");

                entity.HasOne(d => d.TypePartyE)
                    .WithMany(p => p.Likoparticipants)
                    .HasForeignKey(d => d.TypePartyEid)
                    .HasConstraintName("FK_LIKOParticipant_eTypeParty");
            });

            modelBuilder.Entity<List1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("List1$");

                entity.Property(e => e.F11).HasMaxLength(255);

                entity.Property(e => e.F2).HasMaxLength(255);

                entity.Property(e => e.F3).HasMaxLength(255);

                entity.Property(e => e.F4).HasMaxLength(255);

                entity.Property(e => e.F5).HasMaxLength(255);

                entity.Property(e => e.F6).HasMaxLength(255);

                entity.Property(e => e.F7).HasMaxLength(255);

                entity.Property(e => e.F8).HasMaxLength(255);

                entity.Property(e => e.F9).HasMaxLength(255);

                entity.Property(e => e._2StředočeskýKraj)
                    .HasMaxLength(255)
                    .HasColumnName("2  STŘEDOČESKÝ KRAJ");
            });

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

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Name2).HasMaxLength(50);

                entity.Property(e => e.ShortName).HasMaxLength(10);
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

            modelBuilder.Entity<WIntervent>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("wIntervent");

                entity.Property(e => e.CmbName)
                    .HasMaxLength(114)
                    .HasColumnName("cmbName");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Rank).HasMaxLength(50);

                entity.Property(e => e.RegionName).HasMaxLength(50);

                entity.Property(e => e.RegionShortName).HasMaxLength(10);

                entity.Property(e => e.SurName).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(20);
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
