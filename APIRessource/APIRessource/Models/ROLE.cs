using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIRessource.Models
{
	public class ROLE
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idRole { get; set; }
		public string nomRole { get; set; }
	}
}
