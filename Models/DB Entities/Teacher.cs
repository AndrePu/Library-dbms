using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            LibrarycardsTeachers = new HashSet<LibrarycardsTeachers>();
            Studentgroup = new HashSet<Studentgroup>();
            Studentgroupteachers = new HashSet<Studentgroupteachers>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int? LibrarycardId { get; set; }

        public virtual Librarycard Librarycard { get; set; }
        public virtual ICollection<LibrarycardsTeachers> LibrarycardsTeachers { get; set; }
        public virtual ICollection<Studentgroup> Studentgroup { get; set; }
        public virtual ICollection<Studentgroupteachers> Studentgroupteachers { get; set; }
    }
}
