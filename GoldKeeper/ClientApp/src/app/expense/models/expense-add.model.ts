export class ExpensePostModel {
  companyId: number;
  date: string;
  discount: number;
  extraCosts: Array<ExtraCostModel>;
  payments: Array<PaymentModel>;
  items: Array<ItemModel>;
}

class ExtraCostModel {
  cost: string;
  value: number;
}

class PaymentModel {
  methodId: number;
  value: number;
}

class ItemModel {
  productId: number;
  quantity: number;
  value: number;
}
