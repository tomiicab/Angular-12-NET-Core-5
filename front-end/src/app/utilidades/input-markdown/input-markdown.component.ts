import { Component, Output } from '@angular/core';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-input-markdown',
  templateUrl: './input-markdown.component.html',
  styleUrls: ['./input-markdown.component.css']
})
export class InputMarkdownComponent {

  contenidoMarkdown: '';

  @Output()
  changeMarkdown: EventEmitter<string> = new EventEmitter<string>();

  inputTextArea(evento){
    this.contenidoMarkdown = evento.target.value;
    this.changeMarkdown.emit(evento.target.value);
  }
}
