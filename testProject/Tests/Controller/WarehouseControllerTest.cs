using System.Reflection.Metadata;
using DDDNetCore.Controllers;
using DDDNetCore.Domain.Warehouses;
using DDDSample1.Controllers;
using DDDSample1.Domain.Delivery;
using DDDSample1.Domain.Warehouses;
using Moq;

namespace testProject.Tests.Controller;

public class WarehouseControllerTest
{
    [Fact]
    public async void GetAll()
    {
        var driverServiceMock = new Mock<IWarehouseService>();
        string warehouseIdentifier = "33N";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;
        string status = "Active";

        var warehouse = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude));

        var warehouseDto = new WarehouseDTO(warehouse.Id.AsGuid(), warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude,status);

        var warehouseDtoList = new List<WarehouseDTO> { warehouseDto };


        driverServiceMock.Setup(_ => _.GetAllAsync()).ReturnsAsync(warehouseDtoList);

        var controller = new WarehousesController(driverServiceMock.Object);

        var actual = await controller.GetAll();

        Assert.Equal(warehouseDtoList, actual.Value);
    }
    
    [Fact]
    public async void GetByWarehouseIdentifier()
    {
        var driverServiceMock = new Mock<IWarehouseService>();
        string warehouseIdentifier = "33N";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;
        string status = "Active";

        var warehouse = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude));

        var warehouseDto = new WarehouseDTO(warehouse.Id.AsGuid(), warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude,status);

        
        driverServiceMock.Setup(_ => _.GetByWarehouseIdAsync(warehouse.WarehouseIdentifier.WarehouseIdentifier)).ReturnsAsync(warehouseDto);

        var controller = new WarehousesController(driverServiceMock.Object);

        var actual = await controller.GetByWarehouseId("33N");

        Assert.Equal(warehouseDto, actual.Value);
    }
    
    
    [Fact]
    public async void GetByDesignation()
    {
        var driverServiceMock = new Mock<IWarehouseService>();
        string warehouseIdentifier = "33N";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;
        string status = "Active";

        var warehouse = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude));

        var warehouseDto = new WarehouseDTO(warehouse.Id.AsGuid(), warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude,status);

        
        driverServiceMock.Setup(_ => _.GetByDesignationAsync(warehouse.WarehouseDesignation.Text)).ReturnsAsync(warehouseDto);

        var controller = new WarehousesController(driverServiceMock.Object);

        var actual = await controller.GetByDesignation("armazem");

        Assert.Equal(warehouseDto, actual.Value);
    }
    
    [Fact]
    public async void Create()
    {
        var warehouseServiceMock = new Mock<IWarehouseService>();
        string warehouseIdentifier = "09N";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;
        string status = "Active";

        var warehouse = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude));

        var warehouseDto = new WarehouseDTO(warehouse.Id.AsGuid(), warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude,status);
        var cwarehouseDto = new CreatingWarehouseDTO( warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude);

        
       
        warehouseServiceMock.Setup (_ => _.GetByIdAsync (warehouse.Id)).ReturnsAsync (warehouseDto);
        warehouseServiceMock.Setup (_ => _.AddAsync (cwarehouseDto)).ReturnsAsync (warehouseDto);


        var controller = new WarehousesController(warehouseServiceMock.Object);
        
        var actual = await controller.Create(cwarehouseDto);

        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
        
    }
    
    [Fact]
    public async void CreateExistingId()
    {
        var warehouseServiceMock = new Mock<IWarehouseService>();
        string warehouseIdentifier = "09N";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;

        var warehouse1 = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude));
        var warehouse = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude));
        
        string status = "Active";


        var warehouseDto = new WarehouseDTO(warehouse.Id.AsGuid(), warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude,status);
        var cwarehouseDto = new CreatingWarehouseDTO( warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude);

        
       
        warehouseServiceMock.Setup (_ => _.GetByIdAsync (warehouse1.Id)).ReturnsAsync (warehouseDto);
        warehouseServiceMock.Setup (_ => _.AddAsync (cwarehouseDto)).ReturnsAsync (warehouseDto);


        var controller = new WarehousesController(warehouseServiceMock.Object);
        
        var actual = await controller.Create(cwarehouseDto);

        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
        
    }
    
    [Fact]
    public async void UpdateByWarehouseIdTest()
    {
        var warehouseServiceMock = new Mock<IWarehouseService>();
        string warehouseIdentifier = "09N";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;
        string status = "Active";

        var warehouse = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude));

        var warehouseDto = new WarehouseDTO(warehouse.Id.AsGuid(), warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude,status);
        var cwarehouseDto = new CreatingWarehouseDTO( warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude);

        
       
        warehouseServiceMock.Setup (_ => _.GetByIdAsync (warehouse.Id)).ReturnsAsync (warehouseDto);
        warehouseServiceMock.Setup (_ => _.AddAsync (cwarehouseDto)).ReturnsAsync (warehouseDto);


        var controller = new WarehousesController(warehouseServiceMock.Object);
        
        var actual = await controller.UpdateWarehouseAsync(warehouseDto.WarehouseIdentifier,warehouseDto);

        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
        
    }
    
    [Fact]
    public async void UpdateTest()
    {
        var warehouseServiceMock = new Mock<IWarehouseService>();
        string warehouseIdentifier = "09N";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;
        string status = "Active";

        var warehouse = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude));

        var warehouseDto = new WarehouseDTO(warehouse.Id.AsGuid(), warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude,status);
        var cwarehouseDto = new CreatingWarehouseDTO( warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude);

        
       
        warehouseServiceMock.Setup (_ => _.GetByIdAsync (warehouse.Id)).ReturnsAsync (warehouseDto);
        warehouseServiceMock.Setup (_ => _.AddAsync (cwarehouseDto)).ReturnsAsync (warehouseDto);


        var controller = new WarehousesController(warehouseServiceMock.Object);
        
        var actual = await controller.Update(warehouseDto.Id,warehouseDto);

        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
        
    }

    [Fact]
    public async void SoftDeleteTest()
    {
        var warehouseServiceMock = new Mock<IWarehouseService>();
        string warehouseIdentifier = "09N";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;
        string status = "Active";

        var warehouse = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude));

        var warehouseDto = new WarehouseDTO(warehouse.Id.AsGuid(), warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude,status);
        var cwarehouseDto = new CreatingWarehouseDTO( warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude);

        
       
        warehouseServiceMock.Setup (_ => _.GetByIdAsync (warehouse.Id)).ReturnsAsync (warehouseDto);
        warehouseServiceMock.Setup (_ => _.AddAsync (cwarehouseDto)).ReturnsAsync (warehouseDto);


        var controller = new WarehousesController(warehouseServiceMock.Object);
        
        var actual = await controller.SoftDelete(warehouseDto.Id);

        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
        
    }
    
    
    // [Fact]
    // public async void Inactivate()
    // {
    //     var warehouseServiceMock = new Mock<IWarehouseService>();
    //     string warehouseIdentifier = "09N";
    //     string designation = "armazem";
    //     string street = "rua das oliveiras";
    //     int number = 2;
    //     string postalCode = "3879-202";
    //     string country = "Porto Portugal";
    //     float latitude = 72;
    //     float longitude = 34;
    //     float altitude = 2;
    //     string status = "Active";
    //
    //     var warehouse = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
    //         street, number, postalCode, country, latitude, longitude, new Altitude(altitude));
    //
    //     var warehouseDto = new WarehouseDTO(warehouse.Id.AsGuid(), warehouseIdentifier, designation, street, number,
    //         postalCode, country, latitude, longitude, altitude,status);
    //     var cwarehouseDto = new CreatingWarehouseDTO( warehouseIdentifier, designation, street, number,
    //         postalCode, country, latitude, longitude, altitude);
    //
    //     
    //    
    //     warehouseServiceMock.Setup (_ => _.GetByIdAsync (warehouse.Id)).ReturnsAsync (warehouseDto);
    //     warehouseServiceMock.Setup (_ => _.AddAsync (cwarehouseDto)).ReturnsAsync (warehouseDto);
    //
    //
    //     var controller = new WarehousesController(warehouseServiceMock.Object);
    //     
    //     var actual = await controller.SoftDeleteById(warehouseIdentifier);
    //
    //     Assert.NotNull(actual);
    //     Assert.NotNull(actual.Result);
    //     
    // }
    
    [Fact]
    public async void Activate()
    {
        var warehouseServiceMock = new Mock<IWarehouseService>();
        string warehouseIdentifier = "09N";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;
        string status = "Active";

        var warehouse = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude));

        var warehouseDto = new WarehouseDTO(warehouse.Id.AsGuid(), warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude,status);
        var cwarehouseDto = new CreatingWarehouseDTO( warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude);

        
       
        warehouseServiceMock.Setup (_ => _.GetByIdAsync (warehouse.Id)).ReturnsAsync (warehouseDto);
        warehouseServiceMock.Setup (_ => _.AddAsync (cwarehouseDto)).ReturnsAsync (warehouseDto);


        var controller = new WarehousesController(warehouseServiceMock.Object);
        
        var actual = await controller.ActivateById(warehouseIdentifier);

        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
        
    }
    
    [Fact]
    public async void HardDeleteTest()
    {
        var warehouseServiceMock = new Mock<IWarehouseService>();
        string warehouseIdentifier = "09N";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;
        string status = "Active";

        var warehouse = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude));

        var warehouseDto = new WarehouseDTO(warehouse.Id.AsGuid(), warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude,status);

        var cwarehouseDto = new CreatingWarehouseDTO( warehouseIdentifier, designation, street, number,
            postalCode, country, latitude, longitude, altitude);
       
        warehouseServiceMock.Setup (_ => _.GetByIdAsync (warehouse.Id)).ReturnsAsync (warehouseDto);
        warehouseServiceMock.Setup (_ => _.AddAsync (cwarehouseDto)).ReturnsAsync (warehouseDto);


        var controller = new WarehousesController(warehouseServiceMock.Object);
        
        var actual = await controller.HardDelete(warehouseDto.Id);

        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
        
    }
}