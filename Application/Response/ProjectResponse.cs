namespace Application.Response
{
    public class ProjectResponse
    {
        public Guid ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ClientResponse Client { get; set; }
        public GenericResponse Campaign { get; set; }
    }
}
