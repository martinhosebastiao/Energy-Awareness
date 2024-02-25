using System;
using EA.Domain.Core.Abstractions;

namespace EA.Domain.Core.Devices
{
    public sealed class Device : Entity
    {
        private Device(Guid id, Name name) : base(id) => Name = name;


        public Guid UserId { get; private set; }
        public Name Name { get; private set; }
        public Power PowerInWatt { get; private set; } = default!;
        public Hour PowerOnHoursPerDay { get; private set; } = default!;

        public static Device Create(Name name, Power powerInWatt,
                                        Hour PowerOnHoursPerDay)
        {
            var equipament = new Device(Guid.NewGuid(), name)
            {
                PowerInWatt = powerInWatt,
                PowerOnHoursPerDay = PowerOnHoursPerDay
            };

            return equipament;
        }
    }
}


