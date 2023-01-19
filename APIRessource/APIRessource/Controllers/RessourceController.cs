using APIRessource.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return cnx.RESSOURCE.AsQueryable().ToList();
        }

        // GET api/<RessourceController>/5
        [HttpGet("{id}")]
        public RESSOURCE Get(int id)
        {
            return cnx.RESSOURCE.Where(r => r.id == id).First();
        }

        // POST api/<RessourceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RessourceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RessourceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
