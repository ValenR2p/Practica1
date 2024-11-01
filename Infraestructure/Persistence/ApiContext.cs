﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Domain.Entities.TaskStatus> TaskStatus { get; set; }
        public DbSet<Domain.Entities.Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<InteractionType> InteractionTypes { get; set; }
        public DbSet<Interaction> Interactions { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CampaignType> CampaignTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");
                entity.HasKey(p => p.ProjectID);
                entity.Property(p => p.ProjectID).ValueGeneratedOnAdd();
                entity.HasOne(p => p.Campaign)
                      .WithMany()
                      .HasForeignKey(p => p.CampaignType);
                entity.HasOne(p => p.Client)
                      .WithMany()
                      .HasForeignKey(p => p.ClientID);
                entity.Property(p => p.ProjectName).HasMaxLength(255);
                entity.HasIndex(p => p.ProjectName).IsUnique();
            });
            modelBuilder.Entity<Domain.Entities.Task>(entity =>
            {
                entity.ToTable("Task");
                entity.HasKey(t => t.TaskID);
                entity.Property(t => t.TaskID).ValueGeneratedOnAdd();
                entity.HasOne(t => t.Project)
                .WithMany()
                .HasForeignKey(t => t.ProjectID);
                entity.HasOne(t => t.User)
                      .WithMany()
                      .HasForeignKey(t => t.AssignedTo);
                entity.HasOne(t => t.TaskStatus)
                      .WithMany()
                      .HasForeignKey(t => t.Status);
                entity.Property(t => t.Name).HasMaxLength(int.MaxValue);
            });
            modelBuilder.Entity<Interaction>(entity =>
            {
                entity.ToTable("Interaction");
                entity.HasKey(i => i.InteractionID);
                entity.Property(i => i.InteractionID).ValueGeneratedOnAdd();
                entity.HasOne(i => i.Project)
                      .WithMany()
                      .HasForeignKey(i => i.ProjectID);
                entity.HasOne(i => i.interaction)
                      .WithMany()
                      .HasForeignKey(i => i.interactionType);
                entity.Property(i => i.Notes).HasMaxLength(int.MaxValue);
            });
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");
                entity.HasKey(c => c.ClientID);
                entity.Property(c => c.ClientID).ValueGeneratedOnAdd();
                entity.Property(cl => cl.Name).HasMaxLength(255);
                entity.Property(cl => cl.Email).HasMaxLength(255);
                entity.Property(cl => cl.Phone).HasMaxLength(255);
                entity.Property(cl => cl.Company).HasMaxLength(100);
                entity.Property(cl => cl.Address).HasMaxLength(int.MaxValue);
            });
            modelBuilder.Entity<CampaignType>(entity =>
            {
                entity.ToTable("Campaign Type");
                entity.HasKey(ct => ct.Id);
                entity.Property(ct => ct.Name).HasMaxLength(25);
            });
            modelBuilder.Entity<InteractionType>(entity =>
            {
                entity.ToTable("Interaction Type");
                entity.HasKey(it => it.Id);
                entity.Property(it => it.Name).HasMaxLength(25);
            });
            modelBuilder.Entity<Domain.Entities.TaskStatus>(entity =>
            {
                entity.ToTable("Task Status");
                entity.HasKey(ts => ts.Id);
                entity.Property(ts => ts.Name).HasMaxLength(25);
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(u => u.UserID);
                entity.Property(u => u.Name).HasMaxLength(255);
                entity.Property(u => u.Email).HasMaxLength(255);
            });

            modelBuilder.Entity<CampaignType>().HasData(
                new CampaignType { Id = 1, Name = "SEO" },
                new CampaignType { Id = 2, Name = "PPC" },
                new CampaignType { Id = 3, Name = "Social Media" },
                new CampaignType { Id = 4, Name = "Email Marketing" }
            );
            modelBuilder.Entity<InteractionType>().HasData(
                new InteractionType { Id = 1, Name = "Initial Meeting" },
                new InteractionType { Id = 2, Name = "Phone call" },
                new InteractionType { Id = 3, Name = "Email" },
                new InteractionType { Id = 4, Name = "Presentation of Results" }
            );
            modelBuilder.Entity<Domain.Entities.TaskStatus>().HasData(
                new Domain.Entities.TaskStatus { Id = 1, Name = "Pending" },
                new Domain.Entities.TaskStatus { Id = 2, Name = "In Progress" },
                new Domain.Entities.TaskStatus { Id = 3, Name = "Blocked" },
                new Domain.Entities.TaskStatus { Id = 4, Name = "Done" },
                new Domain.Entities.TaskStatus { Id = 5, Name = "Cancel" }
            );
            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, Name = "Joe Done", Email = "jdone@marketing.com" },
                new User { UserID = 2, Name = "Nill Amstrong", Email = "namstrong@marketing.com" },
                new User { UserID = 3, Name = "Marlyn Morales", Email = "mmoralez@marketing.com" },
                new User { UserID = 4, Name = "Antony Orué", Email = "aorue@marketing.com" },
                new User { UserID = 5, Name = "Jazmin Fernandez", Email = "jfernandez@marketing.com" }
            );


            modelBuilder.Entity<Client>().HasData(
                new Client { ClientID = 1, Name = "Tomas Rippa", Email = "tomasrippa@gmail.com", Phone = "224422", Company = "A", Address = "JI 431", CreateDate = DateTime.Now},
                new Client { ClientID = 2, Name = "Juan Carlos", Email = "carlosjuan@hotmail.com", Phone = "1235486", Company = "B", Address = "M 222", CreateDate = DateTime.Now },
                new Client { ClientID = 3, Name = "Fabian Garcia", Email = "fabiangarcia@yahoo.com", Phone = "213532", Company = "C", Address = "P 321", CreateDate = DateTime.Now },
                new Client { ClientID = 4, Name = "Cristian Campos", Email = "cristiancampos@hotmail.com", Phone = "91805736", Company = "D", Address = "PK 1024", CreateDate = DateTime.Now },
                new Client { ClientID = 5, Name = "Pedro Ramirez", Email = "pedroramirez@gmail.com", Phone = "335232", Company = "A", Address = "B 64", CreateDate = DateTime.Now }
            );
        }
    }
}
