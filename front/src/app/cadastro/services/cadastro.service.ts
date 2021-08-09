import { BaseService } from "src/app/services/base.service";

import { Escolaridade } from './../models/escolaridade';
import { UsuarioConfi } from './../models/usuarioConfi';

import { catchError, map } from 'rxjs/operators';
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";


@Injectable()
export class CadastroService extends BaseService {

    constructor(private http: HttpClient) { super() }

    obterEscolaridades(): Observable<Escolaridade[]> {
        return this.http
            .get<Escolaridade[]>(this.UrlServiceV1 + "escolaridade/obter-todos", super.obterHeaderJson())        
            .pipe(catchError(super.serviceError));
    }

    obterTodos(): Observable<UsuarioConfi[]> {
        return this.http
            .get<UsuarioConfi[]>(this.UrlServiceV1 + "usuario/obter-todos", super.obterHeaderJson())
            .pipe(catchError(super.serviceError));
    }

    obterPorId(id: number): Observable<UsuarioConfi> {
        return this.http
            .get<UsuarioConfi>(this.UrlServiceV1 + "usuario/" + id, super.obterHeaderJson())
            .pipe(catchError(super.serviceError));
    }

    novoCadastro(usuario: UsuarioConfi): Observable<UsuarioConfi> {
        return this.http
            .post(this.UrlServiceV1 + "usuario", usuario, super.obterHeaderJson())
            .pipe(
                map(super.extractData),
                catchError(super.serviceError));
    }

    atualizarCadastro(usuario: UsuarioConfi): Observable<UsuarioConfi> {
        return this.http
            .put(this.UrlServiceV1 + "usuario/" + usuario.id, usuario, super.obterHeaderJson())
            .pipe(
                map(super.extractData),
                catchError(super.serviceError));
    }

    excluirCadastro(id: number): Observable<UsuarioConfi> {
        return this.http
            .delete(this.UrlServiceV1 + "usuario/" + id, super.obterHeaderJson())
            .pipe(
                map(super.extractData),
                catchError(super.serviceError));
    }       
}
