using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Task
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid TaskID { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public Guid ProjectID { get; set; }
        [ForeignKey(nameof(ProjectID))] public Project Project { get; set; }
        public int AssignedTo { get; set; }
        [ForeignKey(nameof(AssignedTo))] public User User { get; set; }
        public int Status { get; set; }
        [ForeignKey(nameof(Status))] public TaskStatus TaskStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
