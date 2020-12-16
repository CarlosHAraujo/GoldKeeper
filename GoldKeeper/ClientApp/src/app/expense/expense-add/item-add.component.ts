import { Component, OnInit, Input, EventEmitter, Output, ChangeDetectionStrategy } from '@angular/core';
import { FormGroup, FormControl, AbstractControl } from '@angular/forms';
import { ProductSelectModel } from '../models/product-select.model';
import { Observable } from 'rxjs';
import { first, filter, take, debounceTime } from 'rxjs/operators';
import { RequiredIf } from '../../requiredif.validator';

@Component({
  selector: 'app-item-add',
  templateUrl: './item-add.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ItemAddComponent implements OnInit {
  public newProduct: boolean;

  @Input()
  public form: FormGroup;

  @Input()
  public invalid: boolean;

  @Input()
  public addMode: boolean;

  @Input()
  public products$: Observable<ProductSelectModel[]>;

  @Output()
  public added = new EventEmitter();

  @Output()
  public deleted = new EventEmitter();

  constructor() {
  }

  ngOnInit(): void {
    this.productId.setValidators([RequiredIf(() => !this.newProduct && !this.productName.value, this.productName)]);
    this.productName.setValidators([RequiredIf(() => this.newProduct && !this.productId.value, this.productId)]);
    this.newProduct = !!this.productName.value;
  }

  onAdded(): void {
    this.added.emit(undefined);
  }

  ondeleted(): void {
    this.deleted.emit(undefined);
  }

  get productName(): FormControl {
    return this.form.get('productName') as FormControl;
  }

  get productId(): FormControl {
    return this.form.get('productId') as FormControl;
  }

  get quantity(): FormControl {
    return this.form.get('quantity') as FormControl;
  }

  get value(): FormControl {
    return this.form.get('value') as FormControl;
  }

  get submitted(): FormControl {
    return this.form.get('submitted') as FormControl;
  }

  onNewProductClicked(): void {
    this.newProduct = !this.newProduct;
    if (this.newProduct) {
      this.productId.reset(undefined, { onlySelf: true, emitEvent: false });
    } else {
      this.productName.reset(undefined, { onlySelf: true, emitEvent: false });
    }
  }
}
