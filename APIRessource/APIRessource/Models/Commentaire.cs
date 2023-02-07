using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIRessource.Models
{
	public class COMMENTAIRE
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCommentaire { get; set; }
		public DateTime datePost { get; set; }
		public string commentaire { get; set; }
		public int idDeleted { get; set; }
		public int idRessource { get; set; }
		public int idUser { get; set; }
	}
}
