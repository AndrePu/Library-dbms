namespace Models
{
    public partial class LibrarycardsTeachers
    {
        public int Id { get; set; }
        public int? LibrarycardId { get; set; }
        public int? TeacherId { get; set; }

        public virtual Librarycard Librarycard { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
