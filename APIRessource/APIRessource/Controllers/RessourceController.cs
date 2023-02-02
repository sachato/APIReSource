using APIRessource.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.OleDb;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIRessource.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RessourceController : ControllerBase
    {
        private readonly RessourceContext cnx;

        public RessourceController(RessourceContext context)
        {
            cnx = context;
        }

        // GET: api/<RessourceController>
        [HttpGet]
        public IEnumerable<RESSOURCE> Get()
        {
            return cnx.RESSOURCE.Include(r => r.USER).ToList();
        }

        // GET api/<RessourceController>/5
        [HttpGet("{id}")]
        public RESSOURCE Get(int id)
        {
            return cnx.RESSOURCE.Where(r => r.idRessource == id).Include(r => r.USER).First();
        }

        // POST api/<RessourceController>
        //TODO creation token auth
        [HttpPost]
        public void Post([FromBody] RESSOURCE ressource, int idUser)
        {
            ressource.dateCreation= DateTime.Now;
            ressource.downVote = 0;
            ressource.upVote = 0;
            ressource.isDeleted = false;
            ressource.idUser = idUser;
            //TODO ajouter le type de ressource
            if(idUser != null && idUser > 0)
            {
                //ressource.USER = cnx.USER.Where(r => r.idUser == idUser).FirstOrDefault();
            }
            //TODO throw error si pas de id user, impossible d'add

            cnx.Add(ressource);
            cnx.SaveChanges();
        }

        // PUT api/<RessourceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] RESSOURCE ressource)
        {
            cnx.Update(ressource);
            cnx.SaveChanges();
        }

        // DELETE api/<RessourceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            RESSOURCE ressource = cnx.RESSOURCE.Where(r=>r.idRessource==id).FirstOrDefault();
            ressource.isDeleted = true;
            cnx.Update(ressource);
            cnx.SaveChanges();
        }
    }
}
