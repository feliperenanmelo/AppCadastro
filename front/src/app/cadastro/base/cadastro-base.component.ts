import { UsuarioConfi } from '../models/usuarioConfi';
import { FormGroup } from '@angular/forms';
import { MASKS } from 'ng-brazil';
import { ElementRef } from '@angular/core';
import { FormBaseComponent } from 'src/app/utils/form-base.component';
import { Escolaridade } from '../models/escolaridade';


export abstract class CadastroBaseComponent extends FormBaseComponent {    
    
    escolaridades: Escolaridade[];
    usuario: UsuarioConfi;
    errors: any[] = [];
    cadastroForm: FormGroup;

    MASKS = MASKS;

    constructor() {

        super();

        this.validationMessages = {            
            nome: {
                required: 'Informe o Nome',
                minlength: 'Mínimo de 2 caracteres',
                maxlength: 'Máximo de 200 caracteres'
            },
            sobrenome: {
                required: 'Informe o sobrenome',
                minlength: 'Mínimo de 2 caracteres',
                maxlength: 'Máximo de 200 caracteres'
            },
            email: {
                required: 'Informe o email',
                minlength: 'Mínimo de 2 caracteres',
                maxlength: 'Máximo de 200 caracteres',
                email: "Email inválido"
            },
            dataNascimento: {
                required: 'Informe a data de nascimento',
            },
            escolaridade: {
                required: 'Escolha uma escolaridade',
            },
        };    

        super.configurarMensagensValidacaoBase(this.validationMessages);
    }    

    protected configurarValidacaoFormulario(formInputElements: ElementRef[]) {
        super.configurarValidacaoFormulario(formInputElements, this.cadastroForm);
    }
}