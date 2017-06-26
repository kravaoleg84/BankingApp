import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { UserPageComponent } from './userpage/userpage.component';
import { DepositComponent } from './depositpage/deposit.component';
import { WithdrawComponent } from './withdrawpage/withdraw.component';
import { TransactionsComponent } from './transactions/transactions.component';
import { NotFoundComponent } from './notfound/notfound.component';
import { AuthGuard } from './guards/auth.guard';

const appRoutes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'deposit', component: DepositComponent },
    { path: 'withdraw', component: WithdrawComponent },
    { path: 'transactions/:name', component: TransactionsComponent },
    { path: '', component: UserPageComponent, canActivate: [AuthGuard] },
    { path: '**', component: NotFoundComponent }
];

export const routing = RouterModule.forRoot(appRoutes);