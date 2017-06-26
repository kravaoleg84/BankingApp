import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { UserService } from '../services/user.service';

@Component({
    selector: 'transfer',
    templateUrl: 'transfer.component.html'
})
export class TransferComponent {
    sum: number;
    name: string;
    answer = '';

    constructor(
        private router: Router,
        private userService: UserService) { }

    transfer() {
        this.userService.transferMoney(this.sum, this.name)
            .subscribe(data => {
                this.answer = data;
            });
    }
}