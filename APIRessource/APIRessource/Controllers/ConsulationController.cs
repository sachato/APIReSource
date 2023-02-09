using APIRessource.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APIRessource.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private readonly RessourceContext cnx;

        public ConsultationController(RessourceContext context)
        {
            cnx = context;
        }

        // POST api/<ConsultationController>
        [HttpPost]
        public void Post(int idRessource,  int idUser)
        { 
        
            CONSULTATION consultation = new CONSULTATION();

            consultation.idRessource = idRessource;
            consultation.idUser = idUser;
            consultation.date = DateTime.Now;

            cnx.Add(consultation);
            cnx.SaveChanges(true);
        }

        // GET api/<ConsultationController>
        [HttpGet]
        public ActionResult<IEnumerable<CONSULTATION>> Get()
        {
            return cnx.CONSULTATION.ToList();
        }

        [HttpGet("getAllConsultatioByUser/{id}")]
        public ActionResult<IEnumerable<CONSULTATION>> GetByUser(int idUser)
        {
            return cnx.CONSULTATION.Where(x => x.idUser == idUser).ToList();
        }

        // DELETE 
        [HttpDelete("{id}")]
        public void Delete(int id, int idUser, int idRole)
        {
            var isModerator = cnx.USER.Any(r => r.idUser == idUser && (r.idRole == 8 || r.idRole == 6 || r.idRole == 7 || r.idRole == 5));
            CONSULTATION c = cnx.CONSULTATION.Where(c => c.idConsultation == id).First();
            if (isModerator)
            {
                cnx.Remove(c);
                cnx.SaveChanges();
            }
            else if (!isModerator)
                Console.WriteLine("Vous n'etes pas le moérateur");
        }

        // PUT api/<CommentaireController>/5
        [HttpPut("{id}")]
        public void Put(string nomRole, int idUser, int idRole)
        {
            var isModerator = cnx.USER.Where(r => r.idUser == idUser && r.idRole == 8).Any();

            if (isModerator)
            {
                ROLE c = cnx.ROLE.Where(c => c.idRole == idRole).First();

                c.nomRole = nomRole;
                cnx.Update(c);
                cnx.SaveChanges(true);
            }
        }


    }
}
