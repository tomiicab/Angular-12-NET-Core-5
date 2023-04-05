import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
//esta clase AppComponent se exporta al html, podemos acceder con pelicula.
  //tipo json
//ngOnInit permite ejecutar un metodo o funcion antes que el component se inicialice.
export class AppComponent implements OnInit{
  ngOnInit(): void {

    setTimeout(() => {
      this.peliculasEnCines = [{
        titulo : 'Spider Man - Far From Home',
        fechaLanzamiento : new Date(),
        precio:1400.99
      },
      {
        titulo : 'Moana',
        fechaLanzamiento : new Date('2010-10-12'),
        precio:400.99
      },
      {
        titulo : 'Terminator',
        fechaLanzamiento : new Date('2015-11-07'),
        precio:111.99
      }]
    },3000);
  
  } 
  title = 'Hola lo que yo quiera';

  peliculasEnCines;

  peliculasEstrenos =[];
}
