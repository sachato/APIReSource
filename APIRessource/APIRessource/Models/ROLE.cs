using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIRessource.Models
{
    public class ROLE
    {

        /*public ROLE() 
        {
            //USER = new USER();
        }*/
        [Key]
        public int idRole { get; set; }
        public string nomRole { get; set; }
        public  List<USER> USER { get; set; }
    }
}
