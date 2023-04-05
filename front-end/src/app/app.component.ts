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
      
    },500);
  
  } 
  title = 'Hola lo que yo quiera';

  peliculas;
}
