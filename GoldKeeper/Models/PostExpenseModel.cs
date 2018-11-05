using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GoldKeeper.Models
{
    public class PostExpenseModel
    {
        [JsonRequired]
        public int CompanyId { get; set; }

        [JsonRequired]
        public DateTime Date { get; set; }

        [JsonRequired]
        public decimal Discount { get; set; }

        public IEnumerable<ExtraCostModel> ExtraCosts { get; set; }

        public IEnumerable<PaymentModel> Payments { get; set; }

        public IEnumerable<ItemModel> Items { get; set; }

        public class PaymentModel
        {
            [JsonRequired]
            public int MethodId { get; set; }

            [JsonRequired]
            public decimal Value { get; set; }
        }

        public class ExtraCostModel
        {
            [JsonRequired]
            public int CostId { get; set; }

            [JsonRequired]
            public decimal Value { get; set; }
        }

        public class ItemModel
        {
            [JsonRequired]
            public int ProductId { get; set; }

            [JsonRequired]
            public int Quantity { get; set; }

            [JsonRequired]
            public decimal Value { get; set; }
        }
    }
}
