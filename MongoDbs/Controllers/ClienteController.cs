using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDbs.Models;
using MongoDbs.Repositories;

namespace MongoDbs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private IClienteCollection db = new ClienteCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            return Ok(await db.GetAllClientes());
        }
        [HttpGet("{id}")]


        public async Task<IActionResult> GetClientes(string id)
        {
            return Ok(await db.GetClienteById(id));
        }

        [HttpPost]

        public async Task<IActionResult> CreateCliente([FromBody] Clientes cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }
            if (cliente.firstName == String.Empty)
            {
                ModelState.AddModelError("Name", "El Campo No Puede Estar Vacio");

            }
            await db.InsertCliente(cliente);
            return Created("Creado", true);
        }

        [HttpPost]

        [HttpPut]

        public async Task<IActionResult> UpdateCliente([FromBody] Clientes cliente, string id)
        {
            if (cliente == null)
            {
                return BadRequest();
            }
            if (cliente.firstName == String.Empty)
            {
                ModelState.AddModelError("Name", "El Campo No Puede Estar Vacio");

            }

            cliente.id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateCliente(cliente);
            return Created("Creado", true);

        }

        [HttpPut]


        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteCliente(string id)
        {
            await db.DeleteCliente(id);
            return NoContent();

        }

        
    } 

}
