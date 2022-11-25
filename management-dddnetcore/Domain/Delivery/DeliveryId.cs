using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Delivery
{
    public class DeliveryId : IValueObject
    {
        public string DeliveryIdentifier { get; set; }

        public DeliveryId()
        {
            this.DeliveryIdentifier = "";
        }

        public DeliveryId(string text)
        {
            this.DeliveryIdentifier = text;
        }

        public override string ToString()
        {
            return DeliveryIdentifier;
        }
    }
}