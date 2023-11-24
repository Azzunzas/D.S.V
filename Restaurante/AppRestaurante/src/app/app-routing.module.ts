import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BebidasComponent } from './components/bebidas/bebidas.component';

const routes: Routes = [{
  path: 'bebidas', component:BebidasComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }