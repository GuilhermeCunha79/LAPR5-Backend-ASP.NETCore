using System;
using DDDSample1.Domain.Delivery;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;
using Xunit;


namespace DDDNetCore.Tests.Domain.Delivery
{
    public class DeliveryTest
    {
        [Fact]
        public void ValidDelivery()
        {
            int day = 2;
            string deliveryIdentifier = "21ddd3";
            string month = "january";
            int year = 2002;
            int mass = 23;
            string storeId = "144";
            int withdrawalTime = 2;
            int placingTime = 3;
            var delivery = new DDDSample1.Domain.Delivery.Delivery(deliveryIdentifier,day,month,year,mass,storeId,placingTime,withdrawalTime);

            Assert.True(delivery.GetType().Equals(new DDDSample1.Domain.Delivery.Delivery().GetType()));
        }
        
        [Fact]
        public void DeliveryWithoutValidMass()
        {
            string deliveryIdentifier = "21ddd3";
            int day = 2;
            string month = "january";
            int year = 2002;
            float mass = -2;
            string storeId = "144";
            int withdrawalTime = 2;
            int placingTime = 3;

            Assert.Throws<BusinessRuleValidationException>(()=> new DDDSample1.Domain.Delivery.Delivery(deliveryIdentifier,day,month,year,mass,storeId,withdrawalTime,placingTime));
        }
        
        [Fact]
        public void DeliveryWithoutValidDay()
        {
            string deliveryId = "21ddd3";
            int day = 32;
            string month = "january";
            int year = 2002;
            float mass = 2;
            string storeId = "144";
            int withdrawalTime = 2;
            int placingTime = 3;

            Assert.Throws<BusinessRuleValidationException>(()=> new DDDSample1.Domain.Delivery.Delivery(deliveryId,day,month,year,mass,storeId,withdrawalTime,placingTime));
        }
        
        [Fact]
        public void DeliveryWithoutValidMonth()
        {
            string deliveryIdentifier = "21ddd3";
            int day = 2;
            string month = "januaryy";
            int year = 2002;
            float mass = 2;
            string storeId = "144";
            int withdrawalTime = 2;
            int placingTime = 3;

            Assert.Throws<BusinessRuleValidationException>(()=> new DDDSample1.Domain.Delivery.Delivery(deliveryIdentifier,day,month,year,mass,storeId,withdrawalTime,placingTime));
        }
        
        [Fact]
        public void DeliveryWithoutValidYear()
        {
            string deliveryId = "21ddd3";
            int day = 2;
            string month = "january";
            int year = -2;
            int mass = 2;
            string storeId = "144";
            int withdrawalTime = 2;
            int placingTime = 3;

            Assert.Throws<BusinessRuleValidationException>(()=> new DDDSample1.Domain.Delivery.Delivery(deliveryId,day,month,year,mass,storeId,withdrawalTime,placingTime));
        }
        
        [Fact]
        public void DeliveryWithoutValidWarehouseId()
        {
            string deliveryIdentifier = "21ddd3";
            int day = 2;
            string month = "january";
            int year = 2;
            int mass = 2;
            string storeId = "1446";
            int withdrawalTime = 2;
            int placingTime = 3;

            Assert.Throws<BusinessRuleValidationException>(()=> new DDDSample1.Domain.Delivery.Delivery(deliveryIdentifier,day,month,year,mass,storeId,withdrawalTime,placingTime));
        }
        
        [Fact]
        public void DeliveryWithoutValidWithdrawalTime()
        {
            string deliveryIdentifier = "21ddd3";
            int day = 2;
            string month = "january";
            int year = 2;
            int mass = 2;
            string storeId = "146";
            int withdrawalTime = -1;
            int placingTime = 3;

            Assert.Throws<BusinessRuleValidationException>(()=> new DDDSample1.Domain.Delivery.Delivery(deliveryIdentifier,day,month,year,mass,storeId,withdrawalTime,placingTime));
        }
        
        [Fact]
        public void DeliveryWithoutValidPlacingTime()
        {
            string deliveryIdentifier = "21ddd3";
            int day = 2;
            string month = "january";
            int year = 2;
            int mass = 2;
            string storeId = "146";
            int withdrawalTime = 1;
            int placingTime = -3;

            Assert.Throws<BusinessRuleValidationException>(()=> new DDDSample1.Domain.Delivery.Delivery(deliveryIdentifier,day,month,year,mass,storeId,withdrawalTime,placingTime));
        }
        
