using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmergencyService.Models
{
    public partial class Paciente
    {
        public int PacienteId { get; set; }
        [MaxLength(12)]

        public string Documento { get; set; }
        [MaxLength(20)]
        public string Nombres { get; set; }
        [MaxLength(20)]
        public string Apellidos { get; set; }
        public long Edad { get; set; }
        [MaxLength(40)]
        public string Direccion { get; set; }
        public bool Sexo { get; set; }
        public decimal Peso { get; set; }
        public long Estatura { get; set; }
        public bool Fumador { get; set; }
        public bool Dieta { get; set; }
        public long PesoEstatura { get; set; }
        public double Prioridad { get; set; }
        public double Riesgo { get; set; }
        public long TiempoFumando { get; set; }
        public EstadoPacienteEnum Estado { get; set; }
    }

    public enum EstadoPacienteEnum
    {
        Pendiente=0,
        Atentido=1
    }
}
