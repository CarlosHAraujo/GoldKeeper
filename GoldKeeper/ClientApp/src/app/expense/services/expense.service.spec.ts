import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { ExpenseService } from './expense.service';

describe('ExpenseService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientModule]
  }));

  it('should be created', () => {
    const service: ExpenseService = TestBed.inject(ExpenseService);
    expect(service).toBeTruthy();
  });
});
