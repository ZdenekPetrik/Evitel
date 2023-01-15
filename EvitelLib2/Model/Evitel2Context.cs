using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
    public virtual DbSet<EDruhIntervence> EDruhIntervences { get; set; }
    public virtual DbSet<ESex> ESexes { get; set; }
    public virtual DbSet<ESubTypeIncident> ESubTypeIncidents { get; set; }
    public virtual DbSet<ETypeIncident> ETypeIncidents { get; set; }
    public virtual DbSet<ETypeParty> ETypeParties { get; set; }
    public virtual DbSet<Intervent> Intervents { get; set; }
    public virtual DbSet<Likoincident> Likoincidents { get; set; }
    public virtual DbSet<Likointervence> Likointervences { get; set; }
    public virtual DbSet<Likoparticipant> Likoparticipants { get; set; }
    public virtual DbSet<LoginAccess> LoginAccesses { get; set; }
    public virtual DbSet<LoginAccessUser> LoginAccessUsers { get; set; }
    public virtual DbSet<LoginUser> LoginUsers { get; set; }
    public virtual DbSet<MainEventLog> MainEventLogs { get; set; }
    public virtual DbSet<MainSetting> MainSettings { get; set; }
    public virtual DbSet<Region> Regions { get; set; }
    public virtual DbSet<State> States { get; set; }
    public virtual DbSet<UserColumn> UserColumns { get; set; }
    public virtual DbSet<UserSetting> UserSettings { get; set; }
    public virtual DbSet<WIntervent> WIntervents { get; set; }
    public virtual DbSet<WLikoall> WLikoalls { get; set; }
    public virtual DbSet<WLikocall> WLikocalls { get; set; }
    public virtual DbSet<WLikoincident> WLikoincidents { get; set; }
    public virtual DbSet<WLikointervence> WLikointervences { get; set; }
    public virtual DbSet<WLikoparticipant> WLikoparticipants { get; set; }
    public virtual DbSet<WMainEventLog> WMainEventLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBEvitel2"].ConnectionString;
        optionsBuilder.UseSqlServer(connectionString);
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Call>(entity =>
      {
        entity.Property(e => e.DtEndCall).HasColumnName("dtEndCall");

        entity.Property(e => e.DtStartCall).HasColumnName("dtStartCall");

        entity.HasOne(d => d.LoginUser)
                  .WithMany(p => p.Calls)
                  .HasForeignKey(d => d.LoginUserId)
                  .HasConstraintName("FK_Calls_LoginUsers");
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

        entity.Property(e => e.DtDeleted)
                  .HasColumnType("datetime")
                  .HasColumnName("dtDeleted");

        entity.Property(e => e.Text).HasMaxLength(50);
      });

      modelBuilder.Entity<ESubTypeIncident>(entity =>
      {
        entity.HasKey(e => e.SubTypeIncidentId);

        entity.ToTable("eSubTypeIncident");

        entity.Property(e => e.DtDeleted)
                  .HasColumnType("datetime")
                  .HasColumnName("dtDeleted");

        entity.Property(e => e.Kategorie).HasMaxLength(50);

        entity.Property(e => e.Text).HasMaxLength(255);

        entity.HasOne(d => d.TypeIncident)
                  .WithMany(p => p.ESubTypeIncidents)
                  .HasForeignKey(d => d.TypeIncidentId)
                  .HasConstraintName("FK_eSubTypeIncident_eTypeIncident");
      });

      modelBuilder.Entity<ETypeIncident>(entity =>
      {
        entity.HasKey(e => e.TypeIncidentId)
                  .HasName("PK_eEvent");

        entity.ToTable("eTypeIncident");

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

        entity.Property(e => e.DtDeleted)
                  .HasColumnType("datetime")
                  .HasColumnName("dtDeleted");

        entity.Property(e => e.Text).HasMaxLength(50);
      });

      modelBuilder.Entity<Intervent>(entity =>
      {
        entity.Property(e => e.DtCreate)
                  .HasColumnName("dtCreate")
                  .HasDefaultValueSql("(getdate())");

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

        entity.Property(e => e.Place).HasMaxLength(50);

        entity.Property(e => e.PokusPriprava).HasColumnName("Pokus_Priprava");

        entity.Property(e => e.SubTypeIncidentEid).HasColumnName("SubTypeIncidentEID");

        entity.Property(e => e.Title).HasMaxLength(100);

        entity.HasOne(d => d.SubTypeIncidentE)
                  .WithMany(p => p.Likoincidents)
                  .HasForeignKey(d => d.SubTypeIncidentEid)
                  .HasConstraintName("FK_LIKOIncidents_eSubTypeIncident");
      });

      modelBuilder.Entity<Likointervence>(entity =>
      {
        entity.ToTable("LIKOIntervence");

        entity.Property(e => e.LikointervenceId).HasColumnName("LIKOIntervenceId");

        entity.Property(e => e.DtEndIntervence).HasColumnName("dtEndIntervence");

        entity.Property(e => e.DtStartIntervence).HasColumnName("dtStartIntervence");

        entity.Property(e => e.LikoincidentId).HasColumnName("LIKOIncidentId");

        entity.Property(e => e.LikointervenceIdmaster).HasColumnName("LIKOIntervenceIDMaster");

        entity.HasOne(d => d.Call)
                  .WithMany(p => p.Likointervences)
                  .HasForeignKey(d => d.CallId)
                  .HasConstraintName("FK_LIKOIntervence_Calls");

        entity.HasOne(d => d.Intervent)
                  .WithMany(p => p.Likointervences)
                  .HasForeignKey(d => d.InterventId)
                  .HasConstraintName("FK_LIKOIntervence_Intervents");

        entity.HasOne(d => d.Likoincident)
                  .WithMany(p => p.Likointervences)
                  .HasForeignKey(d => d.LikoincidentId)
                  .HasConstraintName("FK_LIKOIntervence_LIKOIncidents");
      });

      modelBuilder.Entity<Likoparticipant>(entity =>
      {
        entity.ToTable("LIKOParticipant");

        entity.Property(e => e.LikoparticipantId).HasColumnName("LIKOParticipantId");

        entity.Property(e => e.DruhIntervenceEid).HasColumnName("DruhIntervenceEID");

        entity.Property(e => e.IsAgreementBkb).HasColumnName("IsAgreementBKB");

        entity.Property(e => e.LikointervenceId).HasColumnName("LIKOIntervenceId");

        entity.Property(e => e.Organization).HasMaxLength(255);

        entity.Property(e => e.SexEid).HasColumnName("SexEID");

        entity.Property(e => e.TypePartyEid).HasColumnName("TypePartyEID");

        entity.HasOne(d => d.DruhIntervenceE)
                  .WithMany(p => p.Likoparticipants)
                  .HasForeignKey(d => d.DruhIntervenceEid)
                  .HasConstraintName("FK_LIKOParticipant_eDruhIntervence");

        entity.HasOne(d => d.Intervent)
                  .WithMany(p => p.LikoparticipantIntervents)
                  .HasForeignKey(d => d.InterventId)
                  .HasConstraintName("FK_LIKOParticipant_Intervents");

        entity.HasOne(d => d.InterventId2Navigation)
                  .WithMany(p => p.LikoparticipantInterventId2Navigations)
                  .HasForeignKey(d => d.InterventId2)
                  .HasConstraintName("FK_LIKOParticipant_Intervents2");

        entity.HasOne(d => d.Likointervence)
                  .WithMany(p => p.Likoparticipants)
                  .HasForeignKey(d => d.LikointervenceId)
                  .HasConstraintName("FK_LIKOParticipant_LIKOIntervence");

        entity.HasOne(d => d.SexE)
                  .WithMany(p => p.Likoparticipants)
                  .HasForeignKey(d => d.SexEid)
                  .HasConstraintName("FK_LIKOParticipant_eSex");

        entity.HasOne(d => d.TypePartyE)
                  .WithMany(p => p.Likoparticipants)
                  .HasForeignKey(d => d.TypePartyEid)
                  .HasConstraintName("FK_LIKOParticipant_eTypeParty");
      });

      modelBuilder.Entity<LoginAccess>(entity =>
      {
        entity.Property(e => e.AccessName).HasMaxLength(50);

        entity.Property(e => e.AccessShortName).HasMaxLength(3);
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
      });

      modelBuilder.Entity<UserColumn>(entity =>
      {
        entity.Property(e => e.Name).HasMaxLength(255);
      });

      modelBuilder.Entity<UserSetting>(entity =>
      {
        entity.ToTable("UserSetting");

        entity.Property(e => e.DValue).HasColumnName("dValue");

        entity.Property(e => e.IValue).HasColumnName("iValue");

        entity.Property(e => e.Name).HasMaxLength(255);

        entity.Property(e => e.SValue).HasColumnName("sValue");
      });

      modelBuilder.Entity<WIntervent>(entity =>
      {
        entity.HasNoKey();

        entity.ToView("wIntervent");

        entity.Property(e => e.CmbName)
                  .HasMaxLength(114)
                  .HasColumnName("cmbName");

        entity.Property(e => e.DtCreate).HasColumnName("dtCreate");

        entity.Property(e => e.Email).HasMaxLength(255);

        entity.Property(e => e.InterventShortName).HasMaxLength(53);

        entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

        entity.Property(e => e.MobilPhone).HasMaxLength(20);

        entity.Property(e => e.Name).HasMaxLength(50);

        entity.Property(e => e.Phone).HasMaxLength(20);

        entity.Property(e => e.PrivatePhone).HasMaxLength(20);

        entity.Property(e => e.Rank).HasMaxLength(50);

        entity.Property(e => e.RegionName).HasMaxLength(50);

        entity.Property(e => e.RegionShortName).HasMaxLength(10);

        entity.Property(e => e.SurName).HasMaxLength(50);

        entity.Property(e => e.Title).HasMaxLength(20);
      });

      modelBuilder.Entity<WLikoall>(entity =>
      {
        entity.HasNoKey();

        entity.ToView("wLIKOAll");

        entity.Property(e => e.DruhIntervenceEid).HasColumnName("DruhIntervenceEID");

        entity.Property(e => e.DruhIntervenceText).HasMaxLength(50);

        entity.Property(e => e.DtEndIntervence).HasColumnName("dtEndIntervence");

        entity.Property(e => e.DtIncident)
                  .HasColumnType("datetime")
                  .HasColumnName("dtIncident");

        entity.Property(e => e.DtStartCall).HasColumnName("dtStartCall");

        entity.Property(e => e.DtStartIntervence).HasColumnName("dtStartIntervence");

        entity.Property(e => e.FirstName).HasMaxLength(50);

        entity.Property(e => e.IncIncident)
                  .HasMaxLength(255)
                  .HasColumnName("inc_Incident");

        entity.Property(e => e.IncKategorie)
                  .HasMaxLength(50)
                  .HasColumnName("inc_Kategorie");

        entity.Property(e => e.IncMisto)
                  .HasMaxLength(50)
                  .HasColumnName("inc_Misto");

        entity.Property(e => e.IncNote).HasColumnName("inc_Note");

        entity.Property(e => e.IncRegion)
                  .HasMaxLength(50)
                  .HasColumnName("inc_Region");

        entity.Property(e => e.IncRegionId).HasColumnName("inc_RegionId");

        entity.Property(e => e.IntInterventId).HasColumnName("int_interventId");

        entity.Property(e => e.IntInterventName)
                  .HasMaxLength(53)
                  .HasColumnName("int_InterventName");

        entity.Property(e => e.IntRegion)
                  .HasMaxLength(50)
                  .HasColumnName("int_Region");

        entity.Property(e => e.IntervenceNote).HasColumnName("intervenceNote");

        entity.Property(e => e.Intervent2Name).HasMaxLength(53);

        entity.Property(e => e.InterventName).HasMaxLength(53);

        entity.Property(e => e.IsAgreementBkb).HasColumnName("isAgreementBKB");

        entity.Property(e => e.LastName).HasMaxLength(50);

        entity.Property(e => e.LikoincidentId).HasColumnName("LIKOIncidentId");

        entity.Property(e => e.LikointervenceId).HasColumnName("LIKOIntervenceId");

        entity.Property(e => e.LikoparticipantId).HasColumnName("LIKOParticipantId");

        entity.Property(e => e.Organization).HasMaxLength(255);

        entity.Property(e => e.PokusPriprava).HasColumnName("Pokus_Priprava");

        entity.Property(e => e.RegionName).HasMaxLength(50);

        entity.Property(e => e.SexEid).HasColumnName("SexEID");

        entity.Property(e => e.SexText).HasMaxLength(50);

        entity.Property(e => e.SubTypeIncidentEid).HasColumnName("SubTypeIncidentEID");

        entity.Property(e => e.TypePartyEid).HasColumnName("TypePartyEID");

        entity.Property(e => e.TypePartyText).HasMaxLength(50);
      });

      modelBuilder.Entity<WLikocall>(entity =>
      {
        entity.HasNoKey();

        entity.ToView("wLIKOCalls");

        entity.Property(e => e.DtCall)
                  .HasColumnType("date")
                  .HasColumnName("dtCall");

        entity.Property(e => e.DtStartCall).HasColumnName("dtStartCall");

        entity.Property(e => e.InterventShortName).HasMaxLength(53);

        entity.Property(e => e.LikointervenceId).HasColumnName("LIKOIntervenceId");

        entity.Property(e => e.RegionName).HasMaxLength(50);

        entity.Property(e => e.TmStartCall)
                  .HasMaxLength(8)
                  .IsUnicode(false)
                  .HasColumnName("tmStartCall");

        entity.Property(e => e.TypHovoru)
                  .IsRequired()
                  .HasMaxLength(4)
                  .IsUnicode(false);

        entity.Property(e => e.UsrFirstName)
                  .HasMaxLength(50)
                  .HasColumnName("usrFirstName");

        entity.Property(e => e.UsrLastName)
                  .HasMaxLength(50)
                  .HasColumnName("usrLastName");
      });

      modelBuilder.Entity<WLikoincident>(entity =>
      {
        entity.HasNoKey();

        entity.ToView("wLIKOIncident");

        entity.Property(e => e.DtIncident)
                  .HasColumnType("datetime")
                  .HasColumnName("dtIncident");

        entity.Property(e => e.DtIncidentDate)
                  .HasColumnType("date")
                  .HasColumnName("dtIncidentDate");

        entity.Property(e => e.IncidentCategory).HasMaxLength(50);

        entity.Property(e => e.IncidentName).HasMaxLength(255);

        entity.Property(e => e.LikoincidentId).HasColumnName("LIKOIncidentId");

        entity.Property(e => e.Place).HasMaxLength(50);

        entity.Property(e => e.PokusPriprava).HasColumnName("Pokus_Priprava");

        entity.Property(e => e.RegionName).HasMaxLength(50);

        entity.Property(e => e.SubTypeIncidentEid).HasColumnName("SubTypeIncidentEID");

        entity.Property(e => e.Title).HasMaxLength(100);

        entity.Property(e => e.TmIncident)
                  .HasMaxLength(8)
                  .IsUnicode(false)
                  .HasColumnName("tmIncident");
      });

      modelBuilder.Entity<WLikointervence>(entity =>
      {
        entity.HasNoKey();

        entity.ToView("wLIKOIntervence");

        entity.Property(e => e.DateStartIntervence)
                  .HasColumnType("date")
                  .HasColumnName("dateStartIntervence");

        entity.Property(e => e.DtEndIntervence).HasColumnName("dtEndIntervence");

        entity.Property(e => e.DtStartCall).HasColumnName("dtStartCall");

        entity.Property(e => e.DtStartIntervence).HasColumnName("dtStartIntervence");

        entity.Property(e => e.InterventShortName).HasMaxLength(53);

        entity.Property(e => e.LikoincidentId).HasColumnName("LIKOIncidentId");

        entity.Property(e => e.LikointervenceId).HasColumnName("LIKOIntervenceId");

        entity.Property(e => e.LikointervenceIdmaster).HasColumnName("LIKOIntervenceIDMaster");

        entity.Property(e => e.RegionName).HasMaxLength(50);

        entity.Property(e => e.TimeStartIntervence)
                  .HasMaxLength(8)
                  .IsUnicode(false)
                  .HasColumnName("timeStartIntervence");

        entity.Property(e => e.UsrFirstName)
                  .HasMaxLength(50)
                  .HasColumnName("usrFirstName");

        entity.Property(e => e.UsrLastName)
                  .HasMaxLength(50)
                  .HasColumnName("usrLastName");
      });

      modelBuilder.Entity<WLikoparticipant>(entity =>
      {
        entity.HasNoKey();

        entity.ToView("wLIKOParticipant");

        entity.Property(e => e.CmbName)
                  .HasMaxLength(114)
                  .HasColumnName("cmbName");

        entity.Property(e => e.DruhIntervenceEid).HasColumnName("DruhIntervenceEID");

        entity.Property(e => e.DruhIntervenceText).HasMaxLength(50);

        entity.Property(e => e.DtEndIntervence).HasColumnName("dtEndIntervence");

        entity.Property(e => e.DtStartCall).HasColumnName("dtStartCall");

        entity.Property(e => e.DtStartIntervence).HasColumnName("dtStartIntervence");

        entity.Property(e => e.IntervenceNote).HasColumnName("intervenceNote");

        entity.Property(e => e.InterventShortName).HasMaxLength(53);

        entity.Property(e => e.IsAgreementBkb).HasColumnName("IsAgreementBKB");

        entity.Property(e => e.LikointervenceId).HasColumnName("LIKOIntervenceId");

        entity.Property(e => e.LikointervenceIdmaster).HasColumnName("LIKOIntervenceIDMaster");

        entity.Property(e => e.LikoparticipantId).HasColumnName("LIKOParticipantId");

        entity.Property(e => e.Organization).HasMaxLength(255);

        entity.Property(e => e.RegionName).HasMaxLength(50);

        entity.Property(e => e.SexEid).HasColumnName("SexEID");

        entity.Property(e => e.SexText).HasMaxLength(50);

        entity.Property(e => e.TypePartyEid).HasColumnName("TypePartyEID");

        entity.Property(e => e.TypePartyText).HasMaxLength(50);

        entity.Property(e => e.UsrFirstName)
                  .HasMaxLength(50)
                  .HasColumnName("usrFirstName");

        entity.Property(e => e.UsrLastName)
                  .HasMaxLength(50)
                  .HasColumnName("usrLastName");
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
