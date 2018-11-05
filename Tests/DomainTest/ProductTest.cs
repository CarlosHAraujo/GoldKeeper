using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DomainTest
{
    public class ProductTest
    {
        [Theory]
        [MemberData(nameof(GetNameSample))]
        public void Should_Throw_When_NameIsMissing(string name)
        {
            var ex = Assert.ThrowsAny<Exception>(() => new Product(name));
            Assert.Contains(ex.GetType(), Common.GetExpectedExceptionsForMissingParameter());
            Assert.Contains(nameof(name), ex.Message);
        }

        public static IEnumerable<object[]> GetNameSample()
        {
            return Common.GetEmptyOrNullStringSample().Select(x => new object[] { x });
        }
    }
}
