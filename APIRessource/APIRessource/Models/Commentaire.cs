namespace APIRessource.Models
{
	public class Commentaire
	{
		public int id { get; set; }
		public DateTime datePoste { get; set; }
		public string commentaire { get; set; }
		public bool idDeleted { get; set; }
		public int idRessource { get; set; }
		public int idUser { get; set; }
	}
}
