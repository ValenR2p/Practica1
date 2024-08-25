using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Interaction
    {
        [Key] public int InteractionID_uuid { get; set; }
        public int ProjectID { get; set; }

        //[ForeignKey(nameof(ProjectID))]
        public Project Project { get; set; }
        public int interactionType { get; set; }

        //[ForeignKey(nameof(interaction))]
        public InteractionType interaction { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
    }
}
