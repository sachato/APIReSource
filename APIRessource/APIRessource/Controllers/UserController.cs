using APIRessource.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIRessource.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RessourceContext cnx; 

        public UserController(RessourceContext context)
        {
            cnx = context;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<USER> Get()
        {
            return cnx.USER.AsQueryable().ToList();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public USER Get(int id)
        {
            return cnx.USER.Where(u => u.idUser == id).First();
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            USER user = new USER();
            user.nom = "moreau";
            user.prenom = "kevin";
            user.email = "kevin2@viacesi.fr";
            user.password = "fezf";
            user.pseudo = "jesuisaurattrapage";
            user.telephone = "0638568545";
            user.isDeleted = false;
            user.isConfirm = false;
            user.idZoneGeo = 1;
            user.idRole = 1;

            cnx.Add(user);
            cnx.SaveChanges();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            USER user = cnx.USER.Where(u => u.idUser == id).First();
            user.isConfirm = true;

            cnx.Update(user);
            cnx.SaveChanges(true);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            USER user = cnx.USER.Where(u => u.idUser == id).First();
            user.isDeleted = true;
            cnx.Update(user);
            cnx.SaveChanges();
        }
    }
}
