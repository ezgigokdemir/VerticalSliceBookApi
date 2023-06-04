namespace Book.Api.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public Author Author { get; set; }
    }
}
