import { Component, OnInit } from '@angular/core';

import { User } from '../models/user';
import { UserService } from '../services/user.service';

@Component({
    selector: 'userpage',
    templateUrl: 'userpage.component.html'
})

export class UserPageComponent implements OnInit {
    user: User = new User();
    savedUser = JSON.parse(localStorage.getItem("currentUser"));
    name: string = this.savedUser.username;

    constructor(private userService: UserService) { }

    ngOnInit() {
        // get user from secure api end point
        this.userService.getUser(name)
            .subscribe(user => {
                this.user = user;
            });
    }
}