using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Delivery;

public class DeliveryMass: IValueObject
{
    public float Mass { get; set; }
    public DeliveryMass()
    {
        Mass = 0;
    }

    public DeliveryMass(float mass)
    {
        Mass = validateMass(mass);
    }
    
    private float validateMass(float i)
    {
        if (i<0)
        {
            throw new BusinessRuleValidationException("Mass cannot be less then 0 kg.");
        }

        return i;
    }
    
    public override string ToString()
    {
        return Mass + " kg";
    }

}