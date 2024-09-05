using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Interaction
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid InteractionID { get; set; }
        public Guid ProjectID { get; set; }
        [ForeignKey(nameof(ProjectID))] public Project Project { get; set; }
        public int interactionType { get; set; }
        [ForeignKey(nameof(interactionType))] public InteractionType interaction { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
    }
}
