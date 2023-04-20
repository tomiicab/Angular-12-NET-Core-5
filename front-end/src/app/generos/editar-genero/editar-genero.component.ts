import { Component } from '@angular/core';
import { generoCreacionDTO } from '../genero';
import { Router } from '@angular/router';

@Component({
  selector: 'app-editar-genero',
  templateUrl: './editar-genero.component.html',
  styleUrls: ['./editar-genero.component.css']
})
export class EditarGeneroComponent {

  constructor(private router: Router){}

  modelo: generoCreacionDTO = {nombre: 'Drama'};

  guardarCambios(genero: generoCreacionDTO){
    console.log(genero);
    //guardar cambios..
    this.router.navigate(['/generos']);
  }
}
