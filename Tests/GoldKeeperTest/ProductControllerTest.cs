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
    public class ProductControllerTest : ControllerTestBase
    {
        [Theory]
        [MemberData(nameof(GetPostProductSample))]
        public async Task Should_ReturnSuccessResult_When_ModelIsValid(ProductPostModel postedData)
        {
            var controller = new ProductController(context);

            var result = await controller.Post(postedData, default(CancellationToken));

            var actionResult = Assert.IsType<ActionResult<Product>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var product = Assert.IsType<Product>(okResult.Value);
            Assert.Equal(postedData.Name, product.Name);
        }

        public static IEnumerable<object[]> GetPostProductSample()
        {
            yield return new object[] { new ProductPostModel { Name = "Batarang" } };
        }
    }
}
