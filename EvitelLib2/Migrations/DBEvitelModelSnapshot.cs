﻿// <auto-generated />
using System;
using EvitelLib2.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EvitelLib2.Migrations
{
    [DbContext(typeof(DBEvitel))]
    partial class DBEvitelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EvitelLib2.LoginAccess", b =>
                {
                    b.Property<int>("LoginAccessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("LoginAccessId");

                    b.ToTable("LoginAccesses");
                });

            modelBuilder.Entity("EvitelLib2.LoginAccessUser", b =>
                {
                    b.Property<int>("LoginAccessUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LoginAccessId")
                        .HasColumnType("int");

                    b.Property<int>("LoginUserId")
                        .HasColumnType("int");

                    b.HasKey("LoginAccessUserId");

                    b.HasIndex("LoginUserId");

                    b.ToTable("LoginAccessUsers");
                });

            modelBuilder.Entity("EvitelLib2.LoginUser", b =>
                {
                    b.Property<int>("LoginUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LoginName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LoginPassword")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("LoginUserId");

                    b.ToTable("LoginUsers");
                });

            modelBuilder.Entity("EvitelLib2.MainEventLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LoginUserId")
                        .HasColumnType("int");

                    b.Property<string>("Program")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dtCreate")
                        .HasColumnType("datetime2");

                    b.Property<int>("eventCode")
                        .HasColumnType("int");

                    b.Property<int>("eventSubCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MainEventLogs");
                });

            modelBuilder.Entity("EvitelLib2.MainSetting", b =>
                {
                    b.Property<int>("MainSettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("dValue")
                        .HasColumnType("datetime2");

                    b.Property<int?>("iValue")
                        .HasColumnType("int");

                    b.Property<string>("sValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MainSettingId");

                    b.ToTable("MainSettings");
                });

            modelBuilder.Entity("EvitelLib2.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DescriptionType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DescriptionValue")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("StateType")
                        .HasColumnType("int");

                    b.Property<int>("StateValue")
                        .HasColumnType("int");

                    b.HasKey("StateId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("EvitelLib2.wMainEventLog", b =>
                {
                    b.Property<string>("CodeText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("LoginUserId")
                        .HasColumnType("int");

                    b.Property<string>("Program")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubCodeText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dtCreate")
                        .HasColumnType("datetime2");

                    b.Property<int>("eventCode")
                        .HasColumnType("int");

                    b.Property<int>("eventSubCode")
                        .HasColumnType("int");

                    b.ToView("wMainEventLogs");
                });

            modelBuilder.Entity("EvitelLib2.LoginAccessUser", b =>
                {
                    b.HasOne("EvitelLib2.LoginUser", null)
                        .WithMany("Access")
                        .HasForeignKey("LoginUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EvitelLib2.LoginUser", b =>
                {
                    b.Navigation("Access");
                });
#pragma warning restore 612, 618
        }
    }
}
