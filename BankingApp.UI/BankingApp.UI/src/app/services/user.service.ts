import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

import { AuthenticationService } from '../services/authentication.service';
import { User } from '../models/user';
import { Transaction } from '../models/transaction';

@Injectable()
export class UserService {
    constructor(
        private http: Http,
        private authenticationService: AuthenticationService) { }

    headers = new Headers({ 'Authorization': 'Bearer ' + this.authenticationService.token });
    options = new RequestOptions({ headers: this.headers });

    //get user information
    getUser(name: string): Observable<User> {

        return this.http.get('/api/users/getuserbyname?name=' + name, this.options)
            .map((response: Response) => response.json())
            .catch((error: any) => { return Observable.throw(error); });
    }

    //deposit
    depositMoney(money: number) {
        const body = JSON.stringify(money);

        return this.http.post('/api/bank/deposit', body, { headers: this.headers })
            .map((res: Response) => res.json().info)
            .catch((error: any) => { return Observable.throw(error); });
    }

    //withdraw
    withdrawMoney(money: number) {
        const body = JSON.stringify(money);

        return this.http.post('/api/bank/withdraw', body, { headers: this.headers })
            .map((res: Response) => res.json().info)
            .catch((error: any) => { return Observable.throw(error); });
    }

    //transfer
    transferMoney(money: number, name: string) {
        this.headers.append('Content-Type', 'application/x-www-form-urlencoded');

        var params = new URLSearchParams();
        params.set('name', name);
        params.set('money', money.toString());

        return this.http.post('/api/bank/transfer', params.toString(), { headers: this.headers })
            .map((res: Response) => res.json().info)
            .catch((error: any) => { return Observable.throw(error); });
    }

    //get user's transactions
    getTransactions(name: string): Observable<Transaction[]> {

        return this.http.get('/api/transactions/get?userName=' + name, this.options)
            .map((response: Response) => response.json())
            .catch((error: any) => { return Observable.throw(error); });
    }
}