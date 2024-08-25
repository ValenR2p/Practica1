using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TaskStatus
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
    }
}
