using EmergencyService.Aplicattion;
using EmergencyService.Models;
using EmergencyService.Models.Request;
using EmergencyService.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmergencyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly CNTContext _context;
        public PacienteController(CNTContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<PacienteResponse> Add(AgregarPacienteRequest request)
        {
            var res = new PacienteService(_context).Agregar(request);

            return StatusCode(res.Status, res);
        }

        [HttpGet]
        public ActionResult<IEnumerable<PacienteResponse>> GetAll()
        {

            var res = new PacienteService(_context).Reporte();

            return StatusCode(res.Status, res);
        }

        [HttpPut]
        public ActionResult<PacienteResponse> UpdateState(ActualizarEstadoPacienteRequest request)
        {

            var res = new PacienteService(_context).ActualizarEstado(request);

            return StatusCode(res.Status, res);
        }

    }
}
