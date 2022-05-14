using Microsoft.EntityFrameworkCore;
using BitirmeProjesiBackend.Data.Entities;

namespace BitirmeProjesiBackend.Data.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Event> Events => Set<Event>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(x => x.Comments).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Event>().HasMany(x => x.Comments).WithOne(x => x.Event).HasForeignKey(x => x.EventId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasMany(x => x.Tickets).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Event>().HasMany(x => x.Tickets).WithOne(x => x.Event).HasForeignKey(x => x.EventId).OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }
    }
}
