import { Component, OnInit, Input, EventEmitter, Output, ChangeDetectionStrategy } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-item-add',
  templateUrl: './item-add.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ItemAddComponent {
  @Input()
  public form: FormGroup;

  @Input()
  public invalid: boolean;

  @Input()
  public addMode: boolean;

  @Input()
  public products: Array<any>;

  @Output()
  public added = new EventEmitter();

  @Output()
  public deleted = new EventEmitter();

  constructor() {
  }

  onAdded(): void {
    this.added.emit(null);
  }

  ondeleted(): void {
    this.deleted.emit(null);
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
}
