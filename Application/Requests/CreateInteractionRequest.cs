namespace Application.Models
{
    public class CreateInteractionRequest
    {
        public int interactionType { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
    }
}
