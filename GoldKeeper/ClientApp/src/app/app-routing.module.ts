import { NgModule } from '@angular/core';
import { RouterModule, Route } from '@angular/router';
import { ExpenseAddComponent } from './expense/expense-add/expense-add.component';

const appRoutes: Route[] = [
  { path: '', redirectTo: 'expense', pathMatch: 'full' },
  { path: 'expense', component: ExpenseAddComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
