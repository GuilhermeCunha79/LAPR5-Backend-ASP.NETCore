using System.Collections.Generic;
using System.Threading.Tasks;
using DDDNetCore.Domain.Warehouses;
using DDDSample1.Domain.Shared;


namespace DDDSample1.Domain.Warehouses
{
    public interface IWarehouseRepository:IRepository<Warehouse,Identifier>
    {
        Task<Warehouse> GetByWarehouseIdAsync(string warehouseIdentifier);
        
        Task<Warehouse> GetByDesignationAsync(string designation);
        Task<List<WarehouseDTO>> GetByIdsAsync(List<WarehouseId> ids);
        Task<WarehouseDTO> AddAsync(WarehouseDTO obj);

    }
}