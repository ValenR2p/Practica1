namespace Application.Response
{
    public class TaskResponse
    {
        public Guid TaskID { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public Guid ProjectID { get; set; }
        public GenericResponse TaskStatus { get; set; }
        public UserResponse User { get; set; }
    }
}
