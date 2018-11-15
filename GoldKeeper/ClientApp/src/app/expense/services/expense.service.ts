import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ExpensePostModel } from '../models/expense-add.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ProductSelectModel } from '../models/product-select.model';
import { PaymentMethodSelectModel } from '../models/payment-method-select.model';
import { CompanySelectModel } from '../models/company-select.model';

@Injectable({
  providedIn: 'root'
})
export class ExpenseService {
  constructor(private http: HttpClient) {
  }

  getCompanies(): Observable<Array<CompanySelectModel>> {
    return this.http.get<Array<CompanySelectModel>>(`${environment.api}/company`);
  }

  getPaymentMethods(): Observable<Array<PaymentMethodSelectModel>> {
    return this.http.get<Array<PaymentMethodSelectModel>>(`${environment.api}/paymentmethod`);
  }

  getProducts(): Observable<Array<ProductSelectModel>> {
    return this.http.get<Array<ProductSelectModel>>(`${environment.api}/product`);
  }

  post(expense: ExpensePostModel): Observable<ExpensePostModel> {
    return this.http.post<ExpensePostModel>(`${environment.api}/expense`, expense);
  }
}
