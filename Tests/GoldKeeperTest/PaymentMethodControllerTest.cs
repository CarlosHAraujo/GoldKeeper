using Domain;
using GoldKeeper.Controllers;
using GoldKeeper.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GoldKeeperTest
{
    public class PaymentMethodControllerTest : ControllerTestBase
    {
        [Fact]
        public async Task Should_ReturnListOfTuple_When_ThereIsCompany()
        {
            var paymentMethodTest = new PaymentMethod("method test");
            await context.AddAsync(paymentMethodTest);
            await context.SaveChangesAsync();
            var controller = new PaymentMethodController(context);

            var result = await controller.Get(default(CancellationToken));

            var actionResult = Assert.IsType<ActionResult<IEnumerable<PaymentMethodGetModel>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var tuple = Assert.IsAssignableFrom<IEnumerable<PaymentMethodGetModel>>(okResult.Value);
            Assert.NotEmpty(tuple);
            Assert.Equal(paymentMethodTest.Id, tuple.First().Id);
            Assert.Equal(paymentMethodTest.Name, tuple.First().Name);
        }

        [Theory]
        [MemberData(nameof(GetPostPaymentMethodSample))]
        public async Task Should_ReturnSuccessResult_When_ModelIsValid(PaymentMethodPostModel postedData)
        {
            var controller = new PaymentMethodController(context);

            var result = await controller.Post(postedData, default(CancellationToken));

            var actionResult = Assert.IsType<ActionResult<PaymentMethod>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var paymentMethod = Assert.IsType<PaymentMethod>(okResult.Value);
            Assert.Equal(postedData.Name, paymentMethod.Name);
        }

        public static IEnumerable<object[]> GetPostPaymentMethodSample()
        {
            yield return new object[] { new PaymentMethodPostModel { Name = "Dinheiro" } };
        }
    }
}
