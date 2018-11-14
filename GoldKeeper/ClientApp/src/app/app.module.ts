import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { ExpenseAddComponent } from './expense/expense-add/expense-add.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { HttpClientModule } from '@angular/common/http';
import { ExtraCostAddComponent } from './expense/expense-add/extra-cost-add.component';
import { PaymentAddComponent } from './expense/expense-add/payment-add.component';
import { ItemAddComponent } from './expense/expense-add/item-add.component';

@NgModule({
  declarations: [
    AppComponent,
    ExpenseAddComponent,
    HeaderComponent,
    FooterComponent,
    ExtraCostAddComponent,
    PaymentAddComponent,
    ItemAddComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
