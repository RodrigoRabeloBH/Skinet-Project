import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Address } from 'cluster';
import { of, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { User } from '../shared/Models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = environment.apiUrl;
  private currentUser = new ReplaySubject<User>(1);
  currentUser$ = this.currentUser.asObservable();

  constructor(private http: HttpClient, private router: Router) { }

  loadCurrentUser(token: string) {

    if (token === null) {
      this.currentUser.next(null);
      return of(null);
    }
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${token}`);
    return this.http.get(this.baseUrl + 'account', { headers }).pipe(
      map((user: User) => {
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUser.next(user);
        }
      })
    )
  }

  login(model: any) {
    return this.http.post(this.baseUrl + 'account/login', model).pipe(
      map((user: User) => {
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUser.next(user);
        }
      })
    )
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'account/register', model).pipe(
      map((user: User) => {
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUser.next(user);
        }
      })
    )
  }

  logout() {
    localStorage.removeItem('token');
    this.currentUser.next(null);
    this.router.navigateByUrl('/');
  }

  checkEmailExists(email: string) {
    return this.http.get(this.baseUrl + 'account/emailexists?email=' + email);
  }

  getUserAddress() {
    return this.http.get(this.baseUrl + 'account/address');
  }

  updateUserAddress(address: Address) {
    return this.http.put(this.baseUrl + 'account/address', address);
  }
}
