import { Router, ActivatedRoute } from '@angular/router';
import { CadastroService } from './../services/cadastro.service';
import { Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormControlName, FormBuilder, Validators } from '@angular/forms';
import { CadastroBaseComponent } from '../base/cadastro-base.component';

@Component({
  selector: 'app-cadastro-editar',
  templateUrl: './cadastro-editar.component.html',
  styles: []
})
export class CadastroEditarComponent extends CadastroBaseComponent implements OnInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];
  
  constructor(private fb: FormBuilder,
    private cadastroService: CadastroService,
    private router: Router,
    private route: ActivatedRoute) 
    {
      super();
      this.usuario = this.route.snapshot.data['usuario'];
    }

  ngOnInit() {
    this.cadastroService.obterEscolaridades()
      .subscribe(
        escolaridade => this.escolaridades = escolaridade            
    );

    this.cadastroForm = this.fb.group({      
      nome: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(200)]],
      sobrenome: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(200)]],
      email: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(200), Validators.email]],
      dataNascimento: ['', [Validators.required]],
      escolaridade: ['', [Validators.required]]      
    });

    this.cadastroForm.patchValue({
      id: this.usuario.id,
      nome: this.usuario.nome,
      sobrenome: this.usuario.sobrenome,
      email: this.usuario.email,
      dataNascimento: this.usuario.dataNascimento,
      escolaridade: this.usuario.escolaridade
    });
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormulario(this.formInputElements);
  }

  editarCadastro() {
    if (this.cadastroForm.dirty && this.cadastroForm.valid) {
      this.usuario = Object.assign({}, this.usuario, this.cadastroForm.value);

      this.usuario.escolaridade = parseInt(this.usuario.escolaridade.toString());

      this.cadastroService.atualizarCadastro(this.usuario)
          .subscribe(
            sucesso => { this.processarSucesso(sucesso) },
            falha => { this.processarFalha(falha) }
          );

      this.mudancasNaoSalvas = false;
    }
  }

  processarSucesso(response: any) {
    this.cadastroForm.reset();
    this.errors = [];    
  
    this.router.navigate(['/cadastro/listar-todos']);
  }

  processarFalha(fail: any) {
    this.errors = fail.error.errors;    
  } 

}
