import { Component, Input, Output, EventEmitter, ChangeDetectionStrategy, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { PaymentMethodSelectModel } from '../models/payment-method-select.model';
import { Observable } from 'rxjs';
import { RequiredIf } from 'src/app/requiredif.validator';

@Component({
  selector: 'app-payment-add',
  templateUrl: './payment-add.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PaymentAddComponent implements OnInit {
  public newPaymentMethod: boolean;

  @Input()
  public form: FormGroup;

  @Input()
  public paymentMethods$: Observable<Array<PaymentMethodSelectModel>>;

  @Input()
  invalid: boolean;

  @Input()
  public addMode: boolean;

  @Output()
  public added = new EventEmitter();

  @Output()
  public deleted = new EventEmitter();

  constructor() {
  }

  ngOnInit(): void {
    this.methodId.setValidators([RequiredIf(() => !this.newPaymentMethod && !this.methodName.value, this.methodName)]);
    this.methodName.setValidators([RequiredIf(() => this.newPaymentMethod && !this.methodId.value, this.methodId)]);
    this.newPaymentMethod = !!this.methodName.value;
  }

  onAdded(): void {
    this.added.emit(null);
  }
  onDeleted(): void {
    this.deleted.emit(null);
  }

  get methodName(): FormControl {
    return this.form.get('methodName') as FormControl;
  }

  get methodId(): FormControl {
    return this.form.get('methodId') as FormControl;
  }

  get value(): FormControl {
    return this.form.get('value') as FormControl;
  }

  get submitted(): FormControl {
    return this.form.get('submitted') as FormControl;
  }

  onNewPaymentMethodClicked(): void {
    this.newPaymentMethod = !this.newPaymentMethod;
    if (this.newPaymentMethod) {
      this.methodId.reset(null, { onlySelf: true, emitEvent: false });
    } else {
      this.methodName.reset(null, { onlySelf: true, emitEvent: false });
    }
  }
}
