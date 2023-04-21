import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-filtro-peliculas',
  templateUrl: './filtro-peliculas.component.html',
  styleUrls: ['./filtro-peliculas.component.css']
})
export class FiltroPeliculasComponent implements OnInit{

  constructor(private formBuilder: FormBuilder){ }
  
  form: FormGroup;

  generos = [
  {id: 1, nombre: 'Drama'},
  {id:2, nombre: 'Acción'},
  {id:3, nombre: 'Thriller'}];

  peliculas = [
    {titulo: 'Spider-Man: Far From Home', enCines: false, proximosEstrenos: true, generos: [2], 
    poster: 'https://pbs.twimg.com/media/D7M9gyfXoAEnspj.jpg'},
    {titulo: 'Moana', enCines: true, proximosEstrenos: false, generos: [1,2], 
    poster: 'https://temeculablogs.com/wp-content/uploads/2016/11/Screen-Shot-2016-11-18-at-11.49.19-AM-700x1045.png'},
    {titulo: 'Terminator', enCines: false, proximosEstrenos: false, generos: [3], 
    poster: 'https://cdn.shopify.com/s/files/1/0037/8008/3782/products/IMG_2393-441324-237388_3bf8f8de-6f5b-461c-8951-6ca41a2d73ad-297169.jpg?v=1645651651'}
  ];

  peliculasOriginal = this.peliculas;

  formularioOriginal = {
    titulo: '',
    generoId: 0,
    proximosEstrenos: false,
    enCines: false
  };

  ngOnInit(): void {
    this.form = this.formBuilder.group(this.formularioOriginal);

    this.form.valueChanges
        .subscribe(valores => {
          this.peliculas = this.peliculasOriginal;
          this.buscarPeliculas(valores)
        })
  }

  buscarPeliculas(valores: any){
    if (valores.titulo) {
      this.peliculas = this.peliculas.filter(pelicula => pelicula.titulo.indexOf(valores.titulo) !== -1);
    }

    if (valores.generoId !== 0) {
      this.peliculas = this.peliculas.filter(pelicula => pelicula.generos.indexOf(valores.generoId) !== -1);
    }

    if (valores.proximosEstrenos) {
      this.peliculas = this.peliculas.filter(pelicula => pelicula.proximosEstrenos);
    }

    if (valores.enCines) {
      this.peliculas = this.peliculas.filter(pelicula => pelicula.enCines);
    }
  }

  limpiar() {
    this.form.patchValue(this.formularioOriginal);

    }


}
