using System.ComponentModel.DataAnnotations;

namespace APIRessource.Models
{
    public class RESSOURCE
    {
        [Key]
        public int idRessource { get; set; }
        public string titre { get; set; }
        public string description { get; set; }
        public DateTime? dateCreation { get; set; }
        public string? path { get; set; }
        public int? upVote { get; set; }
        public int? downVote { get; set; }
        public bool? isDeleted { get; set; }
        public int idType { get; set; }
        public int idUser { get; set; }
        public USER? USER { get; set; }
    }
}
