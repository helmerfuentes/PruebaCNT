using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmergencyService.Models.Response
{
    public class ReporteResponse
    {
        public IEnumerable<PacienteResponse> Pacientes { get; set; }
        public string PacienteFumador { get; set; }
        public string PacienteMenorEdad { get; set; }
        public string PacienteMayorEdad { get; set; }
    }
}
