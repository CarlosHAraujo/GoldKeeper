import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ExpensePostModel } from '../models/expense-add.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ProductSelectModel } from '../models/product-select.model';

@Injectable({
  providedIn: 'root'
})
export class ExpenseService {

  constructor(private http: HttpClient) {
  }

  getProducts(): Observable<Array<ProductSelectModel>> {
    return this.http.get<Array<ProductSelectModel>>(`${environment.api}/product`);
  }

  post(expense: ExpensePostModel): Observable<ExpensePostModel> {
    return this.http.post<ExpensePostModel>(`${environment.api}/expense`, expense);
  }
}
