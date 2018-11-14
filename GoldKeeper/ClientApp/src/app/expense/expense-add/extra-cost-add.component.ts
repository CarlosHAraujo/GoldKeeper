import { Component, OnInit, ChangeDetectionStrategy, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-extra-cost-add',
  templateUrl: './extra-cost-add.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ExtraCostAddComponent {
  @Input()
  public form: FormGroup;

  @Input()
  public invalid: boolean;

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

  get cost(): FormControl {
    return this.form.get('cost') as FormControl;
  }

  get value(): FormControl {
    return this.form.get('value') as FormControl;
  }

  get submitted(): FormControl {
    return this.form.get('submitted') as FormControl;
  }
}
