using DDDNetCore.Controllers;
using DDDSample1.Domain.Delivery;
using DDDSample1.Domain.Shared;
using Moq;

namespace testProject.Tests.Controller;

public class DeliveryControllerIntegrationTest
{
    [Fact]
    public async void GetAllTest()
    {
        var repo = new Mock<IDeliveryRepository>();
        var unit = new Mock<IUnitOfWork>();

        string deliveryIdentifier = "21ddd3";
        int day = 2;
        string month = "january";
        int year = 2002;
        int mass = 23;
        string storeId = "144";
        int withdrawalTime = 2;
        int placingTime = 3;
        
        var delivery = new Delivery(deliveryIdentifier,day,month,year,mass,storeId,placingTime,withdrawalTime);
        var deliveryDto = new DeliveryDTO(delivery.Id.AsGuid(), deliveryIdentifier, day, month, year, mass, placingTime, storeId, withdrawalTime);
        
        var deliveryDtoList = new List<DeliveryDTO> { deliveryDto };
        var deliveryList = new List<Delivery> { delivery };

        var deliveryService = new DeliveryService(unit.Object, repo.Object);

        repo.Setup(_ => _.GetAllAsync()).ReturnsAsync(deliveryList);

        var controller = new DeliveryController(deliveryService);

        var actual = await controller.GetAll();
        
        Assert.Equal(deliveryDtoList.Count, actual.Value.Count());
    }

    [Fact]
    public async void CreateTest()
    {
        var repo = new Mock<IDeliveryRepository>();
        var unit = new Mock<IUnitOfWork>();

        string deliveryIdentifier = "21ddd3";
        int day = 2;
        string month = "january";
        int year = 2002;
        int mass = 23;
        string storeId = "144";
        int withdrawalTime = 2;
        int placingTime = 3;
        
        var delivery = new Delivery(deliveryIdentifier,day,month,year,mass,storeId,placingTime,withdrawalTime);
        var deliveryDto = new DeliveryDTO(delivery.Id.AsGuid(), deliveryIdentifier, day, month, year, mass, placingTime, storeId, withdrawalTime);
        
        var deliveryList = new List<Delivery> { delivery };
        
        var deliveryService = new DeliveryService(unit.Object, repo.Object);

        repo.Setup(_ => _.GetAllAsync()).ReturnsAsync(deliveryList);
        var controller = new DeliveryController(deliveryService);
        
        var actual = await controller.Create(deliveryDto);
        
        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
    }
    
    [Fact]
    public async void GetByDeliveryIdTest()
    {
        var repo = new Mock<IDeliveryRepository>();
        var unit = new Mock<IUnitOfWork>();

        string deliveryIdentifier = "21ddd3";
        int day = 2;
        string month = "january";
        int year = 2002;
        int mass = 23;
        string storeId = "144";
        int withdrawalTime = 2;
        int placingTime = 3;
        
        var delivery = new Delivery(deliveryIdentifier,day,month,year,mass,storeId,placingTime,withdrawalTime);
        var deliveryDto = new DeliveryDTO(delivery.Id.AsGuid(), deliveryIdentifier, day, month, year, mass, placingTime, storeId, withdrawalTime);
        
        var deliveryList = new List<Delivery> { delivery };
        
        var deliveryService = new DeliveryService(unit.Object, repo.Object);

        repo.Setup(_ => _.GetAllAsync()).ReturnsAsync(deliveryList);
        var controller = new DeliveryController(deliveryService);
        
        var actual = await controller.GetByDeliveryId(deliveryDto.DeliveryIdentifier);
        
        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
    }
    
    [Fact]
    public async void GetByIdTest()
    {
        var repo = new Mock<IDeliveryRepository>();
        var unit = new Mock<IUnitOfWork>();

        string deliveryIdentifier = "21ddd3";
        int day = 2;
        string month = "january";
        int year = 2002;
        int mass = 23;
        string storeId = "144";
        int withdrawalTime = 2;
        int placingTime = 3;
        
        var delivery = new Delivery(deliveryIdentifier,day,month,year,mass,storeId,placingTime,withdrawalTime);
        var deliveryDto = new DeliveryDTO(delivery.Id.AsGuid(), deliveryIdentifier, day, month, year, mass, placingTime, storeId, withdrawalTime);
        
        var deliveryList = new List<Delivery> { delivery };
        
        var deliveryService = new DeliveryService(unit.Object, repo.Object);

        repo.Setup(_ => _.GetAllAsync()).ReturnsAsync(deliveryList);
        var controller = new DeliveryController(deliveryService);
        
        var actual = await controller.GetById(deliveryDto.Id);
        
        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
    }
    
