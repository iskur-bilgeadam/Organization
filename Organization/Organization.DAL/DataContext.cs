namespace Organization.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Organization.ENTITY;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Organizations> Organizations { get; set; }
        public virtual DbSet<OrganizationsUsers> OrganizationsUsers { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organizations>()
                .HasMany(e => e.OrganizationsUsers)
                .WithRequired(e => e.Organizations)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.ReceiverID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Messages1)
                .WithRequired(e => e.Users1)
                .HasForeignKey(e => e.SenderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Organizations)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.OrganizationsUsers)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);
        }
    }
}
