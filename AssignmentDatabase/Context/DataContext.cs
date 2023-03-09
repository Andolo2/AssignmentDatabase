using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentDatabase.Models.Entities;

namespace AssignmentDatabase.Context
{
    public class DataContext : DbContext
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\Webbutveckling-DotNet\DotNet\AssignmentDatabase\AssignmentDatabase\Context\AssignmentDB01.mdf;Integrated Security=True;Connect Timeout=30";

        #region constructors

        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        #endregion

        #region overrides

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TicketEntity>()
                .Property(x => x.Status)
                .HasDefaultValue("new");
        }


        // Override that add CreatedDate and ModifiedDate when the User uses SaveChangesAsync() method.
        // Used this as the base: https://www.entityframeworktutorial.net/faq/set-created-and-modified-date-in-efcore.aspx
        // Had to add some paremeters to make it work. 
        // The task overrides the SavechangesAsync method and add´s datetime then automaticlly when the method is called. 
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entries = ChangeTracker
         .Entries()
         .Where(e => e.Entity is TicketEntity && (
                 e.State == EntityState.Added
                 || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((TicketEntity)entityEntry.Entity).ModifiedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((TicketEntity)entityEntry.Entity).CreationTime = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        #endregion




        public DbSet<DepartmentEntity> Departments { get; set; } = null!;
        public DbSet<UserEntity> Users { get; set; } = null!;
        public DbSet<TicketEntity> Tickets { get; set; } = null!;
        public DbSet<CommentEntity> Comments { get; set; } = null!;
    }
}