    [Fact]
    public async void UpdateTest()
    {
        var repo = new Mock<IDeliveryRepository>();
        var unit = new Mock<IUnitOfWork>();

        string deliveryIdentifier = "21ddd3";
        int day = 2;
        string month = "january";
        int year = 2002;
        int mass = 23;
        string storeId = "144";
        int withdrawalTime = 2;
        int placingTime = 3;
        
        var delivery = new Delivery(deliveryIdentifier,day,month,year,mass,storeId,placingTime,withdrawalTime);
        var deliveryDto = new DeliveryDTO(delivery.Id.AsGuid(), deliveryIdentifier, day, month, year, mass, placingTime, storeId, withdrawalTime);
        
        var deliveryList = new List<Delivery> { delivery };
        
        var deliveryService = new DeliveryService(unit.Object, repo.Object);

        repo.Setup(_ => _.GetAllAsync()).ReturnsAsync(deliveryList);
        var controller = new DeliveryController(deliveryService);
        
        var actual = await controller.Update(deliveryDto.Id,deliveryDto);
        
        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
    }
    
    [Fact]
    public async void UpdateByDeliveryIdAsync()
    {
        var repo = new Mock<IDeliveryRepository>();
        var unit = new Mock<IUnitOfWork>();

        string deliveryIdentifier = "21ddd3";
        int day = 2;
        string month = "january";
        int year = 2002;
        int mass = 23;
        string storeId = "144";
        int withdrawalTime = 2;
        int placingTime = 3;
        
        var delivery = new Delivery(deliveryIdentifier,day,month,year,mass,storeId,placingTime,withdrawalTime);
        var deliveryDto = new DeliveryDTO(delivery.Id.AsGuid(), deliveryIdentifier, day, month, year, mass, placingTime, storeId, withdrawalTime);
        
        var deliveryList = new List<Delivery> { delivery };
        
        var deliveryService = new DeliveryService(unit.Object, repo.Object);

        repo.Setup(_ => _.GetAllAsync()).ReturnsAsync(deliveryList);
        var controller = new DeliveryController(deliveryService);
        
        var actual = await controller.UpdateByDeliveryIdAsync(deliveryDto.Id.ToString(),deliveryDto);
        
        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
    }
    
    [Fact]
    public async void SoftDeleteTest()
    {
        var repo = new Mock<IDeliveryRepository>();
        var unit = new Mock<IUnitOfWork>();

        string deliveryIdentifier = "21ddd3";
        int day = 2;
        string month = "january";
        int year = 2002;
        int mass = 23;
        string storeId = "144";
        int withdrawalTime = 2;
        int placingTime = 3;
        
        var delivery = new Delivery(deliveryIdentifier,day,month,year,mass,storeId,placingTime,withdrawalTime);
        var deliveryDto = new DeliveryDTO(delivery.Id.AsGuid(), deliveryIdentifier, day, month, year, mass, placingTime, storeId, withdrawalTime);
        
        var deliveryList = new List<Delivery> { delivery };
        
        var deliveryService = new DeliveryService(unit.Object, repo.Object);

        repo.Setup(_ => _.GetAllAsync()).ReturnsAsync(deliveryList);
        var controller = new DeliveryController(deliveryService);
        
        var actual = await controller.SoftDelete(deliveryDto.Id);
        
        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
    }
    
    [Fact]
    public async void HardDeleteTest()
    {
        var repo = new Mock<IDeliveryRepository>();
        var unit = new Mock<IUnitOfWork>();

        string deliveryIdentifier = "21ddd3";
        int day = 2;
        string month = "january";
        int year = 2002;
        int mass = 23;
        string storeId = "144";
        int withdrawalTime = 2;
        int placingTime = 3;
        
        var delivery = new Delivery(deliveryIdentifier,day,month,year,mass,storeId,placingTime,withdrawalTime);
        var deliveryDto = new DeliveryDTO(delivery.Id.AsGuid(), deliveryIdentifier, day, month, year, mass, placingTime, storeId, withdrawalTime);
        
        var deliveryList = new List<Delivery> { delivery };
        
        var deliveryService = new DeliveryService(unit.Object, repo.Object);

        repo.Setup(_ => _.GetAllAsync()).ReturnsAsync(deliveryList);
        var controller = new DeliveryController(deliveryService);
        
        var actual = await controller.HardDelete(deliveryDto.Id);
        
        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
    }
}