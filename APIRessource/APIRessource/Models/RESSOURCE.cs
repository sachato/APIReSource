namespace APIRessource.Models
{
    public class RESSOURCE
    {
        public int id { get; set; }
        public string titre { get; set; }
        public string description { get; set; }
        public DateTime dateCreation { get; set; }
        public string path { get; set; }
        public int upVote { get; set; }
        public int downVote { get; set; }
        public int idType { get; set; }
        public int idUser { get; set; }
    }
}
