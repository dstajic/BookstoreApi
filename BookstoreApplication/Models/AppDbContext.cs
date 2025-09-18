using Microsoft.EntityFrameworkCore;
namespace BookstoreApplication.Models

{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<AwardAuthor> AwardsAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AwardAuthor>()
                .HasOne(aa => aa.Author)
                .WithMany(a => a.AwardAuthors)
                .HasForeignKey(aa => aa.AuthorId);

            modelBuilder.Entity <AwardAuthor>()
                .HasOne(aa => aa.Award)
                .WithMany(a => a.AwardAuthors)
                .HasForeignKey(aa => aa.AwardId);
        }
    }
}
