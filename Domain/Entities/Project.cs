using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int CampaignType { get; set; }
        [ForeignKey(nameof(CampaignType))] public CampaignType Campaign { get; set; }
        public int ClientID { get; set; }
        [ForeignKey(nameof(ClientID))] public Client Client { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
