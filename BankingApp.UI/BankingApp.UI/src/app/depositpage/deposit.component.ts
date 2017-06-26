import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { UserService } from '../services/user.service';

@Component({
    selector: 'deposit',
    templateUrl: 'deposit.component.html'
})
export class DepositComponent {
    sum: number;
    answer = '';

    constructor(
        private router: Router,
        private userService: UserService) { }

    deposit() {
        this.userService.depositMoney(this.sum)
            .subscribe(data => {
                this.answer = data;
            });
     }
}