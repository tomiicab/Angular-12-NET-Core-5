import { Component } from '@angular/core';
import { cineCreacionDTO, cineDTO } from '../cine';

@Component({
  selector: 'app-editar-cine',
  templateUrl: './editar-cine.component.html',
  styleUrls: ['./editar-cine.component.css']
})
export class EditarCineComponent {

  constructor(){

  }

  modelo: cineDTO = {nombre: "Sambil", latitud: -31.299281038878025, longitud: -64.2760186731118};

  guardarCambios(cine: cineCreacionDTO){
    console.log(cine);
  }

}
