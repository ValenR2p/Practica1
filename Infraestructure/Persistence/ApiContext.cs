using Domain.Entities;
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

            // Semillas de datos para las tablas
            modelBuilder.Entity<CampaignType>().HasData(
                new CampaignType { Id = 1, Name = "SEO" },
                new CampaignType { Id = 2, Name = "PPC" },
                new CampaignType { Id = 3, Name = "Social Media" },
                new CampaignType { Id = 4, Name = "Email Marketin" }
            );
            modelBuilder.Entity<InteractionType>().HasData(
                new InteractionType { Id= 1, Name = "Initial Meeting" },
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
                new User { UserID = 4, Name = "Antony Orue" , Email = "aorue@marketing.com" },
                new User { UserID = 5, Name = "Jazmin Fernandez", Email = "jfernandez@marketing.com" }
            );
        }
    }
}
