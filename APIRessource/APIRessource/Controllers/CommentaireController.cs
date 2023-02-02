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

        // POST api/<CommentaireController>CommentaireRessource
        [HttpPost]
        public void Post()
        {
            COMMENTAIRE c = new COMMENTAIRE();
            c.id = 1;
            c.datePost = "de";
            c.commentaire = "commentaire";
            c.idDeleted = 0;
            c.idRessource = 1;
            c.idUser = 1;

            cnx.Add(c);
            cnx.SaveChanges(true);
        }

        // GET api/<CommentaireController>/5
        [HttpGet("{id}")]
        public COMMENTAIRE Get(int id)
        {
            return cnx.COMMENTAIRE.Where(c => c.id == id).First();
        }

        // DELETE api/<CommentaireController>/5
        [HttpDelete("{id}")]
        public void Delete(int id, int idUser)
        {
            COMMENTAIRE c = cnx.COMMENTAIRE.Where(c => c.id == id).First();
            c.idDeleted = 1;
            c.idUser = idUser;
            cnx.Update(c);
            cnx.SaveChanges();
        }

        // PUT api/<CommentaireController>/5
        [HttpPut("{id}")]
        public void Put(int id, int idUser)
        {
            COMMENTAIRE c = cnx.COMMENTAIRE.Where(c => c.id == id).First();
            c.idUser = idUser;
            cnx.Update(c);
            cnx.SaveChanges(true);
        }
    }

    ///////////////////////////////rajouter moderer un mommentaire/////////////////////////////////////////////////////////////////////////
}
