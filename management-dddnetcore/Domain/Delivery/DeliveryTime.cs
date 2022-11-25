using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Delivery;

public class DeliveryTime : IValueObject
{

    
    public int placingTime { get; set; }
    public int withdrawalTime { get; set; }

    public DeliveryTime()
    {
        placingTime = 0;
        withdrawalTime = 0;
    }

    public DeliveryTime(int placingTime, int withdrawalTime)
    {
        this.placingTime = ValidateTime(placingTime);
        this.withdrawalTime = ValidateTime(withdrawalTime);
    }
    
    private static int ValidateTime(int i)
    {
        if (i is < 0 or 0)
        {
            throw new BusinessRuleValidationException("The time of withdrawal/placing time must be higher or equal to 0.");
        }

        return i;
    }


}