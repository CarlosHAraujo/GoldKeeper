using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoldKeeper.Models
{
    public class PostExpenseModel
    {
        [Required]
        public int? CompanyId { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [Required]
        public decimal? Discount { get; set; }

        public IEnumerable<ExtraCostModel> ExtraCosts { get; set; }

        public IEnumerable<PaymentModel> Payments { get; set; }

        public IEnumerable<ItemModel> Items { get; set; }

        public class PaymentModel
        {
            [Required]
            public int? MethodId { get; set; }

            [Required]
            public decimal? Value { get; set; }
        }

        public class ExtraCostModel
        {
            [Required]
            public int? CostId { get; set; }

            [Required]
            public decimal? Value { get; set; }
        }

        public class ItemModel
        {
            [Required]
            public int? ProductId { get; set; }

            [Required]
            public int? Quantity { get; set; }

            [Required]
            public decimal? Value { get; set; }
        }
    }
}
