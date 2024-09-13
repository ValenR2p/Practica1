namespace Application.Response
{
    public class InformationProjectResponse
    {
        public ProjectResponse data { get; set; }
        public List<InteractionsResponse> interactions { get; set; }
        public List<TaskResponse> tasks { get; set; }
    }
}
