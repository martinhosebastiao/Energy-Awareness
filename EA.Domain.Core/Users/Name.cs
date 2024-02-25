using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace EA.Domain.Core.Users
{
    public sealed record Name
    {
        public Name(string? value)
        {
            Ensure.NotNullOrEmpty(value);

            Value = value;
        }

        public string Value { get; }
    }

    public static class Ensure
    {
        public static void NotNullOrEmpty(
            [NotNull] string? value,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(paramName);
        }
    }
}

