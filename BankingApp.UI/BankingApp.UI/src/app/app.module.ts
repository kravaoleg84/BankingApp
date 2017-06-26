import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { routing } from './app.routing';

import { AuthGuard } from './guards/auth.guard';
import { AuthenticationService } from './services/authentication.service';
import { UserService } from './services/user.service'
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { UserPageComponent } from './userpage/userpage.component';
import { DepositComponent } from './depositpage/deposit.component';
import { WithdrawComponent } from './withdrawpage/withdraw.component';
import { TransactionsComponent } from './transactions/transactions.component';
import { NotFoundComponent } from './notfound/notfound.component';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        routing
    ],
    declarations: [
        AppComponent,
        LoginComponent,
        RegisterComponent,
        UserPageComponent,
        DepositComponent,
        WithdrawComponent,
        TransactionsComponent,
        NotFoundComponent
    ],
    providers: [
        AuthGuard,
        AuthenticationService,
        UserService
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }
