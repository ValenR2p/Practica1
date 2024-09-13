namespace Application.Models
{
    public class CreateTaskRequest
    {
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public int AssignedTo { get; set; }
        public int Status { get; set; }

    }
}
