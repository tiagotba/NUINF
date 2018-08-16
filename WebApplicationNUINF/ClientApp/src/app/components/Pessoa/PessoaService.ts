// Importing the libraries
import { Injectable } from "@angular/core";
import { Http, Response, Headers } from "@angular/http";
//import "rxjs/add/operator/map";
import { map } from 'rxjs/operators';
import 'rxjs/add/operator/do'; // debug
import { Observable } from "rxjs";
import { BehaviorSubject } from 'rxjs';
// To inject the dependancies in the service
@Injectable()
export class PessoaService {
  public pessoaList: Observable<Pessoa[]>;
  private _pessoaList: BehaviorSubject<Pessoa[]>;
  private baseUrl: string;
  private dataStore: {
    pessoaList: Pessoa[];
  };

  //// Constructor to set the values
  constructor(private http: Http) {
    // Base URL for the API
    this.baseUrl = '/api/';
    this.dataStore = { pessoaList: [] };
    this._pessoaList = <BehaviorSubject<Pessoa[]>>new BehaviorSubject([]);
    this.pessoaList = this._pessoaList.asObservable();
  }

  // Traz todas as pessoas de  /api/GetAllPessoas
  getAll() {
    this.http.get(`${this.baseUrl}GetAllPessoas`)
      .pipe(
        map((res: Response) => res.json())
      )
      .subscribe(data => {
        this.dataStore.pessoaList = data;
        // Adiciona as pessoas a lista
        this._pessoaList.next(Object.assign({}, this.dataStore).pessoaList);
      }, error => console.log('Could not load employee.'));
  }

};

export class Pessoa {
  Nome: string;
  Email: string;
  CPF: number;
  Idade: string;
}
