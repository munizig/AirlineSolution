import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs/internal/Observable';

const apiURL:string = 'http://localhost:5001/api/'

@Injectable({
  providedIn: 'root'
})
export class BaseService {
  private headers: HttpHeaders;
  private apiUrl: string = '';

  constructor(private httpClient: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  get(url: string, header?: Object): Observable<any> {
    return this.httpClient.get(`${apiURL + url}`, header);
  }
  post<T>(url: string, object: T) {
    return this.httpClient.post(`${apiURL + url}`, object);
  }
  put<T>(url: string, object: T) {
    return this.httpClient.put(`${apiURL + url}`, object);
  }
  delete(url: string, options?: any) {
    if (options) {
      return this.httpClient.delete(`${apiURL + url}`, options);
    } else {
      return this.httpClient.delete(`${apiURL + url}`);
    }
  }
}