using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class CampaignType
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
    }
}
