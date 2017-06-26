import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { UserService } from '../services/user.service';

@Component({
    selector: 'withdraw',
    templateUrl: 'withdraw.component.html'
})
export class WithdrawComponent {
    sum: number;
    answer = '';

    constructor(
        private router: Router,
        private userService: UserService) { }

    withdraw() {
        this.userService.withdrawMoney(this.sum)
            .subscribe(data => {
                this.answer = data;
            });
    }
}