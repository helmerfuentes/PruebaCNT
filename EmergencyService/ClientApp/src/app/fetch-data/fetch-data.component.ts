import { Component, Inject, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, NgForm } from '@angular/forms';

export class Paciente{
  documento:string
  nombres:string
  apellidos:String
  direccion:string
  edad:number
  sexo:boolean
  peso:number
  estatura:number
  fumador:boolean
  dieta:boolean
  pesoEstatura:number
  relacionPesoEstatura:number
  tiempoFumando:number
}

export class Response <T>{
  message:string
  state:boolean
  HttpStatusCode:number
  status:number
  code:number
  data:T
}

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  @ViewChild('form', { static: false }) form: NgForm;
  public paciente= new Paciente();
  public mensaje:string=""
  public codigo:number 
  public base:string 
  

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  this.base=baseUrl

    // http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
    //   this.forecasts = result;
    // }, error => console.error(error));
  }

  public onSubmit(form:NgForm){
    console.log(form);
    
    if(form.invalid){
      form.form.markAllAsTouched();
      return;
    }

    this.paciente.peso=  +this.paciente.peso
    this.paciente.tiempoFumando=  +this.paciente.tiempoFumando
    this.paciente.relacionPesoEstatura=  +this.paciente.relacionPesoEstatura
    this.paciente.estatura=  +this.paciente.estatura
    this.paciente.edad=  +this.paciente.edad
    this.paciente.sexo =   (this.paciente.sexo)?true:false
    this.paciente.dieta =  (this.paciente.dieta)?true:false
    this.paciente.fumador=(this.paciente.fumador)?true:false
    
    this.http.post<Response<Paciente>>(`${this.base}api/paciente`,this.paciente)
    .subscribe(res=>{
      this.paciente=new Paciente();
      form.resetForm()
      this.mensaje=res.message
      this.codigo=200
    },err=>{
      console.log(err);
      
      this.mensaje=(err.error.message==undefined) ?"Error en los datos de formulario":err.error.message
      this.codigo=400
    })
    

   
    
  }
}


