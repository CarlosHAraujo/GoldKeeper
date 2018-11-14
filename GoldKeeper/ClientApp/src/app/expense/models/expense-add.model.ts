export class ExpensePostModel {
  companyId = 0;
  date: string;
  discount = 0;
  extraCosts: Array<ExtraCostModel> = [];
  payments: Array<PaymentModel> = [];
  items: Array<ItemModel> = [];
}

class ExtraCostModel {
  cost = '';
  value = 0;
}

class PaymentModel {
  methodId = 0;
  value = 0;
}

class ItemModel {
  productId = 0;
  quantity = 0;
  value = 0;
}
