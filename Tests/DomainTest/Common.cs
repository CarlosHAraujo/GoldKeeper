using System;
using System.Collections.Generic;

namespace DomainTest
{
    public class Common
    {
        public static List<Type> GetExpectedExceptionsForMissingParameter()
        {
            return new List<Type>() { typeof(ArgumentException), typeof(ArgumentNullException) };
        }
    }
}
