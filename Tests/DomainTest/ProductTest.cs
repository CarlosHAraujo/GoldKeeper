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
        [ClassData(typeof(EmptyAndNullStringSample))]
        public void Should_Throw_When_NameIsMissing(string name)
        {
            var ex = Assert.ThrowsAny<Exception>(() => new Product(name));
            Assert.Contains(ex.GetType(), Common.GetExpectedExceptionsForMissingParameter());
            Assert.Contains(nameof(name), ex.Message);
        }
    }
}
