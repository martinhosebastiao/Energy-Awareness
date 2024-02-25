using System;
namespace EA.Domain.Core.Devices
{
    public sealed record Hour
    {
        public Hour(decimal? value)
        {
            ArgumentNullException.ThrowIfNull(value);

            Value = (decimal)value;
        }

        public decimal Value { get; }
    }
}

