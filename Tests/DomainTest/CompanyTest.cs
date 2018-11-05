using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DomainTest
{
    public class CompanyTest
    {
        [Theory]
        [MemberData(nameof(GetNameSampleData))]
        public void Should_ThrowArgumentNullException_When_NameIsMissing(string name)
        {
            var expectedExceptions = new List<Type>() { typeof(ArgumentException), typeof(ArgumentNullException) };
            var ex = Assert.ThrowsAny<Exception>(() => new Company(name));
            Assert.Contains(ex.GetType(), expectedExceptions);
        }

        public static IEnumerable<object[]> GetNameSampleData()
        {
            return Common.GetEmptyOrNullStringSample().Select(x => new object[] { x });
        }
    }
}
