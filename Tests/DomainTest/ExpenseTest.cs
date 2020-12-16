using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DomainTest
{
    public class ExpenseTest
    {
        [Theory]
        [ClassData(typeof(DecimalSample))]
        public void Should_DiscontBePositive_When_AnyValueIsPassed(decimal discount)
        {
            var expense = GetGoodExpense(discount);
            Assert.True(expense.Discount >= 0);
        }

        [Theory]
        [MemberData(nameof(GetExtraCostSample))]
        public void Should_ExtraCostsValueBePositive_When_AnyValueIsPassed(string cost, decimal value)
        {
            var expense = GetGoodExpense();
            var extraCost = expense.AddExtraCost(cost, value);
            Assert.True(extraCost.Value >= 0);
            Assert.Contains(extraCost, expense.ExtraCosts);
            Assert.Equal(cost, extraCost.Cost);
        }

        [Theory]
        [MemberData(nameof(GetPaymentSample))]
        public void Should_PaymentsValueBePositive_When_AnyValueIsPassed(int methodId, decimal value)
        {
            var expense = GetGoodExpense();
            var payment = expense.AddPayment(methodId, value);
            Assert.True(payment.Value >= 0);
            Assert.Contains(payment, expense.Payments);
        }

        [Theory]
        [MemberData(nameof(GetItemSample))]
        public void Should_ItemsValueBePositive_When_AnyValueIsPassed(int productId, decimal value, int quantity)
        {
            try
            {
                var expense = GetGoodExpense();
                var item = expense.AddItem(productId, value, quantity);
                Assert.True(item.Value >= 0);
                Assert.Contains(item, expense.Items);
                Assert.Equal(quantity, item.Quantity);
                Assert.True(item.Quantity >= 0);
                Assert.Equal(quantity * Math.Abs(value), item.Total);
            }
            catch (OverflowException ex)
            {
                //Expected exception if quantity * value exceeds decimal.MaxValue
                Assert.Contains("Decimal", ex.Message);
            }
        }

        private static Expense GetGoodExpense(decimal discount = 0)
        {
            return new Expense(1, default, discount);
        }

        public static IEnumerable<object[]> GetItemSample()
        {
            var random = new Random();
            return new DecimalSample().SelectMany(x => x.Select(y => new object []{ 1, y, random.Next() }));
        }

        public static IEnumerable<object[]> GetExtraCostSample()
        {
            return new DecimalSample().SelectMany(x => x.Select(y => new object[] { "Dummy Cost", y }));
        }

        public static IEnumerable<object[]> GetPaymentSample()
        {
            return new DecimalSample().SelectMany(x => x.Select(y => new object[] { 1, y }));
        }
    }
}
