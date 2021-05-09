import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { User } from './user'; 

var httpOptions = { headers: new HttpHeaders({ "Content-Type": "application/json" }) };

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  url = 'http://localhost:55571/api/Login';
  constructor(private http: HttpClient) { }

  GetTokenAccess(user: User): Observable<User> {    
    var teste = this.http.post<User>(this.url, user, httpOptions).pipe(
      retry(2),
      catchError(this.handleError)
    );   
    

    let _User = new Observable<User>();
    return _User
  }

  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Erro ocorreu no lado do client
      errorMessage = error.error.message;
    } else {
      // Erro ocorreu no lado do servidor
      errorMessage = `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
    }
    console.log(errorMessage);
    alert(errorMessage);
    return throwError(errorMessage);
  };
}
