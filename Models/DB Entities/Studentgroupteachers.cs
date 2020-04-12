namespace Models
{
    public partial class Studentgroupteachers
    {
        public int Id { get; set; }
        public int? StudentgroupId { get; set; }
        public int? TeacherId { get; set; }
        public string Subject { get; set; }

        public virtual Studentgroup Studentgroup { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
