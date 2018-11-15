import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray, FormControl } from '@angular/forms';
import { ExpenseService } from '../services/expense.service';
import * as moment from 'moment';
import { ExpensePostModel } from '../models/expense-add.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-expense-add',
  templateUrl: './expense-add.component.html',
  styleUrls: ['./expense-add.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ExpenseAddComponent implements OnInit {
  public form: FormGroup;
  public extraCostForm: FormGroup;
  public paymentForm: FormGroup;
  public itemForm: FormGroup;
  public companies: Array<any>;
  public paymentMethods: Array<any>;
  public products: Observable<Array<any>>;

  constructor(private fb: FormBuilder, private service: ExpenseService) {
  }

  ngOnInit() {
    this.form = this.fb.group({
      companyId: [null, Validators.required],
      date: [null, Validators.required],
      discount: null,
      extraCosts: this.fb.array([]),
      payments: this.fb.array([], Validators.required),
      items: this.fb.array([], Validators.required)
    });

    this.extraCostForm = this.fb.group({
      cost: [null, Validators.required],
      value: [null, Validators.required],
      submitted: false
    });

    this.paymentForm = this.fb.group({
      methodId: [null, Validators.required],
      value: [null, Validators.required],
      submitted: false
    });

    this.itemForm = this.fb.group({
      productId: [null, Validators.required],
      quantity: [null, Validators.required],
      value: [null, Validators.required],
      submitted: false
    });

    this.products = this.service.getProducts();
  }

  get companyId(): FormGroup {
    return this.form.get('companyId') as FormGroup;
  }

  get date(): FormControl {
    return this.form.get('date') as FormControl;
  }

  get extraCosts(): FormArray {
    return this.form.get('extraCosts') as FormArray;
  }

  addExtraCost(extraCost: FormControl): void {
    extraCost.get('submitted').setValue(true);
    if (extraCost.valid) {
      this.extraCosts.push(this.fb.group(this.extraCostForm.value));
      this.extraCostForm.reset();
    }
  }

  deleteExtraCost(i: number) {
    this.extraCosts.removeAt(i);
  }

  get payments(): FormArray {
    return this.form.get('payments') as FormArray;
  }

  addPayment(payment: FormGroup): void {
    payment.get('submitted').setValue(true);
    if (payment.valid) {
      this.payments.push(this.fb.group(this.paymentForm.value));
      this.paymentForm.reset();
    }
  }

  deletePayment(i: number): void {
    this.payments.removeAt(i);
  }

  get items(): FormArray {
    return this.form.get('items') as FormArray;
  }

  addItem(item: FormGroup): void {
    item.get('submitted').setValue(true);
    if (item.valid) {
      this.items.push(this.fb.group(this.itemForm.value));
      this.itemForm.reset();
    }
  }

  deleteItem(i: number): void {
    this.items.removeAt(i);
  }

  onSubmit(): void {
    if (this.form.valid) {
      const postData = this.form.value as ExpensePostModel;
      postData.date = moment(this.date.value).format();
      this.service.post(postData).subscribe(result => console.dir(result));
    }
  }
}
