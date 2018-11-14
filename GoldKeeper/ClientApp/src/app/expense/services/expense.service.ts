import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ExpensePostModel } from '../models/expense-add.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ExpenseService {

  constructor(private http: HttpClient) {
  }

  post(expense: ExpensePostModel): Observable<ExpensePostModel> {
    return this.http.post<ExpensePostModel>(`${environment.api}/expense`, expense);
  }
}
