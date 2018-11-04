using System.Collections.Generic;

namespace DomainTest
{
    public class Common
    {
        public static IEnumerable<decimal> GetDecimalSample()
        {
            yield return decimal.MinValue;
            yield return decimal.MaxValue;
            yield return decimal.MinusOne;
            yield return decimal.One;
            yield return decimal.Zero;
        }
    }
}
