import { FormGroup } from '@angular/forms';
import { DisplayMessage, GenericValidator, ValidationMessages } from 'src/app/utils/generic-form-validation';
import { fromEvent, merge, Observable } from 'rxjs';
import { ElementRef } from '@angular/core';

export abstract class FormBaseComponent {
    
    validationMessages: ValidationMessages;
    genericValidator: GenericValidator;
    displayMessage: DisplayMessage = {};
    
    mudancasNaoSalvas: boolean;

    protected configurarMensagensValidacaoBase(validationMessages: ValidationMessages) {
        this.genericValidator = new GenericValidator(validationMessages);
    }

    protected configurarValidacaoFormulario(
            formInputElements: ElementRef[],
            formGroup: FormGroup) {

        let controlBlurs: Observable<any>[] = formInputElements
        .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

        merge(...controlBlurs).subscribe(() => {
          this.validarFormulario(formGroup);
        });
    }

    private validarFormulario(formGroup: FormGroup) {
        this.displayMessage = this.genericValidator.processarMensagens(formGroup);
        this.mudancasNaoSalvas = true;
    }
}