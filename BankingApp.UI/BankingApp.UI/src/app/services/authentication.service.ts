import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

@Injectable()
export class AuthenticationService {
    public token: string;

    constructor(private http: Http) {
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        this.token = currentUser && currentUser.token;
    }


    //login
    login(username: string, password: string): Observable<boolean> {
        return this.http.post('/api/account/signin', JSON.stringify({ username: username, password: password }))
            .map((response: Response) => {
                let token = response.json() && response.json().token;
                if (token) {
                    this.token = token;

                    localStorage.setItem('currentUser', JSON.stringify({ username: username, token: token }));

                    return true;
                } else {
                    return false;
                }
            });
    }

    //register
    register(username: string, password: string, confirmPassword: string): Observable<boolean> {
        return this.http.post('/api/account/signup', JSON.stringify({
            username: username, password: password, confirmpassword: confirmPassword
        }))
            .map((response: Response) => {
                let token = response.json() && response.json().token;
                if (token) {
                    this.token = token;

                    localStorage.setItem('currentUser', JSON.stringify({ username: username, token: token }));

                    return true;
                } else {
                    return false;
                }
            });
    }

    //logout
    logout(): void {
        this.token = null;
        localStorage.removeItem('currentUser');
    }
}