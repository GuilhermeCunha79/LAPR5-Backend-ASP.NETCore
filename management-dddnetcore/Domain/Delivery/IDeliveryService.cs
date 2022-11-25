using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Delivery;

public interface IDeliveryService
{
    Task<List<DeliveryDTO>> GetAllAsync();

    Task<DeliveryDTO> GetByIdAsync(Identifier id);
    Task<DeliveryDTO> GetByDeliveryIdAsync(string deliveryIdentifier);
    Task<DeliveryDTO> AddAsync(DeliveryDTO obj);

    Task<DeliveryDTO> UpdateByDeliveryIdAsync(DeliveryDTO dto);

    Task<DeliveryDTO> UpdateAsync(DeliveryDTO dto);
    Task<DeliveryDTO> InactivateAsync(Identifier id);

    Task<DeliveryDTO> DeleteAsync(Identifier id);
}