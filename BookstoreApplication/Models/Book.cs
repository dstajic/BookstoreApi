namespace BookstoreApplication.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishedDate { get; set; }
        public required string ISBN { get; set; }
        public double AverageRating { get; set; } = 0.0;
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
    }
}
