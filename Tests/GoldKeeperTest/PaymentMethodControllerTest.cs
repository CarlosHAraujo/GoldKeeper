using Domain;
using GoldKeeper.Controllers;
using GoldKeeper.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GoldKeeperTest
{
    public class PaymentMethodControllerTest : ControllerTestBase
    {
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
