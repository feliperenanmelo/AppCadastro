import { CadastroResolve } from './cadastro/services/cadastro.resolve';
import { CadastroExcluirComponent } from './cadastro/excluir/cadastro-excluir.component';
import { CadastroEditarComponent } from './cadastro/editar/cadastro-editar.component';
import { CadastroNovoComponent } from './cadastro/novo/cadastro-novo.component';
import { CadastroListaTodosComponent } from './cadastro/listar-todos/cadastro-lista-todos.component';
import { NotFoundComponent } from './navegacao/not-found/not-found.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const rootRouterConfig: Routes = [
    { path: '', redirectTo: 'cadastro/listar-todos', pathMatch: 'full'},             
    { path: 'cadastro/listar-todos', component: CadastroListaTodosComponent},        
    { path: 'cadastro/novo', component: CadastroNovoComponent},        
    { 
        path: 'cadastro/editar/:id', component: CadastroEditarComponent,
        resolve: {
            usuario: CadastroResolve
        }    
    }, 
    { 
        path: 'cadastro/excluir/:id', component: CadastroExcluirComponent,        
        resolve: {
            usuario: CadastroResolve
        }
    } ,
    { path: '**', component: NotFoundComponent},
];

@NgModule({
    imports:[
        RouterModule.forRoot(rootRouterConfig, { enableTracing: true })
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule{}