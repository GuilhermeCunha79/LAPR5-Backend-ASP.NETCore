using System;

namespace DDDSample1.Domain.Warehouses
{
    public class WarehouseDTO
    {
        public Guid Id;
        public string WarehouseIdentifier { get; set; }
        public string Designation { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Altitude { get; set; }
        public string Status { get; set; }

        public WarehouseDTO(Guid id, string warehouseIdentifier, string designation, string street, int number,
            string postalCode, string country,
            float latitude, float longitude, float altitude, string status)
        {
            Id = id;
            WarehouseIdentifier = warehouseIdentifier;
            Designation = designation;
            Street = street;
            Number = number;
            PostalCode = postalCode;
            Country = country;
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
            Status = status;
        }
    }
}