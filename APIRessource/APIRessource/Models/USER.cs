using System.ComponentModel.DataAnnotations;

namespace APIRessource.Models
{
    public class USER
    {

        /*public USER()
        {
            //ZONE_GEO = new ZONE_GEO();
            //ROLE = new ROLE();
        }*/
        [Key]
        public int idUser { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string telephone { get; set; }
        public string pseudo { get; set; }
        public DateTime? dateCreation { get; set; }
        public bool? isDeleted { get; set; }
        public bool? isConfirm { get; set; }
        public int idZoneGeo { get; set; }
        public int idRole { get; set; }
        public  ZONE_GEO? ZONE_GEO { get; set; }
        public  ROLE? ROLE { get; set; }
        public List<RESSOURCE>? RESSOURCE { get; set; }

    }
}
