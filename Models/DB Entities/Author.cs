using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Author
    {
        public Author()
        {
            AuthorsPublishinghouses = new HashSet<AuthorsPublishinghouses>();
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public virtual ICollection<AuthorsPublishinghouses> AuthorsPublishinghouses { get; set; }
        public virtual ICollection<Book> Book { get; set; }
    }
}
