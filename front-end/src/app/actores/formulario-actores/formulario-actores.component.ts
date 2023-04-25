import { Component, Input, OnInit, Output } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { EventEmitter } from '@angular/core';
import { actorCreacionDTO, actorDTO } from '../actor';

@Component({
  selector: 'app-formulario-actores',
  templateUrl: './formulario-actores.component.html',
  styleUrls: ['./formulario-actores.component.css']
})
export class FormularioActoresComponent implements OnInit{

  constructor(private formBuilder: UntypedFormBuilder){
  }


  form: UntypedFormGroup;

  @Input()
  modelo: actorDTO;

  @Output()
  OnSubmit: EventEmitter<actorCreacionDTO> = new EventEmitter<actorCreacionDTO>();


  ngOnInit(): void {
    this.form = this.formBuilder.group({
      nombre: ['',
    {
      validators: [Validators.required],
    },
  ],
    fechaNacimiento: '',
    foto: '',
    biografia: ''
    });

    if (this.modelo !== undefined) {
      this.form.patchValue(this.modelo);
    }
  }
  
  archivoSeleccionado(file){
    this.form.get('foto').setValue(file);
  }

  cambioMarkdown(texto: string){
    this.form.get('biografia').setValue(texto);
  }

  onSubmit(){
    this.OnSubmit.emit(this.form.value);
  }
}
