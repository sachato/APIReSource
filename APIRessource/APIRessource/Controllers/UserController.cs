using APIRessource.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIRessource.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RessourceContext cnx;
        private JsonSerializerOptions jsonserializeroptions = new System.Text.Json.JsonSerializerOptions();

        public UserController(RessourceContext context)
        {
            cnx = context;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<USER> Get()
        {
            var test = new List<USER>();
            try
            {
                test = cnx.USER.ToList();
            }
            catch(Exception ex)
            {
                var stop = "hgflk";
            }
            return test;

        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public USER Get(int id)
        {
            return cnx.USER.Include(u => u.ZONE_GEO).Include(u => u.ROLE).Where(u => u.idUser == id).FirstOrDefault();
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] USER user)
{
            //USER user = JsonSerializer.Deserialize<USER>(value);
            //USER user = new USER();
            /*user.nom = "moreau";
            user.prenom = "kevin";
            user.email = "kevin2@viacesi.fr";
            user.password = "fezf";
            user.pseudo = "jesuisaurattrapage";
            user.telephone = "0638568545";
            user.isDeleted = false;
            user.isConfirm = false;
            user.zone_geo = new ZONE_GEO();
            user.role = new ROLE();*/
            user.dateCreation = DateTime.Now;
            user.isConfirm = false;
            user.isDeleted = false;
            user.ZONE_GEO = cnx.ZONE_GEO.Where(zg => zg.idZoneGeo == user.idZoneGeo).FirstOrDefault();
            user.ROLE = cnx.ROLE.Where(r => r.idRole == 1).FirstOrDefault();
            cnx.Add(user);
            cnx.SaveChanges();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]bool confirmation)
        {
            USER user = cnx.USER.Where(u => u.idUser == id).First();
            user.isConfirm = confirmation;

            cnx.Update(user);
            cnx.SaveChanges();
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
