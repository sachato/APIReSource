using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIRessource.Models
{
    public class ZONE_GEO
    {
        /*public ZONE_GEO()
        {
            //USER = new HashSet<USER>();
        }*/
        [Key]
        public int idZoneGeo { get; set; }
        public int code { get; set; }
        public string nom_fr_fr { get; set; }
        public  List<USER> USER { get; set; }
    }
}
