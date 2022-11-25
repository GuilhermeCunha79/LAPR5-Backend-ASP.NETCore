using System;
using DDDSample1.Domain.Shared;
using Newtonsoft.Json;

namespace DDDSample1.Domain.Warehouses
{
    public class WarehouseId : IValueObject
    {
        public string WarehouseIdentifier { get; set; }

        public WarehouseId()
        {
            this.WarehouseIdentifier = "";
        }

        public WarehouseId(string text)
        {
            this.WarehouseIdentifier = ValidateWarehouseIdentifier(text);
        }

        private string ValidateWarehouseIdentifier(string warehouseIdentifier)
        {
            if (warehouseIdentifier == null)
            {
                throw new NullReferenceException("The warehouse Identifier can't be null.");
            }
            else
            {
                if (warehouseIdentifier.Length > 3)
                {
                    throw new BusinessRuleValidationException("The warehouse Identifier can't have more than 3 characters.");
                }
            }

            return warehouseIdentifier;
        }

        public override string ToString()
        {
            return WarehouseIdentifier;
        }
    }
}