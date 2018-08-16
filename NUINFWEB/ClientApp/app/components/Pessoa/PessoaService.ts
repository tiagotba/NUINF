// Importing the libraries
import { Injectable } from "@angular/core";
import { Http, Response, Headers } from "@angular/http";
import "rxjs/add/operator/map";
import 'rxjs/add/operator/do';  // debug  
//import { Observable } from "rxjs/Observable";
//import { BehaviorSubject } from 'rxjs/BehaviorSubject';
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
        ///this.baseUrl = 'http://localhost:53901/api/pessoa/';
        this.baseUrl = 'http://localhost:53901/api/';
        this.dataStore = { pessoaList: [] };
        this._pessoaList = <BehaviorSubject<Pessoa[]>>new BehaviorSubject([]);
        this.pessoaList = this._pessoaList.asObservable();
    }

    // Method to get all employees by calling /api/GetAllEmployees
    getAll() {
        this.http.get(`${this.baseUrl}pessoa`)
            .map(response => response.json())
            .subscribe(data => {
                this.dataStore.pessoaList = data;
                // Adding newly added Employee in the list
                this._pessoaList.next(Object.assign({}, this.dataStore).pessoaList);
            }, error => console.log('Could not load employee.'));
    }

}

export class Pessoa {
    public codPessoa: number;
    public nomePessoa: string;
    public emailPessoa: string;
    public cpfPessoa: string;
    public idadePessoa: number;
    public qtdTel: string;
}



