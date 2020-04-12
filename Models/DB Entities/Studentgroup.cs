using System.Collections.Generic;

namespace Models
{
    public partial class Studentgroup
    {
        public Studentgroup()
        {
            Student = new HashSet<Student>();
            Studentgroupteachers = new HashSet<Studentgroupteachers>();
        }

        public int Id { get; set; }
        public int? CuratorId { get; set; }
        public string Groupname { get; set; }

        public virtual Teacher Curator { get; set; }
        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<Studentgroupteachers> Studentgroupteachers { get; set; }
    }
}
