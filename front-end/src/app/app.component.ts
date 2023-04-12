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
        precio:1400.99,
        poster:'https://pbs.twimg.com/media/D7M9gyfXoAEnspj.jpg'
      },
      {
        titulo : 'Moana',
        fechaLanzamiento : new Date('2010-10-12'),
        precio:400.99,
        poster: 'https://temeculablogs.com/wp-content/uploads/2016/11/Screen-Shot-2016-11-18-at-11.49.19-AM-700x1045.png'
      },
      {
        titulo : 'Terminator',
        fechaLanzamiento : new Date('2015-11-07'),
        precio:111.99,
        poster: 'https://cdn.shopify.com/s/files/1/0037/8008/3782/products/IMG_2393-441324-237388_3bf8f8de-6f5b-461c-8951-6ca41a2d73ad-297169.jpg?v=1645651651'
      }]
    }, 500);
  
  } 
  title = 'Valor que yo quiera';
  ocultar = false;
  peliculasEnCines;

  peliculasEstrenos =[];

  manejarRated(voto: number):void{
    alert(voto);
  }

  inputTextArea(evento) {
    this.title =  evento.target.value;
  }
}
