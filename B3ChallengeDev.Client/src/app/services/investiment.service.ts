import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CdbInvestimentReturn } from '../models/cdb-investiment-return.interface';
import { Observable } from 'rxjs';
import { CdbInvestiment } from '../models/cdb-investiment.interface';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class InvestimentService {

  readonly apiUrl = `${environment.api}/api`;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private  httpClient: HttpClient) { }

  CalculateCdbInvestiment(cdbInvestiment : CdbInvestiment): Observable<CdbInvestimentReturn>{
    return this.httpClient.post<CdbInvestimentReturn>(
      `${this.apiUrl}/InvestmentCdb/CalculateCDBReturns`,
      JSON.stringify(cdbInvestiment),
      this.httpOptions
    );
  }
}
