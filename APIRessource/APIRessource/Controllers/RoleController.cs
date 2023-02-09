using APIRessource.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIRessource.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RessourceContext cnx;

        public RoleController(RessourceContext context)
        {
            cnx = context;
        }

        // GET: api/Role
        [HttpGet]
        public IEnumerable<Models.ROLE> Get()
        {
            return cnx.ROLE.AsQueryable().ToList();
        }

        // GET api/Role/GetByRole/{nomRole}
        [HttpGet("GetByRole/{nomRole}")]
        public IEnumerable<Models.ROLE> GetByRole(string nomRole)
        {
            return cnx.ROLE.Where(r => r.nomRole == nomRole).ToList();
        }


        // DELETE api/<CommentaireController>/5
        [HttpDelete("{id}")]
        public void Delete(int id, int idUser)
        {
            var isModerator = cnx.USER.Any(r => r.idUser == idUser && (r.idRole == 8 || r.idRole == 6 || r.idRole == 7 || r.idRole == 5));
            var isOwner = cnx.CONSULTATION.Where(c => c.idConsultation == id && c.idUser == idUser).Any();
            CONSULTATION c = cnx.CONSULTATION.Where(c => c.idConsultation == id).First();

            
            if (isModerator || isOwner)
            {
                cnx.Remove(c);
                cnx.SaveChanges();
            }
            else if (!isOwner)
                Console.WriteLine("Vous n'etes pas le propriétaire de ce commentaire");
            else if (!isModerator)
                Console.WriteLine("Vous n'etes pas le moérateur");
        }


    }
}
