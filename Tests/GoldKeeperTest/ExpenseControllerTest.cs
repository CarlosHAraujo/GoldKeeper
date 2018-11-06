using Domain;
using GoldKeeper.Controllers;
using GoldKeeper.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static GoldKeeper.Models.ExpensePostModel;

namespace GoldKeeperTest
{
    public class ExpenseControllerTest : ControllerTestBase
    {
        [Theory]
        [MemberData(nameof(GetPostExpenseSample))]
        public async Task Should_ReturnSuccessResult_When_ModelStateIsValid(ExpensePostModel postedData)
        {
            ExpenseController controller = new ExpenseController(context);

            var result = await controller.Post(postedData, default(CancellationToken));

            var actionResult = Assert.IsType<ActionResult<Expense>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var expense = Assert.IsType<Expense>(okResult.Value);
            Assert.Equal(postedData.CompanyId, expense.CompanyId);
            Assert.Equal(postedData.Date, expense.Date);
            Assert.Equal(Math.Abs(postedData.Discount), expense.Discount);

            ExtraCostModel postedExtraCost = postedData.ExtraCosts.First();
            ExtraCost savedExtraCost = expense.ExtraCosts.First();
            Assert.Equal(postedExtraCost.Cost, savedExtraCost.Cost);
            Assert.Equal(Math.Abs(postedExtraCost.Value), savedExtraCost.Value);

            ItemModel postedItem = postedData.Items.First();
            Item savedItem = expense.Items.First();
            Assert.Equal(postedItem.ProductId, savedItem.ProductId);
            Assert.Equal(postedItem.Quantity, savedItem.Quantity);
            Assert.Equal(Math.Abs(postedItem.Value), savedItem.Value);

            PaymentModel postedPayment = postedData.Payments.First();
            Payment savedPayment = expense.Payments.First();
            Assert.Equal(postedPayment.MethodId, savedPayment.MethodId);
            Assert.Equal(Math.Abs(postedPayment.Value), savedPayment.Value);
        }

        public static IEnumerable<object[]> GetPostExpenseSample()
        {
            yield return new object[]
            {
                new ExpensePostModel
                {
                    CompanyId = 1,
                    Date = default(DateTime),
                    Discount = 0,
                    ExtraCosts = new List<ExtraCostModel>() { new ExtraCostModel { Cost = "Dummy Cost", Value = 0 } },
                    Items = new List<ItemModel>() { new ItemModel { ProductId = 1, Quantity = 1, Value = 0 } },
                    Payments = new List<PaymentModel> { new PaymentModel { MethodId = 1, Value = 0 } }
                }
            };
            yield return new object[]
            {
                new ExpensePostModel
                {
                    CompanyId = -1,
                    Date = DateTime.Now,
                    Discount = -1,
                    ExtraCosts = new List<ExtraCostModel>() { new ExtraCostModel { Cost = "Dummy Cost", Value = -1 } },
                    Items = new List<ItemModel>() { new ItemModel { ProductId = -1, Quantity = -1, Value = -1 } },
                    Payments = new List<PaymentModel> { new PaymentModel { MethodId = -1, Value = -1 } }
                }
            };
            yield return new object[]
            {
                new ExpensePostModel
                {
                    CompanyId = int.MaxValue,
                    Date = DateTime.MaxValue,
                    Discount = int.MaxValue,
                    ExtraCosts = new List<ExtraCostModel>() { new ExtraCostModel { Cost = "Dummy Cost", Value = decimal.MaxValue } },
                    Items = new List<ItemModel>() { new ItemModel { ProductId = int.MaxValue, Quantity = int.MaxValue, Value = decimal.MaxValue } },
                    Payments = new List<PaymentModel> { new PaymentModel { MethodId = int.MaxValue, Value = decimal.MaxValue } }
                }
            };
            yield return new object[]
            {
                new ExpensePostModel
                {
                    CompanyId = int.MinValue,
                    Date = DateTime.MinValue,
                    Discount = int.MinValue,
                    ExtraCosts = new List<ExtraCostModel>() { new ExtraCostModel { Cost = "Dummy Cost", Value = decimal.MinValue } },
                    Items = new List<ItemModel>() { new ItemModel { ProductId = int.MinValue, Quantity = int.MinValue, Value = decimal.MinValue } },
                    Payments = new List<PaymentModel> { new PaymentModel { MethodId = int.MinValue, Value = decimal.MinValue } }
                }
            };
        }
    }
}
