using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmergencyService.Models.Request
{
    public class AgregarPacienteRequest
    {

        [Required(ErrorMessage = "Documento Obligatorio")]
        public string Documento { get; set; }
        [Required(ErrorMessage = "Nombres Obligatorio")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Apellidos Obligatorio")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Edad Obligatorio")]
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public bool Sexo { get; set; }
        [Required(ErrorMessage = "Peso Obligatorio")]
        public int Peso { get; set; }   
        [Required(ErrorMessage = "Estatura Obligatorio")]
        public int Estatura { get; set; }
        public bool Fumador { get; set; }
        public bool Dieta { get; set; }
        public int PesoEstatura { get; set; }
        [Range(0,4,ErrorMessage ="El valor campo esta entre 0 y 4")]
        public int RelacionPesoEstatura { get; set; }
        public long TiempoFumando { get; set; }

    }
}
