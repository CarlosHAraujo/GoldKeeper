import { ValidatorFn, Validators, AbstractControl, ValidationErrors } from '@angular/forms';
import { Observable } from 'rxjs';

export function RequiredIf(condition: () => boolean, otherControl: AbstractControl): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    if (otherControl.errors && otherControl.errors.required) {
      otherControl.updateValueAndValidity({ emitEvent: false, onlySelf: true });
    }
    if (condition()) {
      return Validators.required(control);
    } else {
      return undefined;
    }
  };
}
