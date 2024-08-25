using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User
    {
        [Key] public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
