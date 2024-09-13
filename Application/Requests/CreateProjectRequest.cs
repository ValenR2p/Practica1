namespace Application.Models
{
    public class CreateProjectRequest
    {
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ClientID { get; set; }
        public int CampaignType { get; set; }
    }
}
