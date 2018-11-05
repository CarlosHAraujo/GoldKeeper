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
            Assert.Throws<ArgumentNullException>("name", () => new Company(name));
        }

        public static IEnumerable<object[]> GetNameSampleData()
        {
            return Common.GetEmptyOrNullStringSample().Select(x => new object[] { x });
        }
    }
}
