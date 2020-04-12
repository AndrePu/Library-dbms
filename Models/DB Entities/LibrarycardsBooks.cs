namespace Models
{
    public partial class LibrarycardsBooks
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? LibrarycardId { get; set; }
        public string Returned { get; set; }

        public virtual Book Book { get; set; }
        public virtual Librarycard Librarycard { get; set; }
    }
}
