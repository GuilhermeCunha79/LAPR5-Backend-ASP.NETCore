using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Delivery;

public interface IDeliveryRepository : IRepository<Delivery, Identifier>
{
    Task<Delivery> GetByDeliveryIdAsync(string deliveryIdentifier);
}