using DDDSample1.Domain.Delivery;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;
using Moq;

namespace DDDNetCore.Tests.Domain.Delivery;

public class DeliveryServiceTest
{
    [Fact]
    public async void GetAllAsyncTest()
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
        
        var delivery = new DDDSample1.Domain.Delivery.Delivery(deliveryIdentifier,day,month,year,mass,storeId,placingTime,withdrawalTime);
        var deliveryDto = new DeliveryDTO(delivery.Id.AsGuid(), deliveryIdentifier, day, month, year, mass, placingTime, storeId, withdrawalTime);
        
        var deliveryDtoList = new List<DeliveryDTO> { deliveryDto };
        var deliveryList = new List<DDDSample1.Domain.Delivery.Delivery> { delivery };

        repo.Setup(_ => _.GetAllAsync()).ReturnsAsync(deliveryList);
        
        var deliveryService = new DeliveryService(unit.Object, repo.Object);
        
        var actual = await deliveryService.GetAllAsync();

        Assert.Equal(deliveryDtoList.Count, actual.Count);
    }

    // [Fact]
    // public async void GetByIdAsyncTest()
    // {
    //     var repo = new Mock<IDeliveryRepository>();
    //     var unit = new Mock<IUnitOfWork>();
    //
    //     string deliveryIdentifier = "21ddd3";
    //     int day = 2;
    //     string month = "january";
    //     int year = 2002;
    //     int mass = 23;
    //     string storeId = "144";
    //     int withdrawalTime = 2;
    //     int placingTime = 3;
    //     
    //     var delivery = new DDDSample1.Domain.Delivery.Delivery(deliveryIdentifier,day,month,year,mass,storeId,placingTime,withdrawalTime);
    //     var deliveryDto = new DeliveryDTO(delivery.Id.AsGuid(), deliveryIdentifier, day, month, year, mass, placingTime, storeId, withdrawalTime);
    //
    //     var deliveryService = new DeliveryService(unit.Object, repo.Object);
    //
    //     var actual = await deliveryService.GetByIdAsync(delivery.Id);
    //
    //     Assert.Equal(deliveryDto, actual);
    // }
    //
    // [Fact]
    // public async void GetByDeliveryIdAsyncTest()
    // {
    //     var repo = new Mock<IDeliveryRepository>();
    //     var unit = new Mock<IUnitOfWork>();
    //
    //     string deliveryIdentifier = "21ddd3";
    //     int day = 2;
    //     string month = "january";
    //     int year = 2002;
    //     int mass = 23;
    //     string storeId = "144";
    //     int withdrawalTime = 2;
    //     int placingTime = 3;
    //     
    //     var delivery = new DDDSample1.Domain.Delivery.Delivery(deliveryIdentifier,day,month,year,mass,storeId,placingTime,withdrawalTime);
    //     var deliveryDto = new DeliveryDTO(delivery.Id.AsGuid(), deliveryIdentifier, day, month, year, mass, placingTime, storeId, withdrawalTime);
    //
    //     var deliveryService = new DeliveryService(unit.Object, repo.Object);
    //
    //     var actual = await deliveryService.GetByDeliveryIdAsync("21ddd3");
    //
    //     Assert.Equal(deliveryDto, actual);
    // }
    //
    //

    [Fact]
    public async void AddDeliveryTest()
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
        
        var delivery = new DDDSample1.Domain.Delivery.Delivery(deliveryIdentifier,day,month,year,mass,storeId,placingTime,withdrawalTime);
        var deliveryDto = new DeliveryDTO(delivery.Id.AsGuid(), deliveryIdentifier, day, month, year, mass, placingTime, storeId, withdrawalTime);

        repo.Setup(_ => _.AddAsync(delivery)).ReturnsAsync(delivery);

        var driverService = new DeliveryService(unit.Object, repo.Object);

        var actual = await driverService.AddAsync(deliveryDto);

        Assert.Equal(deliveryDto.DeliveryIdentifier, actual.DeliveryIdentifier);
    }
    
    // [Fact]
    // public async void UpdateAsyncTest()
    // {
    //     var repo = new Mock<IDeliveryRepository>();
    //     var unit = new Mock<IUnitOfWork>();
    //
    //     string deliveryIdentifier = "21ddd3";
    //     int day = 2;
    //     string month = "january";
    //     int year = 2002;
    //     int mass = 23;
    //     string storeId = "144";
    //     int withdrawalTime = 2;
    //     int placingTime = 3;
    //     
    //     var delivery = new DDDSample1.Domain.Delivery.Delivery(deliveryIdentifier,day,month,year,mass,storeId,placingTime,withdrawalTime);
    //     var deliveryDto = new DeliveryDTO(delivery.Id.AsGuid(), deliveryIdentifier, day, month, year, mass, placingTime, storeId, withdrawalTime);
    //
    //     repo.Setup(_ => _.AddAsync(delivery)).ReturnsAsync(delivery);
    //
    //     var driverService = new DeliveryService(unit.Object, repo.Object);
    //
    //     delivery.ChangeStoreId(new WarehouseId("123"));
    //     
    //     var actual = await driverService.UpdateAsync(deliveryDto);
    //     Assert.Equal(delivery.WarehouseId.WarehouseIdentifier, actual.StoreId);
    // }
}