﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainStation.Data;

namespace TrainStation.Migrations.TrainStation
{
    [DbContext(typeof(TrainStationContext))]
    partial class TrainStationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrainStation.Data.AspNetRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedName" }, "RoleNameIndex")
                        .IsUnique()
                        .HasFilter("([NormalizedName] IS NOT NULL)");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("TrainStation.Data.AspNetRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetRoleClaims_RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("TrainStation.Data.AspNetUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedEmail" }, "EmailIndex");

                    b.HasIndex(new[] { "NormalizedUserName" }, "UserNameIndex")
                        .IsUnique()
                        .HasFilter("([NormalizedUserName] IS NOT NULL)");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TrainStation.Data.AspNetUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserClaims_UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("TrainStation.Data.AspNetUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserLogins_UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("TrainStation.Data.AspNetUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("TrainStation.Data.AspNetUserToken", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TrainStation.Models.Car", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Sitting")
                        .HasColumnType("int");

                    b.Property<int>("Standing")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("TrainStation.Models.Cars", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<int>("RideID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CarID");

                    b.HasIndex("RideID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("TrainStation.Models.Conductors", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConductorID")
                        .HasColumnType("int");

                    b.Property<int>("RideID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ConductorID");

                    b.HasIndex("RideID");

                    b.ToTable("Conductors");
                });

            modelBuilder.Entity("TrainStation.Models.Day", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Day");
                });

