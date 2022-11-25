using System;
using System.Data;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;

namespace DDDNetCore.Domain.Warehouses
{
    public class Warehouse : Entity<Identifier>, IAggregateRoot
    {
        public WarehouseId WarehouseIdentifier { get; set; }

        public WarehouseAddress WarehouseAddress { get; set; }

        public WarehouseCoordinates WarehouseCoordinates { get; set; }

        public WarehouseDesignation WarehouseDesignation { get; set; }

        public Altitude Altitude { get; set; }

        public bool Active { get; set; }


        public Warehouse()
        {
            Active = true;
        }

        public Warehouse(WarehouseId warehouseIdentifier, WarehouseDesignation warehouseDesignation, string street,
            int number,
            string postalCode, string country, float latitude, float longitude, Altitude altitude)
        {
            this.Id = new Identifier(Guid.NewGuid());
            this.WarehouseIdentifier = warehouseIdentifier;
            this.WarehouseDesignation = warehouseDesignation;
            this.WarehouseAddress = new WarehouseAddress(street, number, postalCode, country);
            this.WarehouseCoordinates = new WarehouseCoordinates(latitude, longitude);
            this.Altitude = altitude;
            Active = true;
        }

        public void ChangeDesignation(WarehouseDesignation warehouseDesignation)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException(
                    "It is not possible to change the designation of an inactive warehouse.");
            if (warehouseDesignation == null)
                throw new NoNullAllowedException("Every warehouse requires a designation.");
            this.WarehouseDesignation = warehouseDesignation;
        }

        public void ChangeAddress(string street, int number, string postalCode, string country)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException(
                    "It is not possible to change the address of an inactive warehouse.");
            if (street == null || number == 0 || postalCode == null || country == null)
                throw new NoNullAllowedException("Every warehouse requires all address items.");
            this.WarehouseAddress = new WarehouseAddress(street, number, postalCode, country);
        }

        public void ChangeCoordinates(float latitude, float longitude)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException(
                    "It is not possible to change the coordinates of an inactive warehouse.");
            if (latitude == 0 || longitude == 0)
                throw new NoNullAllowedException("Every warehouse requires valid coordinates.");
            this.WarehouseCoordinates = new WarehouseCoordinates(latitude, longitude);
        }

        public void ChangeAltitude(float altitude)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException(
                    "It is not possible to change the coordinates of an inactive warehouse.");
            if (altitude < 0)
                throw new ArgumentOutOfRangeException($"Every warehouse requires a valid altitude.");
            this.Altitude = new Altitude(altitude);
        }

        public void MarkAsInative()
        {
            if (!Active)
            {
                throw new BusinessRuleValidationException("User already inactive");
            }

            Active = false;
        }
    }
}