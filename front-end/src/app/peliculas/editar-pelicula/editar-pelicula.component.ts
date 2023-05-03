import { Component } from '@angular/core';
import { PeliculaCreacionDTO, PeliculaDTO } from '../pelicula';

@Component({
  selector: 'app-editar-pelicula',
  templateUrl: './editar-pelicula.component.html',
  styleUrls: ['./editar-pelicula.component.css']
})
export class EditarPeliculaComponent {

  modelo: PeliculaDTO = {titulo: 'Spider-Man', 'trailer': 'abc', enCines: true, resumen: 'cosa',
  fechaLanzamiento: new Date(), poster: 'https://i.pinimg.com/originals/67/ab/44/67ab44275957c1e1528bfef573c0caf7.jpg'};

  guardarCambios(pelicula: PeliculaCreacionDTO){
    console.log(pelicula);
  }
}
