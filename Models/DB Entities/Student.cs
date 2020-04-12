using System.Collections.Generic;

namespace Models
{
    public partial class Student
    {
        public Student()
        {
            LibrarycardsStudents = new HashSet<LibrarycardsStudents>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int? StudentgroupId { get; set; }
        public int? LibrarycardId { get; set; }

        public virtual Librarycard Librarycard { get; set; }
        public virtual Studentgroup Studentgroup { get; set; }
        public virtual ICollection<LibrarycardsStudents> LibrarycardsStudents { get; set; }
    }
}
