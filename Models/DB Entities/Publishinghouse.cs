using System.Collections.Generic;

namespace Models
{
    public partial class Publishinghouse
    {
        public Publishinghouse()
        {
            AuthorsPublishinghouses = new HashSet<AuthorsPublishinghouses>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AuthorsPublishinghouses> AuthorsPublishinghouses { get; set; }
    }
}
