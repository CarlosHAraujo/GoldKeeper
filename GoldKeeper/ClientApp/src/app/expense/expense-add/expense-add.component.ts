import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray, FormControl } from '@angular/forms';
import { ExpenseService } from '../services/expense.service';
import * as moment from 'moment';
import { ExpensePostModel } from '../models/expense-add.model';
import { Observable } from 'rxjs';
import { PaymentMethodSelectModel } from '../models/payment-method-select.model';
import { ProductSelectModel } from '../models/product-select.model';
import { CompanySelectModel } from '../models/company-select.model';
import { RequiredIf } from 'src/app/requiredif.validator';

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
  public companies$: Observable<CompanySelectModel[]>;
  public paymentMethods$: Observable<PaymentMethodSelectModel[]>;
  public products$: Observable<ProductSelectModel[]>;
  public newCompany: boolean;

  constructor(private fb: FormBuilder, private service: ExpenseService) {
  }

  ngOnInit() {
    this.form = this.fb.group({
      companyId: null,
      companyName: null,
      date: [null, Validators.required],
      discount: null,
      extraCosts: this.fb.array([]),
      payments: this.fb.array([], [Validators.required]),
      items: this.fb.array([], Validators.required)
    });

    this.companyId.setValidators([RequiredIf(() => !this.newCompany && !this.companyName.value, this.companyName)]);
    this.companyName.setValidators([RequiredIf(() => this.newCompany && !this.companyId.value, this.companyId)]);

    this.extraCostForm = this.fb.group({
      cost: [null, Validators.required],
      value: [null, Validators.required],
      submitted: false
    });

    this.paymentForm = this.fb.group({
      methodId: null,
      methodName: null,
      value: [null, Validators.required],
      submitted: false
    });

    this.itemForm = this.fb.group({
      productId: null,
      productName: null,
      quantity: [null, Validators.required],
      value: [null, Validators.required],
      submitted: false
    });

    this.products$ = this.service.getProducts();
    this.paymentMethods$ = this.service.getPaymentMethods();
    this.companies$ = this.service.getCompanies();
  }

  get companyName(): FormGroup {
    return this.form.get('companyName') as FormGroup;
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

  onNewCompanyClicked(): void {
    this.newCompany = !this.newCompany;
    if (this.newCompany) {
      this.companyId.reset(null, { onlySelf: true, emitEvent: false });
    } else {
      this.companyName.reset(null, { onlySelf: true, emitEvent: false });
    }
  }

  onSubmit(): void {
    if (this.form.valid) {
      const postData = this.form.value as ExpensePostModel;
      postData.date = moment(this.date.value).format();
      this.service.post(postData).subscribe(result => console.dir(result));
    }
  }
}
