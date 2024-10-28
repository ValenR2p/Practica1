namespace Application.Models
{
    public class TaskRequest
    {
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public int User { get; set; }
        public int Status { get; set; }

    }
}
