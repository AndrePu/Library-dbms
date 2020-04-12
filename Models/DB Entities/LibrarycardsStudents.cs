namespace Models
{
    public partial class LibrarycardsStudents
    {
        public int Id { get; set; }
        public int? LibrarycardId { get; set; }
        public int? StudentId { get; set; }

        public virtual Librarycard Librarycard { get; set; }
        public virtual Student Student { get; set; }
    }
}
