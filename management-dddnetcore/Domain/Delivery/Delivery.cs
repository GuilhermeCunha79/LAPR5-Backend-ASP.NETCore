using System;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;

namespace DDDSample1.Domain.Delivery;

public class Delivery : Entity<Identifier>, IAggregateRoot
{
    public DeliveryDate DeliveryDate { get; set; }

    public DeliveryId DeliveryId { get; set; }

    public DeliveryMass DeliveryMass { get; set; }

    public WarehouseId WarehouseId { get; set; }

    public DeliveryTime DeliveryTime { get; set; }

    public bool Active { get; set; }

    public Delivery()
    {
        Active = true;
    }

    public Delivery(string deliveryId, int day,string month,int year,float deliveryMass, string storeId,
        int withdrawalTime,int placingTime)
    {
        Id = new Identifier(Guid.NewGuid());
        DeliveryId = new DeliveryId(deliveryId);
        DeliveryDate = new DeliveryDate(day,month,year);
        DeliveryMass = new DeliveryMass(deliveryMass);
        WarehouseId = new WarehouseId(storeId);
        DeliveryTime = new DeliveryTime(placingTime,withdrawalTime);
        Active = true;
    }

    public void ChangeDeliveryDate(DeliveryDate deliveryDate)
    {
        if (!Active)
            throw new BusinessRuleValidationException(
                "It is not possible to change the category of an inactive delivery.");
        DeliveryDate = deliveryDate ??
                       throw new BusinessRuleValidationException("Every warehouse requires a date to delivery.");
    }

    public void ChangeDeliveryMass(DeliveryMass deliveryMass)
    {
        if (!Active)
            throw new BusinessRuleValidationException(
                "It is not possible to change the category of an inactive delivery.");
        DeliveryMass = deliveryMass ??
                       throw new BusinessRuleValidationException(
                           "Every delivery plan requires the mass of the delivery.");
    }

    public void ChangeStoreId(WarehouseId storeId)
    {
        if (!this.Active)
            throw new BusinessRuleValidationException(
                "It is not possible to change the category of an inactive delivery.");
        this.WarehouseId = storeId ??
                           throw new BusinessRuleValidationException(
                               "Every delivery plan requires the warehouse id to deliver.");
    }

    public void ChangeDeliveryTime(DeliveryTime deliveryTime)
    {
        if (!Active)
            throw new BusinessRuleValidationException(
                "It is not possible to change the category of an inactive delivery.");
        DeliveryTime = deliveryTime ??
                       throw new BusinessRuleValidationException("Every delivery plan requires a time to deliver.");
    }

    public void MarkAsInative()
    {
        if (!Active)
        {
            throw new BusinessRuleValidationException("Delivery Plan already inactive");
        }

        Active = false;
    }
}