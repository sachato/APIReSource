using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIRessource.Models;
using APIRessource.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APIRessource.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentairesController : ControllerBase
    {
        private readonly RessourceContext _context;

        public CommentairesController(RessourceContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Commentaire>> AjouterCommentaire(int idRessource, string commentaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nouveauCommentaire = new Commentaire
            {
                idRessource = idRessource,
                commentaire = commentaire,
                datePoste = DateTime.Now
            };

            try
            {
                _context.Commentaires.Add(nouveauCommentaire);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest("Impossible d'ajouter le commentaire");
            }

            return CreatedAtAction(nameof(GetCommentaire), new { id = nouveauCommentaire.id }, nouveauCommentaire);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModifierCommentaire(int id, string commentaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commentaireAModifier = await _context.Commentaires.FindAsync(id);

            if (commentaireAModifier == null)
            {
                return NotFound();
            }

            commentaireAModifier.commentaire = commentaire;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Impossible de mettre à jour le commentaire");
            }


            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Commentaire>> SupprimerCommentaire(int id)
        {
            var commentaireASupprimer = await _context.Commentaires.FindAsync(id);
            if (commentaireASupprimer == null)
            {
                return NotFound();
            }

            _context.Commentaires.Remove(commentaireASupprimer);
            await _context.SaveChangesAsync();

            return commentaireASupprimer;
        }

        private bool CommentaireExiste(long id)
        {
            return _context.Commentaires.Any(e => e.id == id);
        }

        private async Task<ActionResult<Commentaire>> GetCommentaire(long id)
        {
            var commentaire = await _context.Commentaires.FindAsync(id);

            if (commentaire == null)
            {
                return NotFound();
            }

            return commentaire;
        }
    }
}
