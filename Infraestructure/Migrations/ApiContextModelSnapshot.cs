﻿// <auto-generated />
using System;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.CampaignType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Campaign Type", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "SEO"
                        },
                        new
                        {
                            Id = 2,
                            Name = "PPC"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Social Media"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Email Marketing"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ClientID");

                    b.ToTable("Client", (string)null);

                    b.HasData(
                        new
                        {
                            ClientID = 1,
                            Address = "JI 431",
                            Company = "A",
                            CreateDate = new DateTime(2024, 10, 28, 15, 38, 31, 384, DateTimeKind.Local).AddTicks(3543),
                            Email = "tomasrippa@gmail.com",
                            Name = "Tomas Rippa",
                            Phone = "224422"
                        },
                        new
                        {
                            ClientID = 2,
                            Address = "M 222",
                            Company = "B",
                            CreateDate = new DateTime(2024, 10, 28, 15, 38, 31, 384, DateTimeKind.Local).AddTicks(3555),
                            Email = "carlosjuan@hotmail.com",
                            Name = "Juan Carlos",
                            Phone = "1235486"
                        },
                        new
                        {
                            ClientID = 3,
                            Address = "P 321",
                            Company = "C",
                            CreateDate = new DateTime(2024, 10, 28, 15, 38, 31, 384, DateTimeKind.Local).AddTicks(3557),
                            Email = "fabiangarcia@yahoo.com",
                            Name = "Fabian Garcia",
                            Phone = "213532"
                        },
                        new
                        {
                            ClientID = 4,
                            Address = "PK 1024",
                            Company = "D",
                            CreateDate = new DateTime(2024, 10, 28, 15, 38, 31, 384, DateTimeKind.Local).AddTicks(3559),
                            Email = "cristiancampos@hotmail.com",
                            Name = "Cristian Campos",
                            Phone = "91805736"
                        },
                        new
                        {
                            ClientID = 5,
                            Address = "B 64",
                            Company = "A",
                            CreateDate = new DateTime(2024, 10, 28, 15, 38, 31, 384, DateTimeKind.Local).AddTicks(3652),
                            Email = "pedroramirez@gmail.com",
                            Name = "Pedro Ramirez",
                            Phone = "335232"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Interaction", b =>
                {
                    b.Property<Guid>("InteractionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProjectID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("interactionType")
                        .HasColumnType("int");

                    b.HasKey("InteractionID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("interactionType");

                    b.ToTable("Interaction", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.InteractionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Interaction Type", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Initial Meeting"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Phone call"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Email"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Presentation of Results"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Project", b =>
                {
                    b.Property<Guid>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CampaignType")
                        .HasColumnType("int");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectID");

                    b.HasIndex("CampaignType");

                    b.HasIndex("ClientID");

                    b.HasIndex("ProjectName")
                        .IsUnique();

                    b.ToTable("Project", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Task", b =>
                {
                    b.Property<Guid>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AssignedTo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProjectID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TaskID");

                    b.HasIndex("AssignedTo");

                    b.HasIndex("ProjectID");

                    b.HasIndex("Status");

                    b.ToTable("Task", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TaskStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Task Status", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pending"
                        },
                        new
                        {
                            Id = 2,
                            Name = "In Progress"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Blocked"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Done"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Cancel"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UserID");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Email = "jdone@marketing.com",
                            Name = "Joe Done"
                        },
                        new
                        {
                            UserID = 2,
                            Email = "namstrong@marketing.com",
                            Name = "Nill Amstrong"
                        },
                        new
                        {
                            UserID = 3,
                            Email = "mmoralez@marketing.com",
                            Name = "Marlyn Morales"
                        },
                        new
                        {
                            UserID = 4,
                            Email = "aorue@marketing.com",
                            Name = "Antony Orué"
                        },
                        new
                        {
                            UserID = 5,
                            Email = "jfernandez@marketing.com",
                            Name = "Jazmin Fernandez"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Interaction", b =>
                {
                    b.HasOne("Domain.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.InteractionType", "interaction")
                        .WithMany()
                        .HasForeignKey("interactionType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("interaction");
                });

            modelBuilder.Entity("Domain.Entities.Project", b =>
                {
                    b.HasOne("Domain.Entities.CampaignType", "Campaign")
                        .WithMany()
                        .HasForeignKey("CampaignType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Domain.Entities.Task", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("AssignedTo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TaskStatus", "TaskStatus")
                        .WithMany()
                        .HasForeignKey("Status")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("TaskStatus");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
