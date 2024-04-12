using DevBlog.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DevBlog.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Post> posts { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Posts)
                .WithOne(e => e.Author)
                .HasForeignKey(e => e.AuthorId)
                .IsRequired();

            modelBuilder.Entity<Post>()
                .HasOne(e => e.Author)
                .WithMany(e => e.Posts)
                .HasForeignKey(e => e.AuthorId)
                .IsRequired();
        }
    }
}
