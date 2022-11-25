using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;

namespace DDDSample1.Domain.Delivery;

public class DeliveryService:IDeliveryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDeliveryRepository _repo;

    public DeliveryService(IUnitOfWork unitOfWork, IDeliveryRepository repo)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
    }

    public async Task<List<DeliveryDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        List<DeliveryDTO> listDto = list.ConvertAll(delivery =>
            new DeliveryDTO(delivery.Id.AsGuid(), delivery.DeliveryId.DeliveryIdentifier, delivery.DeliveryDate.Day, delivery.DeliveryDate.Month,
                delivery.DeliveryDate.Year, delivery.DeliveryMass.Mass, delivery.DeliveryTime.placingTime, delivery.WarehouseId.ToString(),
                delivery.DeliveryTime.withdrawalTime));

        return listDto;
    }
    
    public async Task<DeliveryDTO> GetByDeliveryIdAsync(string deliveryIdentifier)
    {
        var delivery = await this._repo.GetByDeliveryIdAsync(deliveryIdentifier);

        if (delivery == null)
            return null;

        return new DeliveryDTO(delivery.Id.AsGuid(), delivery.DeliveryId.DeliveryIdentifier, delivery.DeliveryDate.Day, delivery.DeliveryDate.Month,
            delivery.DeliveryDate.Year, delivery.DeliveryMass.Mass, delivery.DeliveryTime.placingTime, delivery.WarehouseId.ToString(),
            delivery.DeliveryTime.withdrawalTime);
    }
    

    public async Task<DeliveryDTO> GetByIdAsync(Identifier id)
    {
        var delivery = await _repo.GetByIdAsync(id);

        if (delivery == null)
            return null;

        return new DeliveryDTO(delivery.Id.AsGuid(), delivery.DeliveryId.DeliveryIdentifier, delivery.DeliveryDate.Day, delivery.DeliveryDate.Month,
            delivery.DeliveryDate.Year, delivery.DeliveryMass.Mass, delivery.DeliveryTime.placingTime, delivery.WarehouseId.ToString(),
            delivery.DeliveryTime.withdrawalTime);
    }

    public async Task<DeliveryDTO> AddAsync(DeliveryDTO dto)
    {
        var delivery = new Delivery(dto.DeliveryIdentifier,dto.Day, dto.Month, dto.Year, dto.Mass, dto.StoreId,
           dto.PlacingTime, dto.WithdrawalTime);

        await _repo.AddAsync(delivery);

        await _unitOfWork.CommitAsync();

        return new DeliveryDTO(delivery.Id.AsGuid(), delivery.DeliveryId.DeliveryIdentifier, delivery.DeliveryDate.Day, delivery.DeliveryDate.Month,
            delivery.DeliveryDate.Year, delivery.DeliveryMass.Mass, delivery.DeliveryTime.placingTime, delivery.WarehouseId.ToString(),
            delivery.DeliveryTime.withdrawalTime);
    }

    public async Task<DeliveryDTO> UpdateAsync(DeliveryDTO dto)
    {
        var delivery = await _repo.GetByIdAsync(new Identifier(dto.Id));

        if (delivery == null)
            return null;

        // change all fields

        delivery.ChangeDeliveryDate(new DeliveryDate(dto.Day, dto.Month, dto.Year));
        delivery.ChangeDeliveryMass(new DeliveryMass(dto.Mass));
        delivery.ChangeDeliveryTime(new DeliveryTime(dto.PlacingTime, dto.WithdrawalTime));
        delivery.ChangeStoreId(new WarehouseId(dto.StoreId));

        await _unitOfWork.CommitAsync();

        return new DeliveryDTO(delivery.Id.AsGuid(), delivery.DeliveryId.DeliveryIdentifier, delivery.DeliveryDate.Day, delivery.DeliveryDate.Month,
            delivery.DeliveryDate.Year, delivery.DeliveryMass.Mass, delivery.DeliveryTime.placingTime, delivery.WarehouseId.ToString(),
            delivery.DeliveryTime.withdrawalTime);
    }
    
    public async Task<DeliveryDTO> UpdateByDeliveryIdAsync(DeliveryDTO dto)
    {
        var delivery = await this._repo.GetByDeliveryIdAsync(dto.DeliveryIdentifier);

        if (delivery == null)
            return null;

        delivery.ChangeDeliveryDate(new DeliveryDate(dto.Day, dto.Month, dto.Year));
        delivery.ChangeDeliveryMass(new DeliveryMass(dto.Mass));
        delivery.ChangeDeliveryTime(new DeliveryTime(dto.PlacingTime, dto.WithdrawalTime));
        delivery.ChangeStoreId(new WarehouseId(dto.StoreId));

        await this._unitOfWork.CommitAsync();

        return new DeliveryDTO(delivery.Id.AsGuid(), delivery.DeliveryId.DeliveryIdentifier, delivery.DeliveryDate.Day, delivery.DeliveryDate.Month,
            delivery.DeliveryDate.Year, delivery.DeliveryMass.Mass, delivery.DeliveryTime.placingTime, delivery.WarehouseId.ToString(),
            delivery.DeliveryTime.withdrawalTime);
    }

    public async Task<DeliveryDTO> InactivateAsync(Identifier id)
    {
        var delivery = await _repo.GetByIdAsync(id);

        if (delivery == null)
            return null;

        delivery.MarkAsInative();

        await _unitOfWork.CommitAsync();

        return new DeliveryDTO(delivery.Id.AsGuid(), delivery.DeliveryId.DeliveryIdentifier, delivery.DeliveryDate.Day, delivery.DeliveryDate.Month,
            delivery.DeliveryDate.Year, delivery.DeliveryMass.Mass, delivery.DeliveryTime.placingTime, delivery.WarehouseId.ToString(),
            delivery.DeliveryTime.withdrawalTime);
    }

    public async Task<DeliveryDTO> DeleteAsync(Identifier id)
    {
        var delivery = await _repo.GetByIdAsync(id);

        if (delivery == null)
            return null;

        if (delivery.Active)
            throw new BusinessRuleValidationException("It is not possible to delete an active delivery plan.");

        _repo.Remove(delivery);
        await _unitOfWork.CommitAsync();

        return new DeliveryDTO(delivery.Id.AsGuid(), delivery.DeliveryId.DeliveryIdentifier, delivery.DeliveryDate.Day, delivery.DeliveryDate.Month,
            delivery.DeliveryDate.Year, delivery.DeliveryMass.Mass, delivery.DeliveryTime.placingTime, delivery.WarehouseId.ToString(),
            delivery.DeliveryTime.withdrawalTime);
    }
}