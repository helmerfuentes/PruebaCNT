import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Response } from '../fetch-data/fetch-data.component';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: ['thead { background-color: #C8DFFD; color: white; }']
})
export class HomeComponent  implements OnInit{
 
  public base:string 
  public reporte:ReporteResponse

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  this.base=baseUrl

    
  }

  ngOnInit(): void {
   this.http.get<Response<ReporteResponse>>(this.base + 'api/paciente').subscribe(result => {
     this.reporte = result.data;
    }, error => console.error(error));
  }

  public atender(item:PacienteResponse){
    this.http.put<Response<PacienteResponse>>(this.base + 'api/paciente',{key:item.key,estado:1}).subscribe(result => {
      
      this.eliminarDatoMemoria(item.key);
    }, error => console.error(error));
  }

  eliminarDatoMemoria(key:number){
    var i=this.reporte.pacientesOrdeRiesgo.filter(x=>x.key!=key);
    var j=this.reporte.pacientesOrdenPrioridad.filter(x=>x.key!=key);

    this.reporte.pacientesOrdeRiesgo=[];
    this.reporte.pacientesOrdenPrioridad=[];
    this.reporte.pacientesOrdeRiesgo=i;
    this.reporte.pacientesOrdenPrioridad=j;
  
  

  }

}


export class PacienteResponse{
  key:number
  Documento:string
  Nombres:string
  //Apellidos = paciente.Apellidos;
  Edad:number
  Direccion:string
  Sexo:string
  Estatura :number
  Fumador:string
  Dieta :string
  PesoEstatura :number
  prioridad :number
  riesgo :number
  TiempoFumando :number
  Estado :string
}

export class ReporteResponse{
pacientesOrdenPrioridad:PacienteResponse[]=[]
pacientesOrdeRiesgo:PacienteResponse[]=[]
pacienteMenorEdad:string
pacienteMayorEdad:string
pacienteFumador:string
}
