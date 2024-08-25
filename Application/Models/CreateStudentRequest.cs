using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Deberia esta en application
namespace Application.Models
{
    //Cuando me llega una solicitud de la base de datos, esto creara un Student junto a una direccion
    //pues como tienen una relacion, no puede haber un Student sin direccion del mismo
    public class CreateStudentRequest
    {
        public string StudentName { get; set; }
        public int Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
    }
}
