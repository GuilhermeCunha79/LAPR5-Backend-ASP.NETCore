using System.Data;
using DDDSample1.Domain.Shared;

namespace DDDNetCore.Domain.Warehouses
{
    public class WarehouseCoordinates : IValueObject
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public WarehouseCoordinates()
        {
            this.Latitude = 0;
            this.Longitude = 0;
        }

        public WarehouseCoordinates(float latitude, float longitude)
        {
            this.Latitude = ValidateCoordinates(latitude);
            this.Longitude = ValidateCoordinates(longitude);
        }

        private float ValidateCoordinates(float coordinate)
        {
            return coordinate;
        }

        public override string ToString()
        {
            return "" + Latitude + Longitude;
        }
    }
}