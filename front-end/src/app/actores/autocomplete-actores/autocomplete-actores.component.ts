import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatTable } from '@angular/material/table';

@Component({
  selector: 'app-autocomplete-actores',
  templateUrl: './autocomplete-actores.component.html',
  styleUrls: ['./autocomplete-actores.component.css']
})
export class AutocompleteActoresComponent implements OnInit{

  control: FormControl = new FormControl();

  actores = [
    {nombre: 'Tom Holland', personaje: '' ,foto: 'https://thumbs.dreamstime.com/z/tom-holanda-holland-en-el-estreno-mundial-de-%E2%80%98spider-man-lejos-del-hogar-%E2%80%98celebrado-teatro-chino-tcl-hollywood-los-e-u-junio-152182771.jpg'},
    {nombre: 'Tom Hanks', personaje: '', foto: 'https://thumbs.dreamstime.com/b/tom-hanks-arrives-premiere-saving-mr-banks-which-being-screened-odeon-leicester-square-as-part-bfi-36047006.jpg'},
    {nombre: 'Samuel jackson', personaje: '', foto: 'https://thumbs.dreamstime.com/b/samuel-l-jackson-en-el-%C2%BA-premio-anual-de-la-academia-celebrado-teatro-dolby-los-angeles-ee-uu-marzo-244305803.jpg'}
  ];
  
  actoresOriginal = this.actores;

  actoresSeleccionados = [];

  columnasAMostrar = ['imagen', 'nombre', 'personaje', 'acciones'];

  @ViewChild(MatTable) table: MatTable<any>;
  
  ngOnInit(): void {
    this.control.valueChanges.subscribe(valor => {
      this.actores = this.actoresOriginal;
      this.actores = this.actores.filter(actor => actor.nombre.indexOf(valor) !== -1);
    });
  }


  optionSelected(event: MatAutocompleteSelectedEvent){
    console.log(event.option.value);
    this.actoresSeleccionados.push(event.option.value);
    this.control.patchValue('');
    if (this.table !== undefined) {
      this.table.renderRows();
    }
  }

  eliminar(actor){
    const indice = this.actoresSeleccionados.findIndex(a => a.nombre == actor.nombre);
    this.actoresSeleccionados.splice(indice, 1);
    this.table.renderRows();
  }

  finalizaArrastre(event: CdkDragDrop<any>){
    const indicePrevio = this.actoresSeleccionados.findIndex(
      actor => actor === event.item.data
    )
    moveItemInArray(this.actoresSeleccionados, indicePrevio, event.currentIndex)
    this.table.renderRows();
  }
}
