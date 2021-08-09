import { NgxMaskModule } from 'ngx-mask';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app.routes';
import { NavegacaoModule } from './navegacao/navegacao.module';

import { AppComponent } from './app.component';
import { CadastroListaTodosComponent } from './cadastro/listar-todos/cadastro-lista-todos.component';
import { CadastroNovoComponent } from './cadastro/novo/cadastro-novo.component';
import { CadastroExcluirComponent } from './cadastro/excluir/cadastro-excluir.component';
import { CadastroEditarComponent } from './cadastro/editar/cadastro-editar.component';

import { CadastroResolve } from './cadastro/services/cadastro.resolve';
import { CadastroService } from './cadastro/services/cadastro.service';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";
import { TextMaskModule } from 'angular2-text-mask';
import { CustomFormsModule } from 'ng2-validation';
import { NgBrazil } from 'ng-brazil';

@NgModule({
  declarations: [
    AppComponent,       
    CadastroListaTodosComponent, 
    CadastroNovoComponent, 
    CadastroExcluirComponent, 
    CadastroEditarComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    NavegacaoModule,
    HttpClientModule,
    ReactiveFormsModule,
    TextMaskModule,
    NgBrazil,
    CustomFormsModule,    
    AppRoutingModule,
    NgxMaskModule.forRoot({
      dropSpecialCharacters: false
    })    
  ],
  providers: [ 
    CadastroService,
    CadastroResolve
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
