using System;

namespace DDDSample1.Domain.Delivery;

public class DeliveryDTO
{
    public Guid Id;
    
    public int Day { get; set; }

    public string DeliveryIdentifier { get; set; }

    public string Month { get; set; }
    
    public int Year { get; set; }
    
    public float Mass{ get; set; }

    public string StoreId { get; set; }

    public int PlacingTime { get; set; }
    
    public int WithdrawalTime { get; set; }

    public DeliveryDTO(Guid id, string deliveryIdentifier,int day, string month, int year, float mass, int placingTime,string storeId, int withdrawalTime)
    {
        Id = id;
        DeliveryIdentifier = deliveryIdentifier;
        Day = day;
        Month = month;
        Year = year;
        Mass = mass;
        StoreId = storeId;
        PlacingTime = placingTime;
        WithdrawalTime = withdrawalTime;
    }
}