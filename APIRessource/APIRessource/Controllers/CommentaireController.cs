using APIRessource.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APIRessource.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentaireController : ControllerBase
    {
        private readonly RessourceContext cnx;

        public CommentaireController(RessourceContext context)
        {
            cnx = context;
        }

        // POST api/<CommentaireController>
        [HttpPost]
        public void Post([FromBody] string commentaire, int idUser)
        {
            Commentaire c = new Commentaire();
            c.datePoste = DateTime.Now;
            c.commentaire = commentaire;
            c.idDeleted = false;
            c.idRessource = 1;
            c.idUser = idUser;

            cnx.Add(c);
            cnx.SaveChanges();
        }

        // GET api/<CommentaireController>/5
        [HttpGet("{id}")]
        public Commentaire Get(int id)
        {
            return cnx.Commentaire.Where(c => c.id == id).First();
        }

        // DELETE api/<CommentaireController>/5
        [HttpDelete("{id}")]
        public void Delete(int id, int idUser)
        {
            Commentaire c = cnx.Commentaire.Where(c => c.id == id).First();
            c.idDeleted = true;
            c.idUser = idUser;
            cnx.Update(c);
            cnx.SaveChanges();
        }

        // PUT api/<CommentaireController>/5
        [HttpPut("{id}")]
        public void Put(int id, int idUser)
        {
            Commentaire c = cnx.Commentaire.Where(c => c.id == id).First();
            c.idUser = idUser;
            cnx.Update(c);
            cnx.SaveChanges(true);
        }
    }
}
