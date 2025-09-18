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
            modelBuilder.Entity<AwardAuthor>()//povezi tabelu sa author        
                .HasOne(aa => aa.Author)
                .WithMany(a => a.AwardAuthors)
                .HasForeignKey(aa => aa.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
           

            modelBuilder.Entity<AwardAuthor>()//povezi taBELU SA award
                .HasOne(aa => aa.Award)
                .WithMany(a => a.AwardAuthors)
                .HasForeignKey(aa => aa.AwardId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<AwardAuthor>(entity =>
            {
                entity.ToTable("AwardAuthorBridge");
            });
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(a => a.DateOfBirth).HasColumnName("Birthday");
            });
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
