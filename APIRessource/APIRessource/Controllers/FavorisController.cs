using APIRessource.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIRessource.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavorisController : ControllerBase
    {
        private readonly RessourceContext cnx;

        public FavorisController(RessourceContext context)
        {
            cnx = context;
        }

        [HttpGet("user/{idUser}")]
        public IEnumerable<FAVORIS> GetFavoritesByUser(int idUser)
        {
            return cnx.FAVORIS.Where(f => f.idUser == idUser).ToList();
        }

        [HttpPost]
        public void Post([FromBody] FAVORIS value)
        {
            cnx.Add(value);
            cnx.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FAVORIS value)
        {
            FAVORIS fav = cnx.FAVORIS.Where(f => f.id == id).First();

            if (value.id != null && value != null && fav != null)
            {
                fav.idUser = id;
                fav.idRessource = value.idRessource;

                cnx.Update(fav);
                cnx.SaveChanges(true);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            FAVORIS fav = cnx.FAVORIS.Where(f => f.id == id).First();
            cnx.Remove(fav);
            cnx.SaveChanges();
        }

        [HttpGet("getAllFavorisByUser/{idUser}")]
        public IEnumerable<FAVORIS> VoirTousFAVORISUser(int idUser)
        {
            return cnx.FAVORIS.Where(f => f.idUser == idUser).ToList();
        }
    }
}
