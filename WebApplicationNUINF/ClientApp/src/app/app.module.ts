import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import { PessoaComponent } from './components/Pessoa/pessoa.component';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpModule,
    //RouterModule.forRoot(
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
