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

    public addPessoa(pessoa: Pessoa) {
       // console.log("add Employee");
        var headers = new Headers();
        headers.append('Content-Type', 'application/json; charset=utf-8');
        console.log('add Employee : ' + JSON.stringify(pessoa));


        this.http.post(`${this.baseUrl}pessoa/`, JSON.stringify(pessoa), { headers: headers })
            .map(response => response.json()).subscribe(data => {
                this.dataStore.pessoaList.push(data);
                this._pessoaList.next(Object.assign({}, this.dataStore).pessoaList);
            }, error => console.log('Could not create Pessoa.'));
    };

    public updatePessoa(newPessoa: Pessoa) {
        console.log("update Pessoa");
        var headers = new Headers();
        headers.append('Content-Type', 'application/json; charset=utf-8');
        console.log('Update Employee : ' + JSON.stringify(newPessoa));


        this.http.put(`${this.baseUrl}pessoa/`, JSON.stringify(newPessoa), { headers: headers })
            .map(response => response.json()).subscribe(data => {
                alert("hi");
                this.dataStore.pessoaList.forEach((t, i) => {
                    if (t.codPessoa === data.id) { this.dataStore.pessoaList[i] = data; }
                });
            }, error => console.log('Could not update Employee.'));
    };

    removeItem(pessoaId: number) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json; charset=utf-8');
        console.log("removeItem:" + pessoaId);
        var ans = confirm("Deseja remover o registro?  " + pessoaId);
        if (ans)
        {
            this.http.delete(`${this.baseUrl}DeleteEmployee/${pessoaId}`, { headers: headers }).subscribe(response => {
                this.dataStore.pessoaList.forEach((t, i) => {
                    if (t.codPessoa === pessoaId) { this.dataStore.pessoaList.splice(i, 1); }
                });

                this._pessoaList.next(Object.assign({}, this.dataStore).pessoaList);
            }, error => console.log('Não foi possivel deletar a Pessoa.'));
        }
        
    };

    getPessoaById(id: number) {
        return this.http.get(this.baseUrl + "pessoa/" + id)
            .map((response: Response) => response.json())
            .catch(this._serverError)
    }

    private _serverError(err: any) {
        console.log('sever errorOK:', err);  // debug  
        if (err instanceof Response) {
            return Observable.throw(err.json().error || 'backend server error');
            // if you're using lite-server, use the following line  
            // instead of the line above:  
            //return Observable.throw(err.text() || 'backend server error');  
        }
        return Observable.throw(err || 'backend server error');
    } 

}

export class Pessoa {
    public codPessoa: number;
    public nomePessoa: string;
    public emailPessoa: string;
    public cpfPessoa: string;
    public dtNascimento: Date;
    public idadePessoa: number;
    public qtdTel: string;
}



