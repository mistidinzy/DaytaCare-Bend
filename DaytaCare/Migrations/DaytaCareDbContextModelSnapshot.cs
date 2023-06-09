﻿// <auto-generated />
using System;
using DaytaCare.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DaytaCare.Migrations
{
    [DbContext(typeof(DaytaCareDbContext))]
    partial class DaytaCareDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DaytaCare.Models.Amenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Parking"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Indoor Playground"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pay Scaling"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Shuttle Transportation"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Security"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Wheelchair Accessible"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Education"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Meal Plan"
                        });
                });

            modelBuilder.Entity("DaytaCare.Models.Daycare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Availability")
                        .HasColumnType("bit");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DaycareType")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LicenseNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Daycares");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Availability = true,
                            City = "Cedar Rapids",
                            Country = "United States",
                            DaycareType = 5,
                            Email = "KidsPoint@example.com",
                            LicenseNumber = 1,
                            Name = "KidsPoint Downtown Learning Center & Preschool",
                            Phone = "(319) 365-1636",
                            Price = 200m,
                            State = "Iowa",
                            StreetAddress = "318 5th St SE"
                        },
                        new
                        {
                            Id = 2,
                            Availability = true,
                            City = "Cedar Rapids",
                            Country = "United States",
                            DaycareType = 5,
                            Email = "TeddyBear@example.com",
                            LicenseNumber = 2,
                            Name = "Teddy Bear Child Care Center Inc",
                            Phone = "(319) 365-6534",
                            Price = 210m,
                            State = "Iowa",
                            StreetAddress = "2730 Bowling St SW"
                        },
                        new
                        {
                            Id = 3,
                            Availability = true,
                            City = "Iowa City",
                            Country = "United States",
                            DaycareType = 5,
                            Email = "iowa4cshometies@yahoo.com",
                            LicenseNumber = 3,
                            Name = "Home Ties Child Care Center",
                            Phone = "(319) 341-0050",
                            Price = 190m,
                            State = "Iowa",
                            StreetAddress = "405 Myrtle Ave"
                        },
                        new
                        {
                            Id = 4,
                            Availability = false,
                            City = "Iowa City",
                            Country = "United States",
                            DaycareType = 1,
                            Email = "alicesrainbowchildcarecenters@gmail.com",
                            LicenseNumber = 4,
                            Name = "Alice's Rainbow Child Care Center",
                            Phone = "(319) 354-1466",
                            Price = 225m,
                            State = "Iowa",
                            StreetAddress = "421 Melrose Ave"
                        },
                        new
                        {
                            Id = 5,
                            Availability = true,
                            City = "Marion",
                            Country = "United States",
                            DaycareType = 5,
                            Email = "KidsInc@example.com",
                            LicenseNumber = 5,
                            Name = "KIDS INC.",
                            Phone = "(319) 447-6316",
                            Price = 200m,
                            State = "Iowa",
                            StreetAddress = "1100 35th St"
                        });
                });

            modelBuilder.Entity("DaytaCare.Models.DaycareAmenity", b =>
                {
                    b.Property<int>("DaycareId")
                        .HasColumnType("int");

                    b.Property<int>("AmenityId")
                        .HasColumnType("int");

                    b.HasKey("DaycareId", "AmenityId");

                    b.HasIndex("AmenityId");

                    b.ToTable("DaycareAmenities");

                    b.HasData(
                        new
                        {
                            DaycareId = 1,
                            AmenityId = 1
                        },
                        new
                        {
                            DaycareId = 1,
                            AmenityId = 2
                        },
                        new
                        {
                            DaycareId = 2,
                            AmenityId = 3
                        },
                        new
                        {
                            DaycareId = 2,
                            AmenityId = 4
                        },
                        new
                        {
                            DaycareId = 3,
                            AmenityId = 5
                        },
                        new
                        {
                            DaycareId = 3,
                            AmenityId = 6
                        },
                        new
                        {
                            DaycareId = 4,
                            AmenityId = 7
                        },
                        new
                        {
                            DaycareId = 5,
                            AmenityId = 8
                        },
                        new
                        {
                            DaycareId = 5,
                            AmenityId = 5
                        },
                        new
                        {
                            DaycareId = 2,
                            AmenityId = 7
                        },
                        new
                        {
                            DaycareId = 5,
                            AmenityId = 6
                        });
                });

            modelBuilder.Entity("DaytaCare.Models.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FamilyBio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

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

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "Administrator",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "Parent",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "Parent",
                            NormalizedName = "PARENT"
                        },
                        new
                        {
                            Id = "Daycare Provider",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "Daycare Provider",
                            NormalizedName = "DAYCARE PROVIDER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
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

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
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

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DaytaCare.Models.Daycare", b =>
                {
                    b.HasOne("DaytaCare.Models.Identity.ApplicationUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("DaytaCare.Models.DaycareAmenity", b =>
                {
                    b.HasOne("DaytaCare.Models.Amenity", "Amenity")
                        .WithMany()
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DaytaCare.Models.Daycare", "Daycare")
                        .WithMany("DaycareAmenities")
                        .HasForeignKey("DaycareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("Daycare");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DaytaCare.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DaytaCare.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DaytaCare.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DaytaCare.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DaytaCare.Models.Daycare", b =>
                {
                    b.Navigation("DaycareAmenities");
                });
#pragma warning restore 612, 618
        }
    }
}
