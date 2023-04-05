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
        public virtual DbSet<DimDateTime> DimDateTimes { get; set; }
        public virtual DbSet<EAge> EAges { get; set; }
        public virtual DbSet<ECallType> ECallTypes { get; set; }
        public virtual DbSet<EClientCurrentStatus> EClientCurrentStatuses { get; set; }
        public virtual DbSet<EClientFrom> EClientFroms { get; set; }
        public virtual DbSet<EContactTopic> EContactTopics { get; set; }
        public virtual DbSet<EContactType> EContactTypes { get; set; }
        public virtual DbSet<EDruhIntervence> EDruhIntervences { get; set; }
        public virtual DbSet<EEndOfSpeech> EEndOfSpeeches { get; set; }
        public virtual DbSet<EGrouping> EGroupings { get; set; }
        public virtual DbSet<ENick> ENicks { get; set; }
        public virtual DbSet<ESex> ESexes { get; set; }
        public virtual DbSet<ESubClientCurrentStatus> ESubClientCurrentStatuses { get; set; }
        public virtual DbSet<ESubContactTopic> ESubContactTopics { get; set; }
        public virtual DbSet<ESubEndOfSpeech> ESubEndOfSpeeches { get; set; }
        public virtual DbSet<ESubTypeIncident> ESubTypeIncidents { get; set; }
        public virtual DbSet<ETypeIncident> ETypeIncidents { get; set; }
        public virtual DbSet<ETypeParty> ETypeParties { get; set; }
        public virtual DbSet<ETypeService> ETypeServices { get; set; }
        public virtual DbSet<Intervent> Intervents { get; set; }
        public virtual DbSet<Likoincident> Likoincidents { get; set; }
        public virtual DbSet<Likointervence> Likointervences { get; set; }
        public virtual DbSet<Likoparticipant> Likoparticipants { get; set; }
        public virtual DbSet<LoginAccess> LoginAccesses { get; set; }
        public virtual DbSet<LoginAccessUser> LoginAccessUsers { get; set; }
        public virtual DbSet<LoginUser> LoginUsers { get; set; }
        public virtual DbSet<Lpk> Lpks { get; set; }
        public virtual DbSet<LpkclientCurrentStatus> LpkclientCurrentStatuses { get; set; }
        public virtual DbSet<LpksubContactTopic> LpksubContactTopics { get; set; }
        public virtual DbSet<LpksubEndOfSpeech> LpksubEndOfSpeeches { get; set; }
        public virtual DbSet<MainEventLog> MainEventLogs { get; set; }
        public virtual DbSet<MainSetting> MainSettings { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<UserColumn> UserColumns { get; set; }
        public virtual DbSet<UserSetting> UserSettings { get; set; }
        public virtual DbSet<WCall> WCalls { get; set; }
        public virtual DbSet<WIntervent> WIntervents { get; set; }
        public virtual DbSet<WLikoall> WLikoalls { get; set; }
        public virtual DbSet<WLikocall> WLikocalls { get; set; }
        public virtual DbSet<WLikoincident> WLikoincidents { get; set; }
        public virtual DbSet<WLikointervence> WLikointervences { get; set; }
        public virtual DbSet<WLikoparticipant> WLikoparticipants { get; set; }
        public virtual DbSet<WLpk> WLpks { get; set; }
        public virtual DbSet<WMainEventLog> WMainEventLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=Evitel2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Czech_CI_AS");

            modelBuilder.Entity<Call>(entity =>
            {
                entity.Property(e => e.CallType).HasColumnName("callType");

                entity.Property(e => e.DtEndCall).HasColumnName("dtEndCall");

                entity.Property(e => e.DtStartCall).HasColumnName("dtStartCall");

                entity.HasOne(d => d.LoginUser)
                    .WithMany(p => p.Calls)
                    .HasForeignKey(d => d.LoginUserId)
                    .HasConstraintName("FK_Calls_LoginUsers");
            });

            modelBuilder.Entity<DimDateTime>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__dimDateT__D9DE21FC35794280");

                entity.ToTable("dimDateTime");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Day)
                    .HasColumnName("day")
                    .HasComputedColumnSql("(datepart(day,[date]))", false);

                entity.Property(e => e.DayOfWeek).HasComputedColumnSql("(datepart(weekday,[date]))", false);

                entity.Property(e => e.FirstOfMonth)
                    .HasColumnType("date")
                    .HasComputedColumnSql("(CONVERT([date],dateadd(month,datediff(month,(0),[date]),(0)),(0)))", false);

                entity.Property(e => e.FirstOfYear)
                    .HasColumnType("date")
                    .HasComputedColumnSql("(CONVERT([date],dateadd(year,datediff(year,(0),[date]),(0)),(0)))", false);

                entity.Property(e => e.HalfOfYear)
                    .HasColumnName("halfOfYear")
                    .HasComputedColumnSql("(case when datepart(weekday,[date])>(2) then (2) else (1) end)", false);

                entity.Property(e => e.Isoweek)
                    .HasColumnName("ISOweek")
                    .HasComputedColumnSql("(datepart(iso_week,[date]))", false);

                entity.Property(e => e.Month)
                    .HasColumnName("month")
                    .HasComputedColumnSql("(datepart(month,[date]))", false);

                entity.Property(e => e.MonthName)
                    .HasMaxLength(30)
                    .HasComputedColumnSql("(datename(month,[date]))", false);

                entity.Property(e => e.Quarter)
                    .HasColumnName("quarter")
                    .HasComputedColumnSql("(datepart(quarter,[date]))", false);

                entity.Property(e => e.Style101)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([char](10),[date],(101)))", false)
                    .IsFixedLength();

                entity.Property(e => e.Style112)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([char](8),[date],(112)))", false)
                    .IsFixedLength();

                entity.Property(e => e.Week)
                    .HasColumnName("week")
                    .HasComputedColumnSql("(datepart(week,[date]))", false);

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasComputedColumnSql("(datepart(year,[date]))", false);
            });

            modelBuilder.Entity<EAge>(entity =>
            {
                entity.HasKey(e => e.AgeId);

                entity.ToTable("eAge");

                entity.Property(e => e.DtDeleted)
                    .HasColumnType("datetime")
                    .HasColumnName("dtDeleted");

                entity.Property(e => e.Text).HasMaxLength(50);
            });

            modelBuilder.Entity<ECallType>(entity =>
            {
                entity.HasKey(e => e.CallTypeId);

                entity.ToTable("eCallType");

                entity.Property(e => e.CallTypeId).HasColumnName("callTypeId");

                entity.Property(e => e.DtDeleted)
                    .HasColumnType("datetime")
                    .HasColumnName("dtDeleted");

                entity.Property(e => e.Text).HasMaxLength(50);
            });

            modelBuilder.Entity<EClientCurrentStatus>(entity =>
            {
                entity.HasKey(e => e.ClientCurrentStatusId);

                entity.ToTable("eClientCurrentStatus");

                entity.Property(e => e.DtDeleted)
                    .HasColumnType("datetime")
                    .HasColumnName("dtDeleted");

                entity.Property(e => e.Text).HasMaxLength(50);
            });

            modelBuilder.Entity<EClientFrom>(entity =>
            {
                entity.HasKey(e => e.ClientFromId);

                entity.ToTable("eClientFrom");

                entity.Property(e => e.DtDeleted)
                    .HasColumnType("datetime")
                    .HasColumnName("dtDeleted");

                entity.Property(e => e.Text).HasMaxLength(50);
            });

            modelBuilder.Entity<EContactTopic>(entity =>
            {
                entity.HasKey(e => e.ContactTopicId)
                    .HasName("PK_eContactTopis");

                entity.ToTable("eContactTopic");

                entity.Property(e => e.DtDeleted)
                    .HasColumnType("datetime")
                    .HasColumnName("dtDeleted");

                entity.Property(e => e.Text).HasMaxLength(50);
            });

            modelBuilder.Entity<EContactType>(entity =>
            {
                entity.HasKey(e => e.ContactTypeId);

                entity.ToTable("eContactType");

                entity.Property(e => e.DtDeleted)
                    .HasColumnType("datetime")
                    .HasColumnName("dtDeleted");

                entity.Property(e => e.Text).HasMaxLength(50);
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

            modelBuilder.Entity<EEndOfSpeech>(entity =>
            {
                entity.HasKey(e => e.EndOfSpeechId);

                entity.ToTable("eEndOfSpeech");

                entity.Property(e => e.DtDeleted)
                    .HasColumnType("datetime")
                    .HasColumnName("dtDeleted");

                entity.Property(e => e.Text).HasMaxLength(50);
            });

            modelBuilder.Entity<EGrouping>(entity =>
            {
                entity.HasKey(e => e.GroupingId);

                entity.ToTable("eGrouping");

                entity.Property(e => e.GroupingId).HasColumnName("groupingId");

                entity.Property(e => e.DtDeleted)
                    .HasColumnType("datetime")
                    .HasColumnName("dtDeleted");

                entity.Property(e => e.Text).HasMaxLength(50);

                entity.Property(e => e.Value).HasMaxLength(50);
            });

            modelBuilder.Entity<ENick>(entity =>
            {
                entity.HasKey(e => e.NickId);

                entity.ToTable("eNick");

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

            modelBuilder.Entity<ESubClientCurrentStatus>(entity =>
            {
                entity.HasKey(e => e.SubClientCurrentStatusId);

                entity.ToTable("eSubClientCurrentStatus");

                entity.Property(e => e.DtDeleted)
                    .HasColumnType("datetime")
                    .HasColumnName("dtDeleted");

                entity.Property(e => e.Text).HasMaxLength(255);

                entity.HasOne(d => d.ClientCurrentStatus)
                    .WithMany(p => p.ESubClientCurrentStatuses)
                    .HasForeignKey(d => d.ClientCurrentStatusId)
                    .HasConstraintName("FK_eSubClientCurrentStatus_eClientCurrentStatus");
            });

            modelBuilder.Entity<ESubContactTopic>(entity =>
            {
                entity.HasKey(e => e.SubContactTopicId);

                entity.ToTable("eSubContactTopic");

                entity.Property(e => e.DtDeleted)
                    .HasColumnType("datetime")
                    .HasColumnName("dtDeleted");

                entity.Property(e => e.Text).HasMaxLength(255);

                entity.HasOne(d => d.ContactTopic)
                    .WithMany(p => p.ESubContactTopics)
                    .HasForeignKey(d => d.ContactTopicId)
                    .HasConstraintName("FK_eSubContactTopic_eContactTopic");
            });

            modelBuilder.Entity<ESubEndOfSpeech>(entity =>
            {
                entity.HasKey(e => e.SubEndOfSpeechId);

                entity.ToTable("eSubEndOfSpeech");

                entity.Property(e => e.DtDeleted)
                    .HasColumnType("datetime")
                    .HasColumnName("dtDeleted");

                entity.Property(e => e.Text).HasMaxLength(255);

                entity.HasOne(d => d.EndOfSpeech)
                    .WithMany(p => p.ESubEndOfSpeeches)
                    .HasForeignKey(d => d.EndOfSpeechId)
                    .HasConstraintName("FK_eSubEndOfSpeech_eEndOfSpeech");
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

            modelBuilder.Entity<ETypeService>(entity =>
            {
                entity.HasKey(e => e.TypeServiceId);

                entity.ToTable("eTypeService");

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LIKOParticipant_LIKOIntervence");

                entity.HasOne(d => d.SexE)
                    .WithMany(p => p.Likoparticipants)
                    .HasForeignKey(d => d.SexEid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LIKOParticipant_eSex");

                entity.HasOne(d => d.TypePartyE)
                    .WithMany(p => p.Likoparticipants)
                    .HasForeignKey(d => d.TypePartyEid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
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

            modelBuilder.Entity<Lpk>(entity =>
            {
                entity.ToTable("LPK");

                entity.Property(e => e.Lpkid).HasColumnName("LPKId");

                entity.Property(e => e.AgeEid).HasColumnName("AgeEID");

                entity.Property(e => e.ClientFromEid).HasColumnName("ClientFromEID");

                entity.Property(e => e.ContactTopicEid).HasColumnName("ContactTopicEID");

                entity.Property(e => e.ContactTypeEid).HasColumnName("ContactTypeEID");

                entity.Property(e => e.Nick).HasMaxLength(50);

                entity.Property(e => e.SexEid).HasColumnName("SexEID");

                entity.Property(e => e.TypeServiceEid).HasColumnName("TypeServiceEID");

                entity.HasOne(d => d.AgeE)
                    .WithMany(p => p.Lpks)
                    .HasForeignKey(d => d.AgeEid)
                    .HasConstraintName("FK_LPK_eAge");

                entity.HasOne(d => d.Call)
                    .WithMany(p => p.Lpks)
                    .HasForeignKey(d => d.CallId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LPK_Calls");

                entity.HasOne(d => d.ClientFromE)
                    .WithMany(p => p.Lpks)
                    .HasForeignKey(d => d.ClientFromEid)
                    .HasConstraintName("FK_LPK_eClientFrom");

                entity.HasOne(d => d.ContactTypeE)
                    .WithMany(p => p.Lpks)
                    .HasForeignKey(d => d.ContactTypeEid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LPK_eContactType");

                entity.HasOne(d => d.SexE)
                    .WithMany(p => p.Lpks)
                    .HasForeignKey(d => d.SexEid)
                    .HasConstraintName("FK_LPK_eSex");

                entity.HasOne(d => d.TypeServiceE)
                    .WithMany(p => p.Lpks)
                    .HasForeignKey(d => d.TypeServiceEid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LPK_eTypeService");
            });

            modelBuilder.Entity<LpkclientCurrentStatus>(entity =>
            {
                entity.HasKey(e => e.LpksubClientCurentStatus);

                entity.ToTable("LPKClientCurrentStatus");

                entity.Property(e => e.LpksubClientCurentStatus).HasColumnName("LPKSubClientCurentStatus");

                entity.Property(e => e.Lpkid).HasColumnName("LPKId");

                entity.Property(e => e.LpksubClientCurrentStatusEid).HasColumnName("LPKSubClientCurrentStatusEID");

                entity.HasOne(d => d.Lpk)
                    .WithMany(p => p.LpkclientCurrentStatuses)
                    .HasForeignKey(d => d.Lpkid)
                    .HasConstraintName("FK_LPKClientCurrentStatus_LPK");

                entity.HasOne(d => d.LpksubClientCurrentStatusE)
                    .WithMany(p => p.LpkclientCurrentStatuses)
                    .HasForeignKey(d => d.LpksubClientCurrentStatusEid)
                    .HasConstraintName("FK_LPKClientCurrentStatus_eSubClientCurrentStatus");
            });

            modelBuilder.Entity<LpksubContactTopic>(entity =>
            {
                entity.ToTable("LPKSubContactTopic");

                entity.Property(e => e.LpksubContactTopicId).HasColumnName("LPKSubContactTopicID");

                entity.Property(e => e.Lpkid).HasColumnName("LPKId");

                entity.Property(e => e.LpksubContactTopicEid).HasColumnName("LPKSubContactTopicEID");

                entity.HasOne(d => d.Lpk)
                    .WithMany(p => p.LpksubContactTopics)
                    .HasForeignKey(d => d.Lpkid)
                    .HasConstraintName("FK_LPKSubContactTopic_LPK");

                entity.HasOne(d => d.LpksubContactTopicE)
                    .WithMany(p => p.LpksubContactTopics)
                    .HasForeignKey(d => d.LpksubContactTopicEid)
                    .HasConstraintName("FK_LPKSubContactTopic_eSubContactTopic");
            });

            modelBuilder.Entity<LpksubEndOfSpeech>(entity =>
            {
                entity.ToTable("LPKSubEndOfSpeech");

                entity.Property(e => e.LpksubEndOfSpeechId).HasColumnName("LPKSubEndOfSpeechID");

                entity.Property(e => e.Lpkid).HasColumnName("LPKId");

                entity.Property(e => e.LpksubEndOfSpeechEid).HasColumnName("LPKSubEndOfSpeechEID");

                entity.HasOne(d => d.Lpk)
                    .WithMany(p => p.LpksubEndOfSpeeches)
                    .HasForeignKey(d => d.Lpkid)
                    .HasConstraintName("FK_LPKSubEndOfSpeech_LPK");

                entity.HasOne(d => d.LpksubEndOfSpeechE)
                    .WithMany(p => p.LpksubEndOfSpeeches)
                    .HasForeignKey(d => d.LpksubEndOfSpeechEid)
                    .HasConstraintName("FK_LPKSubEndOfSpeech_eSubEndOfSpeech");
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

            modelBuilder.Entity<WCall>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("wCalls");

                entity.Property(e => e.CallType).HasMaxLength(50);

                entity.Property(e => e.CallTypeId).HasColumnName("callTypeId");

                entity.Property(e => e.ContactType).HasMaxLength(50);

                entity.Property(e => e.DtCall)
                    .HasColumnType("date")
                    .HasColumnName("dtCall");

                entity.Property(e => e.DtEndCall).HasColumnName("dtEndCall");

                entity.Property(e => e.DtStartCall).HasColumnName("dtStartCall");

                entity.Property(e => e.InterventShortName).HasMaxLength(53);

                entity.Property(e => e.LikointervenceId).HasColumnName("LIKOIntervenceId");

                entity.Property(e => e.Lpkid).HasColumnName("LPKId");

                entity.Property(e => e.Nick).HasMaxLength(50);

                entity.Property(e => e.RegionName).HasMaxLength(50);

                entity.Property(e => e.TmDuration)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("tmDuration");

                entity.Property(e => e.TmEndCall)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("tmEndCall");

                entity.Property(e => e.TmStartCall)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("tmStartCall");

                entity.Property(e => e.UsrFirstName)
                    .HasMaxLength(50)
                    .HasColumnName("usrFirstName");

                entity.Property(e => e.UsrLastName)
                    .HasMaxLength(50)
                    .HasColumnName("usrLastName");
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

                entity.Property(e => e.DruhIntervence).HasMaxLength(50);

                entity.Property(e => e.DruhUdalosti)
                    .HasMaxLength(255)
                    .HasColumnName("Druh_Udalosti");

                entity.Property(e => e.DtCall)
                    .HasColumnType("date")
                    .HasColumnName("dtCall");

                entity.Property(e => e.DtEndIntervence).HasColumnName("dtEndIntervence");

                entity.Property(e => e.DtIncident)
                    .HasColumnType("datetime")
                    .HasColumnName("dtIncident");

                entity.Property(e => e.DtIntervEnd)
                    .HasColumnType("date")
                    .HasColumnName("dtIntervEnd");

                entity.Property(e => e.DtIntervStart)
                    .HasColumnType("date")
                    .HasColumnName("dtIntervStart");

                entity.Property(e => e.DtStartCall).HasColumnName("dtStartCall");

                entity.Property(e => e.DtStartIntervence).HasColumnName("dtStartIntervence");

                entity.Property(e => e.DtUdalost)
                    .HasColumnType("date")
                    .HasColumnName("dtUdalost");

                entity.Property(e => e.IntervPoradi).HasColumnName("Interv_Poradi");

                entity.Property(e => e.IntervenceId).HasColumnName("Intervence_Id");

                entity.Property(e => e.Intervent2Name).HasMaxLength(53);

                entity.Property(e => e.InterventName).HasMaxLength(53);

                entity.Property(e => e.IntrvId).HasColumnName("Intrv_Id");

                entity.Property(e => e.IntrvNote).HasColumnName("Intrv_Note");

                entity.Property(e => e.IsAgreementBkb).HasColumnName("IsAgreementBKB");

                entity.Property(e => e.KategorieUdalosti)
                    .HasMaxLength(50)
                    .HasColumnName("Kategorie_Udalosti");

                entity.Property(e => e.LikointervenceId).HasColumnName("LIKOIntervenceId");

                entity.Property(e => e.Organization).HasMaxLength(255);

                entity.Property(e => e.RegionName).HasMaxLength(50);

                entity.Property(e => e.SexText).HasMaxLength(50);

                entity.Property(e => e.TmCall)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("tmCall");

                entity.Property(e => e.TmIntervDuration)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("tmIntervDuration");

                entity.Property(e => e.TmIntervEnd)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("tmIntervEnd");

                entity.Property(e => e.TmIntervStart)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("tmIntervStart");

                entity.Property(e => e.TmUdalost)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("tmUdalost");

                entity.Property(e => e.TypePartyText).HasMaxLength(50);

                entity.Property(e => e.UdalostId).HasColumnName("Udalost_Id");

                entity.Property(e => e.UdalostMisto)
                    .HasMaxLength(50)
                    .HasColumnName("Udalost_Misto");

                entity.Property(e => e.UdalostMonth).HasColumnName("Udalost_Month");

                entity.Property(e => e.UdalostNote).HasColumnName("Udalost_Note");

                entity.Property(e => e.UdalostRegion)
                    .HasMaxLength(50)
                    .HasColumnName("Udalost_Region");

                entity.Property(e => e.UdalostYear).HasColumnName("Udalost_Year");

                entity.Property(e => e.UserFirstName).HasMaxLength(50);

                entity.Property(e => e.UserLastName).HasMaxLength(50);

                entity.Property(e => e.Volajici).HasMaxLength(53);

                entity.Property(e => e.VolajiciKraj)
                    .HasMaxLength(50)
                    .HasColumnName("Volajici_Kraj");
            });

            modelBuilder.Entity<WLikocall>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("wLIKOCalls");

                entity.Property(e => e.CallType).HasMaxLength(50);

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

                entity.Property(e => e.DruhUdalosti)
                    .HasMaxLength(255)
                    .HasColumnName("Druh_Udalosti");

                entity.Property(e => e.DtCall)
                    .HasColumnType("date")
                    .HasColumnName("dtCall");

                entity.Property(e => e.DtIncident)
                    .HasColumnType("datetime")
                    .HasColumnName("dtIncident");

                entity.Property(e => e.DtStartCall).HasColumnName("dtStartCall");

                entity.Property(e => e.DtUdalost)
                    .HasColumnType("date")
                    .HasColumnName("dtUdalost");

                entity.Property(e => e.KategorieUdalosti)
                    .HasMaxLength(50)
                    .HasColumnName("Kategorie_Udalosti");

                entity.Property(e => e.LikoincidentId).HasColumnName("LIKOIncidentId");

                entity.Property(e => e.PokusPriprava).HasColumnName("Pokus_Priprava");

                entity.Property(e => e.TmCall)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("tmCall");

                entity.Property(e => e.TmUdalost)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("tmUdalost");

                entity.Property(e => e.UdalostMisto)
                    .HasMaxLength(50)
                    .HasColumnName("Udalost_Misto");

                entity.Property(e => e.UdalostNote).HasColumnName("Udalost_Note");

                entity.Property(e => e.UdalostRegion)
                    .HasMaxLength(50)
                    .HasColumnName("Udalost_Region");

                entity.Property(e => e.UserFirstName).HasMaxLength(50);

                entity.Property(e => e.UserLastName).HasMaxLength(50);

                entity.Property(e => e.Volajici).HasMaxLength(53);

                entity.Property(e => e.VolajiciKraj)
                    .HasMaxLength(50)
                    .HasColumnName("Volajici_Kraj");
            });

            modelBuilder.Entity<WLikointervence>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("wLIKOIntervence");

                entity.Property(e => e.DruhUdalosti)
                    .HasMaxLength(255)
                    .HasColumnName("Druh_Udalosti");

                entity.Property(e => e.DtCall)
                    .HasColumnType("date")
                    .HasColumnName("dtCall");

                entity.Property(e => e.DtEndIntervence).HasColumnName("dtEndIntervence");

                entity.Property(e => e.DtIncident)
                    .HasColumnType("datetime")
                    .HasColumnName("dtIncident");

                entity.Property(e => e.DtIntervEnd)
                    .HasColumnType("date")
                    .HasColumnName("dtIntervEnd");

                entity.Property(e => e.DtIntervStart)
                    .HasColumnType("date")
                    .HasColumnName("dtIntervStart");

                entity.Property(e => e.DtStartCall).HasColumnName("dtStartCall");

                entity.Property(e => e.DtStartIntervence).HasColumnName("dtStartIntervence");

                entity.Property(e => e.DtUdalost)
                    .HasColumnType("date")
                    .HasColumnName("dtUdalost");

                entity.Property(e => e.IntervPoradi).HasColumnName("Interv_Poradi");

                entity.Property(e => e.IntrvId).HasColumnName("Intrv_Id");

                entity.Property(e => e.IntrvNote).HasColumnName("Intrv_Note");

                entity.Property(e => e.KategorieUdalosti)
                    .HasMaxLength(50)
                    .HasColumnName("Kategorie_Udalosti");

                entity.Property(e => e.LikoincidentId).HasColumnName("LIKOIncidentId");

                entity.Property(e => e.LikointervenceId).HasColumnName("LIKOIntervenceId");

                entity.Property(e => e.PokusPriprava).HasColumnName("Pokus_Priprava");

                entity.Property(e => e.TmCall)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("tmCall");

                entity.Property(e => e.TmIntervDuration)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("tmIntervDuration");

                entity.Property(e => e.TmIntervEnd)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("tmIntervEnd");

                entity.Property(e => e.TmIntervStart)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("tmIntervStart");

                entity.Property(e => e.TmUdalost)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("tmUdalost");

                entity.Property(e => e.UdalostMisto)
                    .HasMaxLength(50)
                    .HasColumnName("Udalost_Misto");

                entity.Property(e => e.UdalostNote).HasColumnName("Udalost_Note");

                entity.Property(e => e.UdalostRegion)
                    .HasMaxLength(50)
                    .HasColumnName("Udalost_Region");

                entity.Property(e => e.UserFirstName).HasMaxLength(50);

                entity.Property(e => e.UserLastName).HasMaxLength(50);

                entity.Property(e => e.Volajici).HasMaxLength(53);

                entity.Property(e => e.VolajiciKraj)
                    .HasMaxLength(50)
                    .HasColumnName("Volajici_Kraj");
            });

            modelBuilder.Entity<WLikoparticipant>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("wLIKOParticipant");

                entity.Property(e => e.DruhIntervenceEid).HasColumnName("DruhIntervenceEID");

                entity.Property(e => e.DruhIntervenceText).HasMaxLength(50);

                entity.Property(e => e.DtEndIntervence).HasColumnName("dtEndIntervence");

                entity.Property(e => e.DtIntervStart)
                    .HasColumnType("date")
                    .HasColumnName("dtIntervStart");

                entity.Property(e => e.DtStartCall).HasColumnName("dtStartCall");

                entity.Property(e => e.DtStartIntervence).HasColumnName("dtStartIntervence");

                entity.Property(e => e.IntervPoradi).HasColumnName("Interv_Poradi");

                entity.Property(e => e.IntervenceNote).HasColumnName("intervenceNote");

                entity.Property(e => e.InterventName).HasMaxLength(53);

                entity.Property(e => e.InterventName2).HasMaxLength(53);

                entity.Property(e => e.IsAgreementBkb).HasColumnName("IsAgreementBKB");

                entity.Property(e => e.LikointervenceId).HasColumnName("LIKOIntervenceId");

                entity.Property(e => e.LikoparticipantId).HasColumnName("LIKOParticipantId");

                entity.Property(e => e.Organization).HasMaxLength(255);

                entity.Property(e => e.SexEid).HasColumnName("SexEID");

                entity.Property(e => e.SexText).HasMaxLength(50);

                entity.Property(e => e.TmIntervStart)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("tmIntervStart");

                entity.Property(e => e.TypePartyEid).HasColumnName("TypePartyEID");

                entity.Property(e => e.TypePartyText).HasMaxLength(50);

                entity.Property(e => e.UdalostRegion)
                    .HasMaxLength(50)
                    .HasColumnName("Udalost_Region");

                entity.Property(e => e.UserFirstName).HasMaxLength(50);

                entity.Property(e => e.UserLastName).HasMaxLength(50);
            });

            modelBuilder.Entity<WLpk>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("wLPK");

                entity.Property(e => e.Age).HasMaxLength(50);

                entity.Property(e => e.AgeEid).HasColumnName("AgeEID");

                entity.Property(e => e.CallMonth).HasColumnName("call_Month");

                entity.Property(e => e.CallType).HasMaxLength(50);

                entity.Property(e => e.CallYear).HasColumnName("call_Year");

                entity.Property(e => e.ClientCurrentStatus).HasMaxLength(4000);

                entity.Property(e => e.ClientFrom).HasMaxLength(50);

                entity.Property(e => e.ClientFromEid).HasColumnName("ClientFromEID");

                entity.Property(e => e.ContactTopic).HasMaxLength(4000);

                entity.Property(e => e.ContactType).HasMaxLength(50);

                entity.Property(e => e.ContactTypeEid).HasColumnName("ContactTypeEID");

                entity.Property(e => e.DtCall)
                    .HasColumnType("date")
                    .HasColumnName("dtCall");

                entity.Property(e => e.DtEndCall).HasColumnName("dtEndCall");

                entity.Property(e => e.DtStartCall).HasColumnName("dtStartCall");

                entity.Property(e => e.EndOfSpeech).HasMaxLength(4000);

                entity.Property(e => e.Lpkid).HasColumnName("LPKId");

                entity.Property(e => e.Nick).HasMaxLength(50);

                entity.Property(e => e.Sex).HasMaxLength(50);

                entity.Property(e => e.SexEid).HasColumnName("SexEID");

                entity.Property(e => e.TmDuration)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("tmDuration");

                entity.Property(e => e.TmEndCall)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("tmEndCall");

                entity.Property(e => e.TmStartCall)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("tmStartCall");

                entity.Property(e => e.TypeService).HasMaxLength(50);

                entity.Property(e => e.TypeServiceEid).HasColumnName("TypeServiceEID");

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
