
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmergencyService.Models.Request
{
    public class ActualizarEstadoPacienteRequest
    {
        [Required(ErrorMessage = "Key Obligatorio")]
        public int Key { get; set; }
        [Required(ErrorMessage = "Estado Obligatorio")]
        public EstadoPacienteEnum Estado { get; set; }
    }
}
