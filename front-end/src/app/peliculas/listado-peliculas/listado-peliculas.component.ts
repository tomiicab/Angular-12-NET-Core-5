import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-listado-peliculas',
  templateUrl: './listado-peliculas.component.html',
  styleUrls: ['./listado-peliculas.component.css']
})
export class ListadoPeliculasComponent implements OnInit {

  constructor() { }
  peliculas;
  ngOnInit(): void {
    this.peliculas = [{
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
  }

}
