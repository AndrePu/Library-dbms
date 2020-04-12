using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Librarian
    {
        public Librarian()
        {
            Librarycard = new HashSet<Librarycard>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public virtual ICollection<Librarycard> Librarycard { get; set; }
    }
}
