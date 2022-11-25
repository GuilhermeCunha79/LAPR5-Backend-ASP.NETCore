using DDDSample1.Domain.Shared;

namespace DDDNetCore.Domain.Warehouses
{
    public class WarehouseDesignation : IValueObject
    {
        public string Text { get; set; }

        public WarehouseDesignation()
        {
            this.Text = "";
        }

        public WarehouseDesignation(string text)
        {
            this.Text = ValidateWarehouseDesignation(text);
        }

        private string ValidateWarehouseDesignation(string warehouseDesignation)
        {
            if (warehouseDesignation != null)
            {
                if (warehouseDesignation.Length > 50)
                {
                    throw new BusinessRuleValidationException("The designation can't have more than 50 characters.");
                }
            }

            return warehouseDesignation;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}