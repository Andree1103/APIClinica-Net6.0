using Microsoft.AspNetCore.Mvc;
using WebApiCoreClinica.DAO;
using WebApiCoreClinica.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiCoreClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosAPIController : ControllerBase
    {

        private readonly MedicosDAO dao_medicos;

        public MedicosAPIController(MedicosDAO _dao)
        {
            dao_medicos = _dao;            
        }
        // GET: api/<MedicosAPIController>
        [HttpGet("GetMedicos")]
        public List<Medicos> Get()
        {
            return dao_medicos.ListarMedicos();
        }

        // GET api/<MedicosAPIController>/5
        [HttpGet("GetMedicos/{id}")]
        public Medicos Get(string id)
        {
            Medicos? obj = dao_medicos.ListarMedicos()
                .Find(m => m.codmed.Equals(id));
            return obj;
        }

        // POST api/<MedicosAPIController>
        [HttpPost("AddMedico")]
        public string Post([FromBody] Medicos obj)
        {
            string mensaje = dao_medicos.GrabarMedico(obj);
            return mensaje;
        }

        // PUT api/<MedicosAPIController>/5
        [HttpPut("PutMedico/{id}")]
        public string Put([FromBody] Medicos obj)
        {
            string mensaje = "";
            return mensaje;
        }

        // DELETE api/<MedicosAPIController>/5
        [HttpDelete("DeleteMedicos/{id}")]
        public string Delete(int id)
        {
            string mensaje = "";
            return mensaje;
        }
    }
}