        [Fact]
        public void ChangeStoreIdTest()
        {
            string deliveryIdentifier = "21ddd3";
            int day = 2;
            string month = "january";
            int year = 2;
            int mass = 2;
            string storeId = "146";
            int withdrawalTime = 1;
            int placingTime = 3;

            var delivery = new DDDSample1.Domain.Delivery.Delivery(deliveryIdentifier,day,month,year,mass,storeId,placingTime,withdrawalTime);
            
            delivery.ChangeStoreId(new WarehouseId("123"));
            var change = "123";
            Assert.Equal(delivery.WarehouseId.WarehouseIdentifier,change);
        }
        
        [Fact]
        public void ChangeDeliveryDateTest()
        {
            string deliveryIdentifier = "21ddd3";
            int day = 2;
            string month = "january";
            int year = 2;
            int mass = 2;
            string storeId = "146";
            int withdrawalTime = 1;
            int placingTime = 3;

            var delivery = new DDDSample1.Domain.Delivery.Delivery(deliveryIdentifier,day,month,year,mass,storeId,placingTime,withdrawalTime);
            
            delivery.ChangeDeliveryDate(new DeliveryDate(12,"march",2001));
            var deliveryDate  = new DeliveryDate(12,"march",2001);
            Assert.Equal(delivery.DeliveryDate.Day,deliveryDate.Day);
        }
        
        [Fact]
        public void ChangeDeliveryDateMonthTest()
        {
            string deliveryIdentifier = "21ddd3";
            int day = 2;
            string month = "january";
            int year = 2;
            int mass = 2;
            string storeId = "146";
            int withdrawalTime = 1;
            int placingTime = 3;

            var delivery = new DDDSample1.Domain.Delivery.Delivery(deliveryIdentifier,day,month,year,mass,storeId,placingTime,withdrawalTime);
            
            delivery.ChangeDeliveryDate(new DeliveryDate(12,"march",2001));
            var deliveryDate  = new DeliveryDate(12,"march",2001);
            Assert.Equal(delivery.DeliveryDate.Month,deliveryDate.Month);
        }
        
        [Fact]
        public void ChangeDeliveryDateYearTest()
        {
            string deliveryIdentifier = "21ddd3";
            int day = 2;
            string month = "january";
            int year = 2;
            int mass = 2;
            string storeId = "146";
            int withdrawalTime = 1;
            int placingTime = 3;

            var delivery = new DDDSample1.Domain.Delivery.Delivery(deliveryIdentifier,day,month,year,mass,storeId,placingTime,withdrawalTime);
            
            delivery.ChangeDeliveryDate(new DeliveryDate(12,"march",2001));
            var deliveryDate  = new DeliveryDate(12,"march",2001);
            Assert.Equal(delivery.DeliveryDate.Year,deliveryDate.Year);
        }
        
        [Fact]
        public void ChangeDeliveryMassTest()
        {
            string deliveryIdentifier = "21ddd3";
            int day = 2;
            string month = "january";
            int year = 2;
            int mass = 2;
            string storeId = "146";
            int withdrawalTime = 1;
            int placingTime = 3;

            var delivery = new DDDSample1.Domain.Delivery.Delivery(deliveryIdentifier,day,month,year,mass,storeId,placingTime,withdrawalTime);
            
            delivery.ChangeDeliveryMass(new DeliveryMass(4));
            var change = 4;
            Assert.Equal(delivery.DeliveryMass.Mass,change);
        }
        
        [Fact]
        public void ChangeDeliveryTimeTest()
        {
            string deliveryIdentifier = "21ddd3";
            int day = 2;
            string month = "january";
            int year = 2;
            int mass = 2;
            string storeId = "146";
            int withdrawalTime = 1;
            int placingTime = 3;

            var delivery = new DDDSample1.Domain.Delivery.Delivery(deliveryIdentifier,day,month,year,mass,storeId,placingTime,withdrawalTime);
            
            delivery.ChangeDeliveryTime(new DeliveryTime(4,5));
            var change = new DeliveryTime(4,5);
            Assert.Equal(delivery.DeliveryTime.placingTime,change.placingTime);
        }
        
        [Fact]
        public void MarkAsInactiveTest()
        {
            string deliveryIdentifier = "21ddd3";
            int day = 2;
            string month = "january";
            int year = 2;
            int mass = 2;
            string storeId = "146";
            int withdrawalTime = 1;
            int placingTime = 3;

            var delivery = new DDDSample1.Domain.Delivery.Delivery(deliveryIdentifier,day,month,year,mass,storeId,placingTime,withdrawalTime);
            
            delivery.MarkAsInative();
            
            Assert.Equal(false,delivery.Active);
        }
    }
}