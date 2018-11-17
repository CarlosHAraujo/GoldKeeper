using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoldKeeper.Models
{
    public class ExpensePostModel
    {
        [RequiredIf(nameof(CompanyId), AllowEmptyStrings = false)]
        public string CompanyName { get; set; }

        [RequiredIf(nameof(CompanyName))]
        public int? CompanyId { get; set; }

        [JsonRequired]
        public DateTimeOffset Date { get; set; }

        public decimal? Discount { get; set; }

        public IEnumerable<ExtraCostModel> ExtraCosts { get; set; }

        public IEnumerable<PaymentModel> Payments { get; set; }

        public IEnumerable<ItemModel> Items { get; set; }

        public class PaymentModel
        {
            [RequiredIf(nameof(MethodId), AllowEmptyStrings = false)]
            public string MethodName { get; set; }

            [RequiredIf(nameof(MethodName))]
            public int? MethodId { get; set; }

            [JsonRequired]
            public decimal Value { get; set; }
        }

        public class ExtraCostModel
        {
            [Required(AllowEmptyStrings = false)]
            public string Cost { get; set; }

            [JsonRequired]
            public decimal Value { get; set; }
        }

        public class ItemModel
        {
            [RequiredIf(nameof(ProductId), AllowEmptyStrings = false)]
            public string ProductName { get; set; }

            [RequiredIf(nameof(ProductName))]
            public int? ProductId { get; set; }

            [JsonRequired]
            public int Quantity { get; set; }

            [JsonRequired]
            public decimal Value { get; set; }
        }
    }
}
