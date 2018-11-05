using System;

/// <summary>
/// Credits: https://stackoverflow.com/questions/2480521/argumentexception-or-argumentnullexception-for-string-parameters
/// </summary>
namespace Shared.Extensions
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Throws when string is null, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns><paramref name="value"/></returns>
        public static string CheckNullOrWhiteSpace(this string value)
        {
            value = value ?? throw new ArgumentNullException(nameof(value));
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Argument must not be the empty string.", nameof(value));
            }
            return value;
        }
    }
}
