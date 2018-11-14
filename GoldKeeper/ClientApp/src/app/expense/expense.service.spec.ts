import { TestBed } from '@angular/core/testing';
import { ExpenseService } from './services/expense.service';

describe('ExpenseService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ExpenseService = TestBed.get(ExpenseService);
    expect(service).toBeTruthy();
  });
});
