using DDDNetCore.Domain.Warehouses;

namespace testProject.Tests.Domain.Warehouses;

using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;
using Moq;

public class WarehouseServiceTest
{
    private Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
    private Mock<IWarehouseRepository> _repoMock = new Mock<IWarehouseRepository>();
    
    public List<Warehouse> Warehouses()
    {
        return new List<Warehouse>
        {
            new Warehouse(new WarehouseId("M45"),
                new WarehouseDesignation("Armazem"), "rua das oliveiras", 2, "3879-202", "Porto Portugal", 72,
                34, new Altitude(2)),
            new Warehouse(new WarehouseId("3F5"),
                new WarehouseDesignation("Armazem2"), "rua das cavadas", 34, "3179-202", " Portugal", 52,
                64, new Altitude(8))
        };
    }

    public List<WarehouseDTO> WarehousesDTO()
    {
        var warehouse1 = new Warehouse(new WarehouseId("M45"),
            new WarehouseDesignation("Armazem"), "rua das oliveiras", 2, "3879-202", "Porto Portugal", 72,
            34, new Altitude(2));
        var warehouse2 = new Warehouse(new WarehouseId("3F5"),
            new WarehouseDesignation("Armazem2"), "rua das cavadas", 34, "3179-202", " Portugal", 52,
            64, new Altitude(8));
        string status = "Active";

        return new List<WarehouseDTO>
        {
            new WarehouseDTO(warehouse1.Id.AsGuid(), warehouse1.WarehouseIdentifier.WarehouseIdentifier,
                warehouse1.WarehouseDesignation.Text, warehouse1.WarehouseAddress.Street,
                warehouse1.WarehouseAddress.Number,
                warehouse1.WarehouseAddress.PostalCode, warehouse1.WarehouseAddress.Country,
                warehouse1.WarehouseCoordinates.Latitude, warehouse1.WarehouseCoordinates.Longitude,
                warehouse1.Altitude.AltitudeValue,status),
            new WarehouseDTO(warehouse2.Id.AsGuid(), warehouse2.WarehouseIdentifier.WarehouseIdentifier,
                warehouse2.WarehouseDesignation.Text, warehouse2.WarehouseAddress.Street,
                warehouse2.WarehouseAddress.Number,
                warehouse2.WarehouseAddress.PostalCode, warehouse2.WarehouseAddress.Country,
                warehouse2.WarehouseCoordinates.Latitude, warehouse2.WarehouseCoordinates.Longitude,
                warehouse2.Altitude.AltitudeValue,status)
        };
    }

    public Warehouse Warehouse()
    {
        return new Warehouse(new WarehouseId("2F4"),
            new WarehouseDesignation("Armazem"), "rua das oliveiras", 2, "3879-202", "Porto Portugal", 72,
            34, new Altitude(2));
    }
    public Warehouse Warehouse2()
    {
        return new Warehouse(new WarehouseId("26E"),
            new WarehouseDesignation("Armazem"), "rua das oliveiras", 2, "3879-202", "Porto Portugal", 72,
            34, new Altitude(2));
    }

    [Fact]
    public async Task GetAllAsyncTest()
    {
        var warehouseList = Warehouses();
        this._repoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(warehouseList);
        var _service = new WarehouseService(_unitOfWorkMock.Object, _repoMock.Object);
        var list = await _service.GetAllAsync();


        Assert.Equal("M45", list[0].WarehouseIdentifier);
        Assert.Equal("3F5", list[1].WarehouseIdentifier);
        Assert.Equal(2, list.Count);
    }
    
    [Fact]
    public async Task GetByIdAsyncTest() 
    {
        var warehouse = Warehouse2();
        this._repoMock.Setup(repo => repo.GetByIdAsync(warehouse.Id))
            .ReturnsAsync(warehouse);
        var _service = new WarehouseService(_unitOfWorkMock.Object, _repoMock.Object);
        var get_warehouse = await _service.GetByIdAsync(warehouse.Id);

        Assert.Equal(warehouse.Id.Value, get_warehouse.Id.ToString());

    }

    [Fact]
    public async Task GetByWarehouseIdAsync() 
    {
        var warehouse = Warehouse();
        this._repoMock.Setup(repo => repo.GetByWarehouseIdAsync(warehouse.WarehouseIdentifier.WarehouseIdentifier))
            .ReturnsAsync(warehouse);
        var _service = new WarehouseService(_unitOfWorkMock.Object, _repoMock.Object);
        var get_warehouse = await _service.GetByWarehouseIdAsync(warehouse.WarehouseIdentifier.WarehouseIdentifier);

        Assert.Equal(warehouse.WarehouseIdentifier.WarehouseIdentifier, get_warehouse.WarehouseIdentifier);
    }
    
    [Fact]
    public async Task GetByDesignationAsyncTest() 
    {
        var warehouse = Warehouse();
        this._repoMock.Setup(repo => repo.GetByDesignationAsync(warehouse.WarehouseDesignation.Text))
            .ReturnsAsync(warehouse);
        var _service = new WarehouseService(_unitOfWorkMock.Object, _repoMock.Object);
        var get_warehouse = await _service.GetByDesignationAsync(warehouse.WarehouseDesignation.Text);

        Assert.Equal(warehouse.WarehouseDesignation.Text, get_warehouse.Designation);
    }

    
    // [Fact]
    // public async Task Inactivate() 
    // {
    //     var warehouse = Warehouse();
    //     this._repoMock.Setup(repo => repo.GetByDesignationAsync(warehouse.WarehouseDesignation.Text))
    //         .ReturnsAsync(warehouse);
    //     var _service = new WarehouseService(_unitOfWorkMock.Object, _repoMock.Object);
    //     var get_warehouse = await _service.InactivateAsync(warehouse.Id);
    //
    //     Assert.Equal("Inactive", get_warehouse.Status);
    // }
    //
    // [Fact]
    // public async Task Activate() 
    // {
    //     var warehouse = Warehouse();
    //     this._repoMock.Setup(repo => repo.GetByDesignationAsync(warehouse.WarehouseDesignation.Text))
    //         .ReturnsAsync(warehouse);
    //     var _service = new WarehouseService(_unitOfWorkMock.Object, _repoMock.Object);
    //     var get_warehouse = await _service.ActivateAsync(warehouse.WarehouseIdentifier.WarehouseIdentifier);
    //
    //     Assert.Equal("Active", get_warehouse.Status);
    // }
    [Fact]
    public async Task AddAsyncTest()
    {
        var warehouse = Warehouse();
        this._repoMock.Setup(repo => repo.AddAsync(warehouse)).ReturnsAsync(warehouse);
        var _service = new WarehouseService(_unitOfWorkMock.Object, _repoMock.Object);
        var get_warehouse = await _service.AddAsync(new CreatingWarehouseDTO(
            warehouse.WarehouseIdentifier.WarehouseIdentifier, warehouse.WarehouseDesignation.Text,
            warehouse.WarehouseAddress.Street,
            warehouse.WarehouseAddress.Number,
            warehouse.WarehouseAddress.PostalCode, warehouse.WarehouseAddress.Country,
            warehouse.WarehouseCoordinates.Latitude, warehouse.WarehouseCoordinates.Longitude,
            warehouse.Altitude.AltitudeValue));

        Assert.Equal("2F4", get_warehouse.WarehouseIdentifier);
    }

}