namespace BasicDBWebApp.Entities
{
    public class Grade
    {
        public Guid GradeID { get; set; }
        public string GradeName { get; set;} = string.Empty;
        public ICollection<Student>? Students { get; set; }
    }
}
