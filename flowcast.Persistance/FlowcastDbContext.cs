using flowcast.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowcast.Persistance
{
    public class FlowcastDbContext : DbContext
    {
        public FlowcastDbContext(DbContextOptions<FlowcastDbContext> options)
            : base(options)
        {
        }

        // === DbSets represent database tables ===
        public DbSet<User> Users => Set<User>();
        public DbSet<Workflow> Workflows => Set<Workflow>();
        public DbSet<WorkflowParameterDefinition> WorkflowParameterDefinitions { get; set; } = null!;
        public DbSet<WorkflowStep> WorkflowSteps => Set<WorkflowStep>();
        public DbSet<Rule> Rules => Set<Rule>();
        public DbSet<Module> Modules => Set<Module>();


        // === Configure relationships between entities ===
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Workflow --> many ParameterDefinitions
            modelBuilder.Entity<Workflow>()
                .HasMany(w => w.ParameterDefinitions)
                .WithOne(p => p.Workflow)
                .HasForeignKey(p => p.WorkflowId)
                .OnDelete(DeleteBehavior.Cascade);

            // Workflow --> many Steps
            modelBuilder.Entity<Workflow>()
                .HasMany(w => w.Steps)
                .WithOne(s => s.Workflow)
                .HasForeignKey(s => s.WorkflowId)
                .OnDelete(DeleteBehavior.Cascade);

            // WorkflowStep --> many Rules
            modelBuilder.Entity<WorkflowStep>()
                .HasMany(s => s.Rules)
                .WithOne(r => r.WorkflowStep)
                .HasForeignKey(r => r.WorkflowStepId)
                .OnDelete(DeleteBehavior.Cascade);

            // Required call to the base configuration
            base.OnModelCreating(modelBuilder);

        }
    }
}
