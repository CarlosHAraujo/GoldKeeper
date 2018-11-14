import { Component, Input, Output, EventEmitter, ChangeDetectionStrategy } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-payment-add',
  templateUrl: './payment-add.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PaymentAddComponent {
  @Input()
  public form: FormGroup;

  @Input()
  public paymentMethods: Array<any>;

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

  onAdded(): void {
    this.added.emit(null);
  }
  onDeleted(): void {
    this.deleted.emit(null);
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
}
