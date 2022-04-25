using EmergencyService.Models;
using EmergencyService.Models.Base;
using EmergencyService.Models.Request;
using EmergencyService.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmergencyService.Aplicattion
{
    public class PacienteService
    {
        private readonly CNTContext _context;
        public PacienteService(CNTContext context)
        {
            _context = context;
        }


        public ResponseGeneric<ReporteResponse> Reporte()
        {
            ReporteResponse response;
            var pacientesEdad = _context.Paciente.ToList().OrderByDescending(x => x.Edad).ToList();
            var pacienteprioridad = pacientesEdad.OrderByDescending(x => x.Prioridad).ToList();
            if (pacientesEdad.Count!=0)
            {
            var menorEdad = pacientesEdad.Last().Nombres + " " + pacientesEdad.Last().Apellidos;
            var mayorEdad = pacientesEdad.First().Nombres + " " + pacientesEdad.First().Apellidos;
            var fumador = pacienteprioridad.Find(x => x.Fumador);
            var mayorPriordidad = fumador!=null? (fumador.Nombres+" " + pacienteprioridad.Find(x => x.Fumador).Apellidos):"No hay pacientes";

                response = new ReporteResponse
                {
                    PacienteFumador = mayorPriordidad,
                    PacienteMayorEdad = mayorEdad,
                    PacienteMenorEdad = menorEdad,
                    PacientesOrdenPrioridad = pacienteprioridad.Select(x => new PacienteResponse(x)),
                    PacientesOrdeRiesgo = pacienteprioridad.Select(x => new PacienteResponse(x)).OrderByDescending(x => x.Riesgo)
                };
            }
            else
            {
                response = new ReporteResponse
                {
                    PacienteFumador = "No hay paciente",
                    PacienteMayorEdad = "No hay paciente",
                    PacienteMenorEdad = "No hay paciente",
                    PacientesOrdenPrioridad = pacienteprioridad.Select(x => new PacienteResponse(x)),
                    PacientesOrdeRiesgo = pacienteprioridad.Select(x => new PacienteResponse(x)).OrderByDescending(x => x.Prioridad)
                };
            }
            
           
                
            return new ResponseGeneric<ReporteResponse>("Petición exitosa", response  , System.Net.HttpStatusCode.OK, false);
        }
        public ResponseGeneric<PacienteResponse> ActualizarEstado(ActualizarEstadoPacienteRequest request)
        {
            var Paciente = _context.Paciente.FirstOrDefault(x => x.PacienteId == request.Key);
            if (Paciente == null)
            {
                return new ResponseGeneric<PacienteResponse>("No se encontro el paciente", null, System.Net.HttpStatusCode.BadRequest, false);
            }

            Paciente.Estado = request.Estado;
            _context.Paciente.Update(Paciente);
            _context.SaveChanges();
            return new ResponseGeneric<PacienteResponse>("Paciente actualizado", new PacienteResponse(Paciente), System.Net.HttpStatusCode.OK, false);
        }

        public ResponseGeneric<PacienteResponse> Agregar(AgregarPacienteRequest request)
        {
            var Paciente = _context.Paciente.FirstOrDefault(x => x.Documento == request.Documento);
            if (Paciente!=null)
            {
                return new ResponseGeneric<PacienteResponse>("Paciente con documento "+request.Documento+" Ya se encuentra registrado", null, System.Net.HttpStatusCode.BadRequest, false);
            }

            if (request.Fumador && request.TiempoFumando==0 )
            {
                return new ResponseGeneric<PacienteResponse>("Debe ingresar cuantos años lleva fumando", null, System.Net.HttpStatusCode.BadRequest, false);
            }

            double prioridad = CalcularPrioridad(request.Edad, request.RelacionPesoEstatura, request.TiempoFumando, request.Fumador, request.Dieta);
            double riesgo = CalcularRiesgo(request.Edad, prioridad);
            
            var paciente = new Paciente
            {
                Apellidos = request.Apellidos,
                TiempoFumando = request.TiempoFumando,
                Documento = request.Documento,
                Dieta = request.Dieta,
                Direccion = request.Direccion,
                Edad = request.Edad,
                Estado = 0,
                Estatura = request.Estatura,
                Fumador = request.Fumador,
                Nombres = request.Nombres,
                Peso = request.Peso,
                PesoEstatura = request.PesoEstatura,
                Sexo = request.Sexo,
                Prioridad = prioridad,
                Riesgo = riesgo,
            };

            _context.Add(paciente);
            _context.SaveChanges();

            return new ResponseGeneric<PacienteResponse>("Paciente agregado", new PacienteResponse(paciente), System.Net.HttpStatusCode.OK, false);

        }

        private double CalcularPrioridad(int edad,int relacionPesoEstatura,long tiempoFumando,bool fumador,bool dieta)
        {
            if (edad <= 5) return relacionPesoEstatura + 3;
            else if (edad > 5 && edad <= 12) return relacionPesoEstatura + 2;
            else if (edad > 12 && edad <= 15) return relacionPesoEstatura + 1;
            else if (edad > 15 && edad <= 40) return fumador ? (int)(tiempoFumando / 4 + 2) : 2;
            else return (dieta && edad >= 60 && edad <= 100) ? edad / 20 + 4 : edad / 30 + 3;

        }

        private double CalcularRiesgo(int edad, double prioridad)
        {
            return (edad <= 40) ? (edad * prioridad) / 100 : (edad * prioridad) / 100 + 5.3;
           
        }


    }
}
