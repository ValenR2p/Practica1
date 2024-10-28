namespace Application.Response
{
    public class InformationProjectResponse
    {
        public ProjectResponse Data { get; set; }
        public List<InteractionsResponse> Interactions { get; set; }
        public List<TaskResponse> Tasks { get; set; }
    }
}
