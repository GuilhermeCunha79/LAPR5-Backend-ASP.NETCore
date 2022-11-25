using DDDNetCore.Controllers;
using DDDSample1.Domain.Delivery;

namespace DDDSample1.UserInterface;

public class CreateDelivery
{
    public IDeliveryService _deliveryService = new DeliveryService()
    public DeliveryController Controller = new DeliveryController();
}