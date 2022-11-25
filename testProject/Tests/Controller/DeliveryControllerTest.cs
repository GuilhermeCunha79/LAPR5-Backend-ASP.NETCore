using DDDNetCore.Controllers;
using DDDSample1.Domain.Delivery;
using DDDSample1.Domain.Warehouses;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace testProject.Tests.Controller;

public class DeliveryControllerTest
{
    [Fact]
    public async void GetAll()
    {
        var deliveryServiceMock = new Mock<IDeliveryService>();
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


        deliveryServiceMock.Setup(_ => _.GetAllAsync()).ReturnsAsync(deliveryDtoList);

        var controller = new DeliveryController(deliveryServiceMock.Object);

        var actual = await controller.GetAll();

        Assert.Equal(deliveryDtoList, actual.Value);
        
    }
    
    [Fact]
    public async void GetByDeliveryIdentifier()
    {
        var deliveryServiceMock = new Mock<IDeliveryService>();
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
        
        deliveryServiceMock.Setup(_ => _.GetByDeliveryIdAsync(deliveryIdentifier)).ReturnsAsync(deliveryDto);
        
        var controller = new DeliveryController(deliveryServiceMock.Object);
        
        var actual = await controller.GetByDeliveryId("21ddd3");

        Assert.Equal (deliveryDto, actual.Value);
    }

    [Fact]
    public async void GetByIdTest()
    {
        var deliveryServiceMock = new Mock<IDeliveryService>();
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
        
        deliveryServiceMock.Setup(_ => _.GetByDeliveryIdAsync(deliveryIdentifier)).ReturnsAsync(deliveryDto);
        
        var controller = new DeliveryController(deliveryServiceMock.Object);
        
        var actual = await controller.GetById(delivery.Id.AsGuid());

        Assert.Equal (deliveryDto, actual.Value);
    }
    
    [Fact]
    public async void Create()
    {
        var deliveryServiceMock = new Mock<IDeliveryService>();
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

        deliveryServiceMock.Setup (_ => _.GetByIdAsync (delivery.Id)).ReturnsAsync (deliveryDto);
        deliveryServiceMock.Setup (_ => _.AddAsync (deliveryDto)).ReturnsAsync (deliveryDto);

           
        var controller = new DeliveryController(deliveryServiceMock.Object);

        var actual = await controller.Create(deliveryDto);

        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
        
    }
}