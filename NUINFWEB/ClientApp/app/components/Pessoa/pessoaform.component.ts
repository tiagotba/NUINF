import { Component, OnInit } from '@angular/core';
import 'rxjs/add/operator/catch';
import { Observable } from "rxjs";
import { PessoaService } from "./PessoaService";
import { Pessoa } from "./PessoaService";
import { Router, ActivatedRoute } from '@angular/router';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { PessoaComponent } from '../Pessoa/pessoa.component';


@Component({
    selector: 'PessoaForm',
    providers: [PessoaService],
    templateUrl: './pessoaform.component.html'
})

export class PessoaFormComponent implements OnInit {
    employeeForm: FormGroup;
    title: string = "Cadastro";
    id: number;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _pessoaService: PessoaService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }

        this.employeeForm = this._fb.group({
            id: 0,
            nomePessoa: ['', [Validators.required]],
            cpf: ['', [Validators.required]],
            emailPessoa: ['', [Validators.required]],
            dtNascimento: ['', [Validators.required]]
        })
    }

    ngOnInit() {
        if (this.id > 0) {
            this.title = "Editar";
            this._pessoaService.getPessoaById(this.id)
                .subscribe(resp => this.employeeForm.setValue(resp)
                    , error => this.errorMessage = error);
        }
    }

    save() {

        if (!this.employeeForm.valid) {
            return;
        }

        if (this.title == "Create") {
            this._pessoaService.addPessoa(this.employeeForm.value);
                //.subscribe((data) => {
                //    this._router.navigate(['/fetch-employee']);
                //}, error => this.errorMessage = error)
        }
        else if (this.title == "Edit") {
            this._pessoaService.updatePessoa(this.employeeForm.value);
                //.((data) => {
                //    this._router.navigate(['/fetch-employee']);
                //}, error => this.errorMessage = error)
        }
    }

    get nomePessoa() { return this.employeeForm.get('nomePessoa'); }
    get cpf() { return this.employeeForm.get('cpfPessoa'); }
    get emailPessoa() { return this.employeeForm.get('emailPessoa'); }
    get dtNascimento() { return this.employeeForm.get('dtNascimento'); }
}

