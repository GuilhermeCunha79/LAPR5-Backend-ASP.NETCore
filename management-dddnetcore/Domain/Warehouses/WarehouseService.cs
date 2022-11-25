using System.Threading.Tasks;
using System.Collections.Generic;
using DDDNetCore.Domain.Warehouses;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Warehouses
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWarehouseRepository _repo;

        public WarehouseService(IUnitOfWork unitOfWork, IWarehouseRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

        public async Task<List<WarehouseDTO>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();

            List<WarehouseDTO> listDto = list.ConvertAll(warehouse =>
                new WarehouseDTO(warehouse.Id.AsGuid(), warehouse.WarehouseIdentifier.ToString(),
                    warehouse.WarehouseDesignation.ToString(),
                    warehouse.WarehouseAddress.Street, warehouse.WarehouseAddress.Number,
                    warehouse.WarehouseAddress.PostalCode, warehouse.WarehouseAddress.Country,
                    warehouse.WarehouseCoordinates.Latitude, warehouse.WarehouseCoordinates.Longitude,
                    warehouse.Altitude.AltitudeValue));

            return listDto;
        }

        public async Task<WarehouseDTO> GetByIdAsync(Identifier id)
        {
            var warehouse = await this._repo.GetByIdAsync(id);

            if (warehouse == null)
                return null;

            return new WarehouseDTO(warehouse.Id.AsGuid(), warehouse.WarehouseIdentifier.ToString(),
                warehouse.WarehouseDesignation.ToString(),
                warehouse.WarehouseAddress.Street, warehouse.WarehouseAddress.Number,
                warehouse.WarehouseAddress.PostalCode, warehouse.WarehouseAddress.Country,
                warehouse.WarehouseCoordinates.Latitude, warehouse.WarehouseCoordinates.Longitude,
                warehouse.Altitude.AltitudeValue);
        }

        public async Task<WarehouseDTO> GetByWarehouseIdAsync(string warehouseIdentifier)
        {
            var warehouse = await this._repo.GetByWarehouseIdAsync(warehouseIdentifier);

            if (warehouse == null)
                return null;

            return new WarehouseDTO(warehouse.Id.AsGuid(), warehouse.WarehouseIdentifier.ToString(),
                warehouse.WarehouseDesignation.ToString(),
                warehouse.WarehouseAddress.Street, warehouse.WarehouseAddress.Number,
                warehouse.WarehouseAddress.PostalCode, warehouse.WarehouseAddress.Country,
                warehouse.WarehouseCoordinates.Latitude, warehouse.WarehouseCoordinates.Longitude,
                warehouse.Altitude.AltitudeValue);
        }

        public async Task<WarehouseDTO> GetByDesignationAsync(string designation)
        {
            var warehouse = await this._repo.GetByDesignationAsync(designation);

            if (warehouse == null)
                return null;

            return new WarehouseDTO(warehouse.Id.AsGuid(), warehouse.WarehouseIdentifier.ToString(),
                warehouse.WarehouseDesignation.ToString(),
                warehouse.WarehouseAddress.Street, warehouse.WarehouseAddress.Number,
                warehouse.WarehouseAddress.PostalCode, warehouse.WarehouseAddress.Country,
                warehouse.WarehouseCoordinates.Latitude, warehouse.WarehouseCoordinates.Longitude,
                warehouse.Altitude.AltitudeValue);
        }

        public async Task<WarehouseDTO> AddAsync(CreatingWarehouseDTO dto)
        {
            var warehouse = new Warehouse(new WarehouseId(dto.WarehouseIdentifier),
                new WarehouseDesignation(dto.Designation), dto.Street, dto.Number,
                dto.PostalCode, dto.Country, dto.Latitude, dto.Longitude, new Altitude(dto.Altitude));

            await this._repo.AddAsync(warehouse);

            await this._unitOfWork.CommitAsync();

            return new WarehouseDTO(warehouse.Id.AsGuid(), warehouse.WarehouseIdentifier.ToString(),
                warehouse.WarehouseDesignation.ToString(),
                warehouse.WarehouseAddress.Street, warehouse.WarehouseAddress.Number,
                warehouse.WarehouseAddress.PostalCode, warehouse.WarehouseAddress.Country,
                warehouse.WarehouseCoordinates.Latitude, warehouse.WarehouseCoordinates.Longitude,
                warehouse.Altitude.AltitudeValue);
        }

        public async Task<WarehouseDTO> UpdateAsync(WarehouseDTO dto)
        {
            var warehouse = await this._repo.GetByIdAsync(new Identifier(dto.Id));

            if (warehouse == null)
                return null;

            warehouse.ChangeDesignation(new WarehouseDesignation(dto.Designation));
            warehouse.ChangeAddress(dto.Street, dto.Number, dto.PostalCode, dto.Country);
            warehouse.ChangeCoordinates(dto.Latitude, dto.Longitude);
            warehouse.ChangeAltitude(dto.Altitude);

            await this._unitOfWork.CommitAsync();

            return new WarehouseDTO(warehouse.Id.AsGuid(), warehouse.WarehouseIdentifier.ToString(),
                warehouse.WarehouseDesignation.ToString(),
                warehouse.WarehouseAddress.Street, warehouse.WarehouseAddress.Number,
                warehouse.WarehouseAddress.PostalCode, warehouse.WarehouseAddress.Country,
                warehouse.WarehouseCoordinates.Latitude, warehouse.WarehouseCoordinates.Longitude,
                warehouse.Altitude.AltitudeValue);
        }

        public async Task<WarehouseDTO> UpdateByWarehouseIdAsync(WarehouseDTO dto)
        {
            var warehouse = await this._repo.GetByWarehouseIdAsync(dto.WarehouseIdentifier.ToString());

            if (warehouse == null)
                return null;

            warehouse.ChangeDesignation(new WarehouseDesignation(dto.Designation));
            warehouse.ChangeAddress(dto.Street, dto.Number, dto.PostalCode, dto.Country);
            warehouse.ChangeCoordinates(dto.Latitude, dto.Longitude);
            warehouse.ChangeAltitude(dto.Altitude);

            await this._unitOfWork.CommitAsync();

            return new WarehouseDTO(warehouse.Id.AsGuid(), warehouse.WarehouseIdentifier.ToString(),
                warehouse.WarehouseDesignation.ToString(),
                warehouse.WarehouseAddress.Street, warehouse.WarehouseAddress.Number,
                warehouse.WarehouseAddress.PostalCode, warehouse.WarehouseAddress.Country,
                warehouse.WarehouseCoordinates.Latitude, warehouse.WarehouseCoordinates.Longitude,
                warehouse.Altitude.AltitudeValue);
        }

        public async Task<WarehouseDTO> InactivateAsync(Identifier id)
        {
            var warehouse = await this._repo.GetByIdAsync(id);

            if (warehouse == null)
                return null;

            warehouse.MarkAsInative();

            await this._unitOfWork.CommitAsync();

            return new WarehouseDTO(warehouse.Id.AsGuid(), warehouse.WarehouseIdentifier.ToString(),
                warehouse.WarehouseDesignation.ToString(),
                warehouse.WarehouseAddress.Street, warehouse.WarehouseAddress.Number,
                warehouse.WarehouseAddress.PostalCode, warehouse.WarehouseAddress.Country,
                warehouse.WarehouseCoordinates.Latitude, warehouse.WarehouseCoordinates.Longitude,
                warehouse.Altitude.AltitudeValue);
        }

        public async Task<WarehouseDTO> DeleteAsync(Identifier id)
        {
            var warehouse = await this._repo.GetByIdAsync(id);

            if (warehouse == null)
                return null;

            if (warehouse.Active)
                throw new BusinessRuleValidationException("It is not possible to delete an active warehouse.");

            this._repo.Remove(warehouse);
            await this._unitOfWork.CommitAsync();

            return new WarehouseDTO(warehouse.Id.AsGuid(), warehouse.WarehouseDesignation.ToString(),
                warehouse.WarehouseDesignation.ToString(),
                warehouse.WarehouseAddress.Street, warehouse.WarehouseAddress.Number,
                warehouse.WarehouseAddress.PostalCode, warehouse.WarehouseAddress.Country,
                warehouse.WarehouseCoordinates.Latitude, warehouse.WarehouseCoordinates.Longitude,
                warehouse.Altitude.AltitudeValue);
        }
    }
}