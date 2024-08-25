using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectID_uuid { get; set; }
        public string ProjectName { get; set; }
        public int CampaignType { get; set; }

        //[ForeignKey(nameof(CampaignType))]
        public CampaignType Campaign { get; set; }
        public int ClientID { get; set; }

        //Al asignar Client como Clave Foranea, se le atribuye a ClientID como valor que conecta el projecto 
        //Con un objeto de tipo Client, haciendo esto mediante el nameof
        //[ForeignKey(nameof(ClientID))]//tambien se puede escribir como FoerignKey("ClientID"), creo
        public Client Client { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
