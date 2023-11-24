import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';

import { BebidasService } from './bebidas.service';
import { BebidasComponent } from './components/bebidas/bebidas.component';

import { FuncionariosService } from './funcionarios.service';
import { FuncionariosComponent } from './components/funcionarios/funcionarios.component';

import { MesasService } from './mesas.service';
import { MesasComponent } from './components/mesas/mesas.component';

import { PagamentosService } from './pagamentos.service';
import { PagamentosComponent } from './components/pagamentos/pagamentos.component';

import { PratosService } from './pratos.service';
import { PratosComponent } from './components/pratos/pratos.component';

import { RetiradasService } from './retiradas.service';
import { RetiradasComponent } from './components/retiradas/retiradas.component';

import { UsuariosService } from './usuarios.service';
import { UsuariosComponent } from './components/usuarios/usuarios.component';

import { VeiculosService } from './veiculos.service';
import { VeiculosComponent } from './components/veiculos/veiculos.component';

@NgModule({
    declarations:[
        AppComponent,
        BebidasComponent,
        FuncionariosComponent,
        MesasComponent,
        PagamentosComponent,
        PratosComponent,
        RetiradasComponent,
        UsuariosComponent,
        VeiculosComponent
    ],
    imports:[
        BrowserModule,
        AppRoutingModule,
        CommonModule,
        HttpClientModule,
        ReactiveFormsModule,
        ModalModule.forRoot()
    ],
    providers:[HttpClientModule, BebidasService,FuncionariosService,MesasService,PagamentosService,PratosService,RetiradasService,UsuariosService,VeiculosService],
    bootstrap:[AppComponent]
})
export class AppModule{ }