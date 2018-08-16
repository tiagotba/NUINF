import { Component, OnInit } from '@angular/core';
import 'rxjs/add/operator/catch';
import { Observable } from "rxjs";
import { PessoaService } from "./PessoaService";
import { Pessoa } from "./PessoaService";

@Component({
  selector: 'Pessoa',
  providers: [PessoaService],
  templateUrl: './pessoa.component.html'
})

export class PessoaComponent implements OnInit {
  public pessoaList: Observable<Pessoa[]>;
  showEditor = true;
  myName: string;
  employee: Pessoa;
  constructor(private dataService: PessoaService) {
    this.employee = new Pessoa();
  }

  ngOnInit() {
    // if you want to debug info just uncomment the console.log lines.
    // console.log("You are in ngOnInit");
    this.pessoaList = this.dataService.pessoaList;
    this.dataService.getAll();
  }
}
