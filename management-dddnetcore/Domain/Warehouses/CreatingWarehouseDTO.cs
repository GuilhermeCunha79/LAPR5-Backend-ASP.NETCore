namespace DDDNetCore.Domain.Warehouses;

public class CreatingWarehouseDTO
{
    public string WarehouseIdentifier { get; set; }
    public string Designation { get; set; }
    public string Street { get; set; }
    public int Number { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public float Altitude { get; set; }

    public CreatingWarehouseDTO(string warehouseIdentifier, string designation, string street, int number,
        string postalCode, string country,
        float latitude, float longitude, float altitude)
    {
        WarehouseIdentifier = warehouseIdentifier;
        Designation = designation;
        Street = street;
        Number = number;
        PostalCode = postalCode;
        Country = country;
        Latitude = latitude;
        Longitude = longitude;
        Altitude = altitude;
    }
}