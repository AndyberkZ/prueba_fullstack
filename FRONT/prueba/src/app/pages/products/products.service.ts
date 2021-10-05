import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';

var apiRequests = `${environment.BACKEND_URL}`;
@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  httpHeader = {
    headers: new HttpHeaders({
      'Access-Control-Allow-Origin': '*',
      'Content-Type': 'application/json'
    }),
  };
  constructor(private http: HttpClient) {}

  GetAll(): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-type', 'application/json');

    return this.http.get(apiRequests + '/Producto', this.httpHeader);
  }

  GetById(id:any): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-type', 'application/json');
    headers = headers.set('Access-Control-Allow-Origin', '*');
    

    return this.http.get(apiRequests + '/Producto', {
      headers: headers,
      params: { id: id },
    });
  }

  Create(data:any): Observable<any> {
    console.log('dataaaaaaaaaaa',data);
    
    return this.http.post(apiRequests + '/Producto', data, this.httpHeader);
  }

  Update(data:any): Observable<any> {
    
    return this.http.put(apiRequests + '/Producto', data, this.httpHeader);
  }

  Delete(id:any): Observable<any> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-type', 'application/json');
    headers = headers.set('Access-Control-Allow-Origin', '*');
    
    return this.http.put(apiRequests + '/Producto/' + id, {}, { headers: headers });
  }
}
