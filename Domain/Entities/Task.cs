using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Task
    {
        [Key] public int TaskID_uuid { get; set; }
        public string Name { get; set; }
        DateTime DueDate { get; set; }
        public int ProjectID { get; set; }
        public Project Project { get; set; }
        public User AssignedTo { get; set; }
        public TaskStatus Status { get; set; }
    }
}
