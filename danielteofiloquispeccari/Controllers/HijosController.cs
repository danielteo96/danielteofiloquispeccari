using Business;
using Entity.result;
using Microsoft.AspNetCore.Mvc;

namespace danielteofiloquispeccari.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HijosController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<HijosController> _logger;

        public HijosController(ILogger<HijosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Hijos> Get()
        {
            HijosB cotizacionB = new HijosB();
            List<Hijos> listobj =   cotizacionB.Listarhijos();
            return listobj;
        }
        [HttpPost]
        public Hijos post(Hijos body)
        {
        
            HijosB cotizacionB = new HijosB();
            Hijos hijos = cotizacionB.insertarhijos(body);
            return hijos;
        }
        [HttpPut]
        public Hijos put(Hijos body)
        {

            HijosB cotizacionB = new HijosB();
            Hijos hijos = cotizacionB.actualizarhijos(body);
            return hijos;
        }
        [HttpDelete]
        public void delete(int idhijo)
        {
            HijosB hijosB = new HijosB();
            hijosB.eliminarhijos(idhijo);
           
        }
    }
}

public class Hijosnn
{

    public int idHijo { get; set; }
    public string Name { get; set; }
    public DateTime FechaNacimiento { get; set; }
}