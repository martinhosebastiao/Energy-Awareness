namespace EA.Domain.Core.Devices
{
    public sealed record Power
    {
        private Power(decimal value) => Value = value;

        public decimal Value { get; init; }

        public static Power? CreateInWatt(decimal value)
        {
            // Aplicar as validações necessarias.
            // ......

            return new Power(value);
        }
    }
}

