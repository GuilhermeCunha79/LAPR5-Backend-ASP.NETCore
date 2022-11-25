using System.Linq;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Delivery;

public class DeliveryDate : IValueObject
{
    private int MAX_DAY = 31;
    
    
    private string[] months = {"JANUARY","FEBRUARY","MARCH","APRIL","MAY","JUNE","JULY",
    "AUGUST","SEPTEMBER","OCTOBER","NOVEMBER","DECEMBER"};

    private int ZERO = 0;
    public int Day { get; set; }
    
    public string Month { get; set; }
    
    public int Year { get; set; }

    public DeliveryDate()
    {
        Day = 0;
        Month = "";
        Year = 0;
    }

    public DeliveryDate(int day, string month, int year)
    {
        Day = validateDay(validateYearDay(day));
        Month = validateMonth(month);
        Year = validateYearDay(year);
    }
    
    private int validateYearDay(int i)
    {
        if (i == 0 || i<0)
        {
            throw new BusinessRuleValidationException("Year/Day must be greater than 0.");
        }

        return i;
    }

    private int validateDay(int i)
    {
        if (ZERO < i && i < MAX_DAY)
        {
            return i;
        }
        throw new BusinessRuleValidationException("The day must be between 1 and 31.");
    }
    
    private string validateMonth(string i)
    {
        if (months.Contains(i.ToUpper()))
        {
            return i;
        }
        throw new BusinessRuleValidationException("The month must be valid.");
    }
    
    public override string ToString()
    {
        return Day + " de " + Month + " de " + Year;
    }
    
}