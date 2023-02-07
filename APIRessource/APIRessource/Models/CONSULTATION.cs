using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIRessource.Models
{
    public class CONSULTATION
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idConsultation { get; set; }
        public int idRessource { get; set; }
        public int idUser { get; set; }
        public DateTime date { get; set; }
    }
}
