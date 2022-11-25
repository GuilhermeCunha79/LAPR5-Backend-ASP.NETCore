using System;
using DDDSample1.Domain.Shared;

namespace DDDNetCore.Domain.Warehouses
{
    public class Altitude : IValueObject
    {
        public float AltitudeValue { get; set; }

        public Altitude()
        {
            this.AltitudeValue = 0;
        }

        public Altitude(float altitudeValue)
        {
            this.AltitudeValue = ValidateWarehouseDesignation(altitudeValue);
        }

        private float ValidateWarehouseDesignation(float altitudeValue)
        {
            if (altitudeValue < 0)
            {
                throw new ArgumentOutOfRangeException($"The altitude can't be less than 0.");
            }

            return altitudeValue;
        }

        public override string ToString()
        {
            return AltitudeValue.ToString();
        }
    }
}