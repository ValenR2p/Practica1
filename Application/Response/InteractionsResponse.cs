namespace Application.Response
{
    public class InteractionsResponse
    {
        public Guid InteractionID { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
        public Guid ProjectID { get; set; }
        public GenericResponse interaction { get; set; }
    }
}
