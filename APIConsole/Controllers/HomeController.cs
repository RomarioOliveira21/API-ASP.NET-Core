using APIConsole.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIConsole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/<HomeController>
        [HttpGet("bico/{id}")]
        public IActionResult GetAbastecimentoBico(int id)
        {
            AbastecimentoModel model = new();

            List<object> list = model.GetAbastecimentosPorBico(id);

            if (list == null)
            {
                return Ok(new
                {
                    error = true,
                    message = "Não encontramos nada.",
                    code = 1,
                    data = list
                });
            }

            return Ok(new
            {
                error = false,
                message = "Não encontramos nada.",
                code = 0,
                data = list
            });
        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ClienteModel model = new();

            List<object> list = model.GetClientes(id);

            if (list.Count > 0)
            {
                return Ok(new
                {
                    error = false,
                    message = "Dados encontrados com sucesso!",
                    code = 0,
                    data = list
                });
            }
            return Ok(new
            {
                error = true,
                message = "Não encontramos nada.",
                code = 1,
                data = list
            });
        }

        // POST api/<HomeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
