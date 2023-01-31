namespace APIRessource.Models
{
    public class ZONE_GEO
    {
        /*public ZONE_GEO()
        {
            //USER = new HashSet<USER>();
        }*/
        public int id { get; set; }
        public int code { get; set; }
        public string alpha2 { get; set; }
        public string alpha3 { get; set; }
        public string nom_en_gb { get; set; }
        public string nom_fr_fr { get; set; }
        public virtual ICollection<USER> USER { get; set; }
    }
}
