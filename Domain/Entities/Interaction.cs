namespace Domain.Entities
{
    public class Interaction
    {
        public Guid InteractionID { get; set; }
        public Guid ProjectID { get; set; }
        public Project Project { get; set; }
        public int interactionType { get; set; }
        public InteractionType interaction { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
    }
}
