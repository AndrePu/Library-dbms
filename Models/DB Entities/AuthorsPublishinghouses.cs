using System;
using System.Collections.Generic;

namespace Models
{
    public partial class AuthorsPublishinghouses
    {
        public int Id { get; set; }
        public int? AuthorId { get; set; }
        public int? PublishinghouseId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Publishinghouse Publishinghouse { get; set; }
    }
}
