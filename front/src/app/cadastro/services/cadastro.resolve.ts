import { UsuarioConfi } from './../models/usuarioConfi';
import { CadastroService } from './cadastro.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';

@Injectable()
export class CadastroResolve implements Resolve<UsuarioConfi> {

    constructor(private cadastroService: CadastroService) {}

    resolve(route: ActivatedRouteSnapshot) {
        let id = parseInt(route.params['id']);   
        return this.cadastroService.obterPorId(id);            
    }
}