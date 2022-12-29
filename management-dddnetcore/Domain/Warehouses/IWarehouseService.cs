using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.Warehouses;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Warehouses;

public interface IWarehouseService
{
    Task<List<WarehouseDTO>> GetAllAsync();

    Task<WarehouseDTO> GetByIdAsync(Identifier id);
    Task<WarehouseDTO> GetByWarehouseIdAsync(string warehouseIdentifier);

    Task<WarehouseDTO> GetByDesignationAsync(string designation);
    Task<WarehouseDTO> AddAsync(CreatingWarehouseDTO obj);

    Task<WarehouseDTO> UpdateAsync(WarehouseDTO dto);

    Task<WarehouseDTO> UpdateByWarehouseIdAsync(WarehouseDTO dto);
    Task<WarehouseDTO> InactivateAsync(Identifier id);
    
    Task<WarehouseDTO> ActivateAsync(string id);

    Task<WarehouseDTO> DeleteAsync(Identifier id);
}