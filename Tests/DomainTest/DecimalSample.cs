using System.Collections;
using System.Collections.Generic;

namespace DomainTest
{
    public class DecimalSample : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { decimal.MinValue },
            new object[] { decimal.MaxValue },
            new object[] { decimal.MinusOne },
            new object[] { decimal.One },
            new object[] { decimal.Zero }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
