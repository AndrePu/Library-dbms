using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Book
    {
        public Book()
        {
            LibrarycardsBooks = new HashSet<LibrarycardsBooks>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? AuthorId { get; set; }
        public int Pagesamount { get; set; }

        public virtual Author Author { get; set; }
        public virtual ICollection<LibrarycardsBooks> LibrarycardsBooks { get; set; }
    }
}
