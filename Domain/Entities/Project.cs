namespace Domain.Entities
{
    public class Project
    {
        public Guid ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int CampaignType { get; set; }
        public CampaignType Campaign { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
