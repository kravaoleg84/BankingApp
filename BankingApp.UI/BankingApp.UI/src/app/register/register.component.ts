import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from '../services/authentication.service'

@Component({
    selector: 'register',
    templateUrl: 'register.component.html'
})
export class RegisterComponent {
    model: any = {};
    loading = false;
    error = '';

    constructor(
        private router: Router,
        private authService: AuthenticationService) { }

    ngOnInit() {
        this.authService.logout();
    }

    register() {
        this.loading = true;
        this.authService.register(this.model.username, this.model.password, this.model.confirmPassword)
            .subscribe(result => {
                if (result === true) {
                    this.router.navigate(['']);
                } else {
                    this.error = 'Username or password is incorrect';
                    this.loading = false;
                }
            });
    }
}