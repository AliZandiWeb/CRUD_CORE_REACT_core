using Microsoft.EntityFrameworkCore;

namespace ASPNetServer.Data
{
    internal sealed class AppDBContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source = ./Data/AppDB.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Post[] postToSeed = new Post[6];
            for (int i = 1; i <= 6; i++)
            {
                postToSeed[i - 1] = new Post
                { 
                    Id = i,
                    Title = $"Post {i}",
                    Content = $"This is post{i} and it has some very interesting content."
                };
            }

            modelBuilder.Entity<Post>().HasData(postToSeed);
        }
    }
}
