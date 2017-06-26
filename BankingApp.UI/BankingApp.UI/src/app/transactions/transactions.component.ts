import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { Transaction } from '../models/transaction';
import { UserService } from '../services/user.service';

@Component({
    selector: 'transactions',
    templateUrl: 'transactions.component.html'
})

export class TransactionsComponent implements OnInit {
    transactions: Transaction[] = [];
    name: string;

    constructor(private userService: UserService, private activatedRoute: ActivatedRoute) {
        //this.name = activatedRoute.snapshot.params['name'];
    }

    ngOnInit() {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.name = params['name']
        });
        // get transactions from secure api end point
        this.userService.getTransactions(this.name)
            .subscribe(transactions => {
                this.transactions = transactions;
            });
    }
}