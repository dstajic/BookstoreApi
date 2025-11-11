using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<AwardAuthor> AwardsAuthors { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure AwardAuthor relationships
            modelBuilder.Entity<AwardAuthor>()
                .HasOne(aa => aa.Author)
                .WithMany(a => a.AwardAuthors)
                .HasForeignKey(aa => aa.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AwardAuthor>()
                .HasOne(aa => aa.Award)
                .WithMany(a => a.AwardAuthors)
                .HasForeignKey(aa => aa.AwardId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AwardAuthor>(entity =>
            {
                entity.ToTable("AwardAuthorBridge");
            });

            // Rename Author DateOfBirth column
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(a => a.DateOfBirth).HasColumnName("Birthday");
            });
            modelBuilder.Entity<Author>()
       .HasIndex(a => a.FullName)
       .HasDatabaseName("IX_Authors_Name");

            // Book -> Publisher relationship
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Review>()
        .HasOne(r => r.Book)
        .WithMany(b => b.Reviews)
        .HasForeignKey(r => r.BookId)
        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Seed Authors
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FullName = "John Doe", Biography = "Fiction writer from USA", DateOfBirth = DateTime.SpecifyKind(new DateTime(1975, 5, 12), DateTimeKind.Utc) },
                new Author { Id = 2, FullName = "Jane Smith", Biography = "Science fiction author", DateOfBirth = DateTime.SpecifyKind(new DateTime(1980, 8, 22), DateTimeKind.Utc) },
                new Author { Id = 3, FullName = "Alice Johnson", Biography = "Children's books author", DateOfBirth = DateTime.SpecifyKind(new DateTime(1990, 2, 3), DateTimeKind.Utc) },
                new Author { Id = 4, FullName = "Robert Brown", Biography = "Historical novels writer", DateOfBirth = DateTime.SpecifyKind(new DateTime(1965, 11, 15), DateTimeKind.Utc) },
                new Author { Id = 5, FullName = "Emily Davis", Biography = "Mystery novels author", DateOfBirth = DateTime.SpecifyKind(new DateTime(1985, 7, 30), DateTimeKind.Utc) }
            );

            // Seed Publishers
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Sunshine Books", Address = "123 Main St, NY", Website = "http://sunshinebooks.com" },
                new Publisher { Id = 2, Name = "Moonlight Press", Address = "456 Oak Ave, LA", Website = "http://moonlightpress.com" },
                new Publisher { Id = 3, Name = "Star Publishers", Address = "789 Pine Rd, TX", Website = "http://starpublishers.com" }
            );

            // Seed Books
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Dawn", PageCount = 320, PublishedDate = DateTime.SpecifyKind(new DateTime(2001, 5, 12), DateTimeKind.Utc), ISBN = "978-0-1111-1111-1", AuthorId = 1, PublisherId = 1 },
                new Book { Id = 2, Title = "Space Odyssey", PageCount = 280, PublishedDate = DateTime.SpecifyKind(new DateTime(2005, 6, 10), DateTimeKind.Utc), ISBN = "978-0-1111-1111-2", AuthorId = 2, PublisherId = 2 },
                new Book { Id = 3, Title = "Magic Tales", PageCount = 150, PublishedDate = DateTime.SpecifyKind(new DateTime(2010, 3, 8), DateTimeKind.Utc), ISBN = "978-0-1111-1111-3", AuthorId = 3, PublisherId = 1 },
                new Book { Id = 4, Title = "History of Rome", PageCount = 400, PublishedDate = DateTime.SpecifyKind(new DateTime(1999, 1, 20), DateTimeKind.Utc), ISBN = "978-0-1111-1111-4", AuthorId = 4, PublisherId = 3 },
                new Book { Id = 5, Title = "Mystery Manor", PageCount = 250, PublishedDate = DateTime.SpecifyKind(new DateTime(2015, 9, 12), DateTimeKind.Utc), ISBN = "978-0-1111-1111-5", AuthorId = 5, PublisherId = 2 },
                new Book { Id = 6, Title = "Ocean Secrets", PageCount = 300, PublishedDate = DateTime.SpecifyKind(new DateTime(2008, 4, 18), DateTimeKind.Utc), ISBN = "978-0-1111-1111-6", AuthorId = 1, PublisherId = 3 },
                new Book { Id = 7, Title = "Future Worlds", PageCount = 360, PublishedDate = DateTime.SpecifyKind(new DateTime(2012, 7, 25), DateTimeKind.Utc), ISBN = "978-0-1111-1111-7", AuthorId = 2, PublisherId = 1 },
                new Book { Id = 8, Title = "Fairy Land", PageCount = 200, PublishedDate = DateTime.SpecifyKind(new DateTime(2018, 2, 14), DateTimeKind.Utc), ISBN = "978-0-1111-1111-8", AuthorId = 3, PublisherId = 2 },
                new Book { Id = 9, Title = "Ancient Empires", PageCount = 420, PublishedDate = DateTime.SpecifyKind(new DateTime(2000, 11, 11), DateTimeKind.Utc), ISBN = "978-0-1111-1111-9", AuthorId = 4, PublisherId = 1 },
                new Book { Id = 10, Title = "Detective Stories", PageCount = 290, PublishedDate = DateTime.SpecifyKind(new DateTime(2016, 6, 6), DateTimeKind.Utc), ISBN = "978-0-1111-1111-10", AuthorId = 5, PublisherId = 3 },
                new Book { Id = 11, Title = "Lost Kingdom", PageCount = 310, PublishedDate = DateTime.SpecifyKind(new DateTime(2011, 9, 1), DateTimeKind.Utc), ISBN = "978-0-1111-1111-11", AuthorId = 1, PublisherId = 2 },
                new Book { Id = 12, Title = "Starlight Adventures", PageCount = 270, PublishedDate = DateTime.SpecifyKind(new DateTime(2014, 12, 5), DateTimeKind.Utc), ISBN = "978-0-1111-1111-12", AuthorId = 2, PublisherId = 3 }
            );

            // Seed Awards
            modelBuilder.Entity<Award>().HasData(
                new Award { Id = 1, Name = "Best Fiction", Description = "Award for best fiction book", StartYear = 2000 },
                new Award { Id = 2, Name = "Sci-Fi Excellence", Description = "Award for outstanding science fiction", StartYear = 2005 },
                new Award { Id = 3, Name = "Children's Choice", Description = "Award for children's books", StartYear = 2010 },
                new Award { Id = 4, Name = "Mystery Master", Description = "Award for mystery novels", StartYear = 2015 }
            );

            // Seed AwardAuthor bridge
            modelBuilder.Entity<AwardAuthor>().HasData(
                new AwardAuthor { Id = 1, AuthorId = 1, AwardId = 1, awardYear = 2001 },
                new AwardAuthor { Id = 2, AuthorId = 2, AwardId = 2, awardYear = 2006 },
                new AwardAuthor { Id = 3, AuthorId = 3, AwardId = 3, awardYear = 2011 },
                new AwardAuthor { Id = 4, AuthorId = 4, AwardId = 1, awardYear = 2000 },
                new AwardAuthor { Id = 5, AuthorId = 5, AwardId = 4, awardYear = 2016 },
                new AwardAuthor { Id = 6, AuthorId = 1, AwardId = 2, awardYear = 2005 },
                new AwardAuthor { Id = 7, AuthorId = 2, AwardId = 1, awardYear = 2007 },
                new AwardAuthor { Id = 8, AuthorId = 3, AwardId = 3, awardYear = 2012 },
                new AwardAuthor { Id = 9, AuthorId = 4, AwardId = 4, awardYear = 2017 },
                new AwardAuthor { Id = 10, AuthorId = 5, AwardId = 2, awardYear = 2018 },
                new AwardAuthor { Id = 11, AuthorId = 1, AwardId = 3, awardYear = 2013 },
                new AwardAuthor { Id = 12, AuthorId = 2, AwardId = 4, awardYear = 2019 },
                new AwardAuthor { Id = 13, AuthorId = 3, AwardId = 1, awardYear = 2014 },
                new AwardAuthor { Id = 14, AuthorId = 4, AwardId = 2, awardYear = 2015 },
                new AwardAuthor { Id = 15, AuthorId = 5, AwardId = 3, awardYear = 2020 }
            );
        }
    }
}
