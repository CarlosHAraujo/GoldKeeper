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
    public class CompanyControllerTest : ControllerTestBase
    {
        [Fact]
        public async Task Should_ReturnListOfTuple_When_ThereIsCompany()
        {
            var testCompany = new Company("Test 1");
            await context.Companies.AddAsync(testCompany);
            await context.SaveChangesAsync();
            var controller = new CompanyController(context);

            var result = await controller.Get(default(CancellationToken));

            var actionResult = Assert.IsType<ActionResult<IEnumerable<(int, string)>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var tuple = Assert.IsAssignableFrom<IEnumerable<(int id, string name)>>(okResult.Value);
            Assert.NotEmpty(tuple);
            Assert.Equal(testCompany.Id, tuple.First().id);
            Assert.Equal(testCompany.Name, tuple.First().name);
        }

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
