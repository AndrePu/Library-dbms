using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Librarycard
    {
        public Librarycard()
        {
            LibrarycardsBooks = new HashSet<LibrarycardsBooks>();
            LibrarycardsStudents = new HashSet<LibrarycardsStudents>();
            LibrarycardsTeachers = new HashSet<LibrarycardsTeachers>();
            Student = new HashSet<Student>();
            Teacher = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public DateTime Registrationdate { get; set; }
        public int? ResponsiblelibrarianId { get; set; }

        public virtual Librarian Responsiblelibrarian { get; set; }
        public virtual ICollection<LibrarycardsBooks> LibrarycardsBooks { get; set; }
        public virtual ICollection<LibrarycardsStudents> LibrarycardsStudents { get; set; }
        public virtual ICollection<LibrarycardsTeachers> LibrarycardsTeachers { get; set; }
        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
    }
}
