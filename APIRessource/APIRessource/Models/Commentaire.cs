namespace APIRessource.Models
{
	public class COMMENTAIRE
	{
		public int id { get; set; }
		public string datePost { get; set; }
		public string commentaire { get; set; }
		public int idDeleted { get; set; }
		public int idRessource { get; set; }
		public int idUser { get; set; }
	}
}
