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
    public class CompanyControllerTest : ControllerTestBase
    {
        [Theory]
        [MemberData(nameof(GetPostCompanySample))]
        public async Task Should_ReturnSuccessResult_When_ModelStateIsValid(CompanyPostModel postedData)
        {
            var controller = new CompanyController(context);

            var result = await controller.Post(postedData, default(CancellationToken));

            var actionResult = Assert.IsType<ActionResult<Company>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var company = Assert.IsType<Company>(okResult.Value);
            Assert.Equal(postedData.Name, company.Name);
        }

        public static IEnumerable<object[]> GetPostCompanySample()
        {
            yield return new object[]
            {
                new CompanyPostModel{ Name = "Bruce Wayne" }
            };
        }
    }
}
