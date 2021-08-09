import { Escolaridade } from './../models/escolaridade';
import { CadastroService } from './../services/cadastro.service';
import { UsuarioConfi } from './../models/usuarioConfi';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cadastro-lista-todos',
  templateUrl: './cadastro-lista-todos.component.html',
  styles: []
})
export class CadastroListaTodosComponent implements OnInit {

  usuarios: UsuarioConfi[];
  escolaridades: Escolaridade[];
  
  errorMessage: string;

  constructor(private cadastroService: CadastroService) { }

  ngOnInit() {
    this.cadastroService.obterTodos()
      .subscribe(
            usuarios => this.usuarios = usuarios,
            error => this.errorMessage = error
    );

    this.cadastroService.obterEscolaridades()
        .subscribe(
          escolaridades => this.escolaridades = escolaridades
    );
  }

  obterDescricaoEscolaridade(id: number) : string {
    let descricao = this.escolaridades.find(e => e.id == id).descricao;

    return descricao;
  }

}
