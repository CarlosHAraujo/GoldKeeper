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
    public class ProductControllerTest : ControllerTestBase
    {
        [Fact]
        public async Task Should_ReturnListOfTuple_When_ThereIsCompany()
        {
            var productTest = new Product("product test");
            await context.AddAsync(productTest);
            await context.SaveChangesAsync();
            var controller = new ProductController(context);

            var result = await controller.Get(default(CancellationToken));

            var actionResult = Assert.IsType<ActionResult<IEnumerable<(int, string)>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var tuple = Assert.IsAssignableFrom<IEnumerable<(int id, string name)>>(okResult.Value);
            Assert.NotEmpty(tuple);
            Assert.Equal(productTest.Id, tuple.First().id);
            Assert.Equal(productTest.Name, tuple.First().name);
        }

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
