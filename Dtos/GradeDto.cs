namespace BasicDBWebApp.Dtos
{
    public class GradeDto
    {
        public Guid GradeID { get; set; }
        public string GradeName { get; set; } = string.Empty;
        public int Students { get; set; }
    }
}