            modelBuilder.Entity("TrainStation.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PermissionID")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("PermissionID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("TrainStation.Models.Engine", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Engine");
                });

            modelBuilder.Entity("TrainStation.Models.Journey", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("BreakTimeOnStation")
                        .HasColumnType("time");

                    b.Property<int>("DayID")
                        .HasColumnType("int");

                    b.Property<int>("DestinationPlaceID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndingDateTime")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("FullTimeRide")
                        .HasColumnType("time");

                    b.Property<int>("RideID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartingDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StartingPlaceID")
                        .HasColumnType("int");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.Property<decimal>("TicketBasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("DayID");

                    b.HasIndex("DestinationPlaceID");

                    b.HasIndex("RideID");

                    b.HasIndex("StartingPlaceID");

                    b.HasIndex("StatusID");

                    b.ToTable("Journey");
                });

            modelBuilder.Entity("TrainStation.Models.Permission", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("TrainStation.Models.Place", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("TravelTime")
                        .HasColumnType("time");

                    b.HasKey("ID");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("TrainStation.Models.Ride", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DriverID")
                        .HasColumnType("int");

                    b.Property<int>("EngineID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DriverID");

                    b.HasIndex("EngineID");

                    b.ToTable("Ride");
                });

            modelBuilder.Entity("TrainStation.Models.Status", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("TrainStation.Models.Ticket", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<DateTime>("SoldDateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("SoldPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TypeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CarID");

                    b.HasIndex("TypeID");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("TrainStation.Models.Tickets", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JourneyID")
                        .HasColumnType("int");

                    b.Property<int>("TicketID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("JourneyID");

                    b.HasIndex("TicketID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TrainStation.Models.Type", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("TrainStation.Data.AspNetRoleClaim", b =>
                {
                    b.HasOne("TrainStation.Data.AspNetRole", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TrainStation.Data.AspNetUserClaim", b =>
                {
                    b.HasOne("TrainStation.Data.AspNetUser", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TrainStation.Data.AspNetUserLogin", b =>
                {
                    b.HasOne("TrainStation.Data.AspNetUser", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TrainStation.Data.AspNetUserRole", b =>
                {
                    b.HasOne("TrainStation.Data.AspNetRole", "Role")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainStation.Data.AspNetUser", "User")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TrainStation.Data.AspNetUserToken", b =>
                {
                    b.HasOne("TrainStation.Data.AspNetUser", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TrainStation.Models.Cars", b =>
                {
                    b.HasOne("TrainStation.Models.Car", "Car")
                        .WithMany("CarsList")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TrainStation.Models.Ride", "Ride")
                        .WithMany("CarsList")
                        .HasForeignKey("RideID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Ride");
                });

            modelBuilder.Entity("TrainStation.Models.Conductors", b =>
                {
                    b.HasOne("TrainStation.Models.Employee", "Conductor")
                        .WithMany("ConductorsList")
                        .HasForeignKey("ConductorID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TrainStation.Models.Ride", "Ride")
                        .WithMany("ConductorsList")
                        .HasForeignKey("RideID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Conductor");

                    b.Navigation("Ride");
                });

            modelBuilder.Entity("TrainStation.Models.Employee", b =>
                {
                    b.HasOne("TrainStation.Models.Permission", "Type")
                        .WithMany("Employees")
                        .HasForeignKey("PermissionID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("TrainStation.Models.Journey", b =>
                {
                    b.HasOne("TrainStation.Models.Day", "Day")
                        .WithMany("Journeys")
                        .HasForeignKey("DayID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TrainStation.Models.Place", "DestinationPlace")
                        .WithMany("JourneysDestinations")
                        .HasForeignKey("DestinationPlaceID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TrainStation.Models.Ride", "Ride")
                        .WithMany("Journeys")
                        .HasForeignKey("RideID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TrainStation.Models.Place", "StartingPlace")
                        .WithMany("JourneysStarting")
                        .HasForeignKey("StartingPlaceID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TrainStation.Models.Status", "Status")
                        .WithMany("Journeys")
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Day");

                    b.Navigation("DestinationPlace");

                    b.Navigation("Ride");

                    b.Navigation("StartingPlace");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("TrainStation.Models.Ride", b =>
                {
                    b.HasOne("TrainStation.Models.Employee", "Driver")
                        .WithMany("Rides")
                        .HasForeignKey("DriverID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TrainStation.Models.Engine", "Engine")
                        .WithMany("Rides")
                        .HasForeignKey("EngineID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Engine");
                });

            modelBuilder.Entity("TrainStation.Models.Ticket", b =>
                {
                    b.HasOne("TrainStation.Models.Car", "Car")
                        .WithMany("Tickets")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TrainStation.Models.Type", "Type")
                        .WithMany("Tickets")
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("TrainStation.Models.Tickets", b =>
                {
                    b.HasOne("TrainStation.Models.Journey", "Journey")
                        .WithMany("TicketsList")
                        .HasForeignKey("JourneyID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TrainStation.Models.Ticket", "Ticket")
                        .WithMany("TicketsList")
                        .HasForeignKey("TicketID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Journey");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("TrainStation.Data.AspNetRole", b =>
                {
                    b.Navigation("AspNetRoleClaims");

                    b.Navigation("AspNetUserRoles");
                });

            modelBuilder.Entity("TrainStation.Data.AspNetUser", b =>
                {
                    b.Navigation("AspNetUserClaims");

                    b.Navigation("AspNetUserLogins");

                    b.Navigation("AspNetUserRoles");

                    b.Navigation("AspNetUserTokens");
                });

            modelBuilder.Entity("TrainStation.Models.Car", b =>
                {
                    b.Navigation("CarsList");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("TrainStation.Models.Day", b =>
                {
                    b.Navigation("Journeys");
                });

            modelBuilder.Entity("TrainStation.Models.Employee", b =>
                {
                    b.Navigation("ConductorsList");

                    b.Navigation("Rides");
                });

            modelBuilder.Entity("TrainStation.Models.Engine", b =>
                {
                    b.Navigation("Rides");
                });

            modelBuilder.Entity("TrainStation.Models.Journey", b =>
                {
                    b.Navigation("TicketsList");
                });

            modelBuilder.Entity("TrainStation.Models.Permission", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("TrainStation.Models.Place", b =>
                {
                    b.Navigation("JourneysDestinations");

                    b.Navigation("JourneysStarting");
                });

            modelBuilder.Entity("TrainStation.Models.Ride", b =>
                {
                    b.Navigation("CarsList");

                    b.Navigation("ConductorsList");

                    b.Navigation("Journeys");
                });

            modelBuilder.Entity("TrainStation.Models.Status", b =>
                {
                    b.Navigation("Journeys");
                });

            modelBuilder.Entity("TrainStation.Models.Ticket", b =>
                {
                    b.Navigation("TicketsList");
                });

            modelBuilder.Entity("TrainStation.Models.Type", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
