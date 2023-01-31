namespace APIRessource.Models
{
    public class ROLE
    {

        public ROLE() 
        {
            //USER = new USER();
        }
        public int id { get; set; }
        public string nomRole { get; set; }
        public USER USER { get; set; }
    }
}
