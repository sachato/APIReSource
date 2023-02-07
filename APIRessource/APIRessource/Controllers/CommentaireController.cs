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
        public void Post(string commentaire, int idRessource, int idUser)
        {
            COMMENTAIRE c = new COMMENTAIRE();
            var lastId = cnx.COMMENTAIRE.OrderByDescending(x => x.idCommentaire).Select(x => x.idCommentaire).FirstOrDefault();
            var userExist = cnx.USER.Any(r => r.id == idUser);

            if (idUser >= 0 && userExist)
            {
                
                c.commentaire = commentaire;
                c.idDeleted = 0;
                c.idRessource = idRessource;
                c.idUser = idUser;
                c.datePost = DateTime.Now; 

                cnx.Add(c);
                cnx.SaveChanges(true);
            }
        }

        // GET api/<CommentaireController>/5
        [HttpGet("GetCommentaires/{idCommentaire}")]
        public COMMENTAIRE Get(int idCommentaire)
        {
            return cnx.COMMENTAIRE.Where(c => c.idCommentaire == idCommentaire).First();
        }

        // GETALL BY RESSOURCE
        [HttpGet("GetALLCommentairesByRessource/{idRessource}")]
        public IEnumerable<COMMENTAIRE> GetAllCommentairesByRessourceId(int idRessource)
        {
            return cnx.COMMENTAIRE.Where(c => c.idRessource == idRessource && c.idDeleted == 0).ToList();
        }

        // DELETE api/<CommentaireController>/5
        [HttpDelete("{id}")]
        public void Delete(int id, int idUser)
        {
            var isModerator = cnx.USER.Any(r => r.id == idUser && (r.idRole == 8 || r.idRole == 6 || r.idRole == 7 || r.idRole == 5));
            var isOwner = cnx.COMMENTAIRE.Where(c => c.idCommentaire == id && c.idUser == idUser).Any();
            var isDeleted = cnx.COMMENTAIRE.Where(c => c.idCommentaire == id && c.idDeleted == 1).Any();
            var userRole = cnx.USER.Where(r => r.id == idUser).FirstOrDefault();
            COMMENTAIRE c = cnx.COMMENTAIRE.Where(c => c.idCommentaire == id).First();

         
                if ((isModerator || isOwner) && !isDeleted)
                {
                    c.idDeleted = 1;
                    c.idUser = idUser;
                    cnx.Update(c);
                    cnx.SaveChanges();
                }
                else if (isDeleted)
                    Console.WriteLine("Le commentaire a été supprimé");
                else if (!isOwner)
                    Console.WriteLine("Vous n'etes pas le propriétaire de ce commentaire");
                else if (!isModerator)
                    Console.WriteLine("Vous n'etes pas le moérateur");
        }

        // PUT api/<CommentaireController>/5
        [HttpPut("{id}")]
        public void Put(int id, int idUser, [FromBody] COMMENTAIRE commentaire)
        {
            var isModerator = cnx.USER.Where(r => r.id == idUser && r.idRole == 8).Any();
            var isOwner = cnx.COMMENTAIRE.Where(c => c.idCommentaire == id && c.idUser == idUser).Any();
            var isDeleted = cnx.COMMENTAIRE.Where(c => c.idCommentaire == id && c.idDeleted == 1).Any();
            

            if ((isModerator || isOwner) && !isDeleted)
            {
                COMMENTAIRE c = cnx.COMMENTAIRE.Where(c => c.idCommentaire == id).First();
                c.commentaire = commentaire.commentaire;
                c.datePost = DateTime.Now;
                cnx.Update(c);
                cnx.SaveChanges();
            }
        }

        

    }

}
