import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BebidasService } from 'src/app/bebidas.service';
import { Bebida } from 'src/app/Bebida';

@Component({
  selector: 'app-bebidas',
  templateUrl: './bebidas.component.html',
  styleUrls: ['./bebidas.component.css']
})
export class BebidasComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private bebidasService : BebidasService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Nova Bebida';
    this.formulario = new FormGroup({
      id: new FormControl(null),
      nome: new FormControl(null),
      descricao: new FormControl(null),
      preco: new FormControl(null),
    })
  }
  enviarFormulario(): void {
    const bebida : Bebida = this.formulario.value;
    this.bebidasService.cadastrar(bebida).subscribe(result => {
      alert('Bebida inserido com sucesso.');
    })
  } 
}