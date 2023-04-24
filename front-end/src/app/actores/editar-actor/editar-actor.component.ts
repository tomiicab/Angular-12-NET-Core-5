import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { actorCreacionDTO, actorDTO } from '../actor';

@Component({
  selector: 'app-editar-actor',
  templateUrl: './editar-actor.component.html',
  styleUrls: ['./editar-actor.component.css']
})
export class EditarActorComponent implements OnInit {

  constructor(private activatedRoute: ActivatedRoute){
  }

  modelo: actorDTO = {nombre: 'Tom Holland', fechaNacimiento: new Date(), 
  foto: 'https://cloudfront-us-east-1.images.arcpublishing.com/infobae/M7XUKQCWSZA6LN4QTEM3X4FX3M.jpg'}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      //alert(params.id);
    })
  }

  guardarCambios(actor: actorCreacionDTO){
    console.log(actor);
  }


}
