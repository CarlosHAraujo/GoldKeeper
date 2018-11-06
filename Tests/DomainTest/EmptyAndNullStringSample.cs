using System.Collections;
using System.Collections.Generic;

namespace DomainTest
{
    public class EmptyAndNullStringSample : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { " " },
            new object[] { "" },
            new object[] { null },
            new object[] { string.Empty },
            new object[] { default(string) }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
