import { Component, OnInit } from '@angular/core';
import 'rxjs/add/operator/catch';
import { Observable } from "rxjs";
import { PessoaService } from "./PessoaService";
import { Pessoa } from "./PessoaService";
import { Router } from '@angular/router';

@Component({
    selector: 'Pessoa',
    providers: [PessoaService],
    templateUrl: './pessoa.component.html'
})

export class PessoaComponent implements OnInit {
    public pessoaList: Observable<Pessoa[]> | undefined;
    showEditor = true;
    myName: string ;
    pessoa: Pessoa;
    constructor(private dataService: PessoaService) {
        this.pessoa = new Pessoa();
    }

    ngOnInit() {
        // if you want to debug info just uncomment the console.log lines.
        // console.log("You are in ngOnInit");
        this.pessoaList = this.dataService.pessoaList;
        this.dataService.getAll();
    }

    public addPessoa(item: Pessoa) {
        let employeeId = this.dataService.addPessoa(this.pessoa);
    }
    public updatePessoa(item: Pessoa) {
        this.dataService.updatePessoa(item);
    }
    public deletePessoa(pessoaId: number) {
        this.dataService.removeItem(pessoaId);
    }
}
