using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmergencyService.Models.Response
{
    public class PacienteResponse 
    {
        public int key { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public long Edad { get; set; }
        public string Direccion { get; set; }
        public string Sexo { get; set; }
        public decimal Peso { get; set; }
        public long Estatura { get; set; }
        public string Fumador { get; set; }
        public string Dieta { get; set; }
        public long PesoEstatura { get; set; }
        public double Prioridad { get; set; }
        public double Riesgo { get; set; }
        public long TiempoFumando { get; set; }
        public string Estado { get; set; }

        public PacienteResponse(Paciente paciente)
        {
            this.key = paciente.PacienteId;
            Documento = paciente.Documento;
            Nombres = paciente.Nombres+ ""+ paciente.Apellidos;
            //Apellidos = paciente.Apellidos;
            Edad = paciente.Edad;
            Direccion = paciente.Direccion;
            Sexo=paciente.Sexo?"Mujer":"Hombre";
            Estatura = paciente.Estatura;
            Fumador = (bool)paciente.Fumador ? "Si" : "No";
            Dieta = paciente.Dieta ? "Si" : "No";
            PesoEstatura = paciente.PesoEstatura;
            Prioridad = (double)paciente.Prioridad;
            Riesgo = (double)paciente.Riesgo;
            TiempoFumando = paciente.TiempoFumando;
            Estado = paciente.Estado == 0 ? "Pendiente" : "Atendido";

        }
    }
}
