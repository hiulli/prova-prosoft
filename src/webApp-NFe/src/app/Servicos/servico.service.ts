import { HttpClient, HttpHeaders } from '@angular/common/http';
import { urlapi } from '../../environments/environment';
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};

@Injectable()
export class ServicoService {

    constructor(private http: HttpClient) { }

    public obtemTodosOsLogs(): Observable<any> {
        return this.http.get(`${urlapi}/NFe/log-processamento`, httpOptions);
    }

    public obtemDadosRelatorio(): Observable<any> {
        return this.http.get(`${urlapi}/relatorio/valorproduto-valorimposto-por-marca/11`, httpOptions);
    }

    public obtemComparativo(): Observable<any> {
        return this.http.get(`${urlapi}/NFe/alteracao-pos-processamento`, httpOptions);
    }
}