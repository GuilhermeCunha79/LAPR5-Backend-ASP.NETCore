using System.Data;
using DDDNetCore.Domain.Warehouses;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;

namespace testProject.Tests.Domain.Warehouses;

public class WarehouseTest
{
    [Fact]
    public void ValidWarehouse()
    {
        string warehouseIdentifier = "33N";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;
        Guid id = new Guid();

        var warehouse = new Warehouse(new WarehouseId(warehouseIdentifier), new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude));

        Assert.True(warehouse.GetType().Equals(new Warehouse().GetType()));
    }

    [Fact]
    public void WarehouseWithoutWarehouseIdentifier()
    {
        string warehouseIdentifier = null;
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;

        Assert.Throws<NullReferenceException>(() => new Warehouse(new WarehouseId(warehouseIdentifier),
            new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude)));
    }

    [Fact]
    public void WarehouseWithWarehouseIdentifierWithMoreThan3Characters()
    {
        string warehouseIdentifier = "W3ED";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "3879-202";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;

        Assert.Throws<BusinessRuleValidationException>(() => new Warehouse(new WarehouseId(warehouseIdentifier),
            new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude)));
    }


    [Fact]
    public void WarehouseWithNullAddress()
    {
        string warehouseIdentifier = "WED";
        string designation = "armazem";
        string street = null;
        int number = 0;
        string postalCode = null;
        string country = null;
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;

        Assert.Throws<NullReferenceException>(() => new Warehouse(new WarehouseId(warehouseIdentifier),
            new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude)));
    }

    [Fact]
    public void WarehouseWithWrongPostalCode()
    {
        string warehouseIdentifier = "WED";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "38739-2024";
        string country = "Porto Portugal";
        float latitude = 72;
        float longitude = 34;
        float altitude = 2;

        Assert.Throws<FormatException>(() => new Warehouse(new WarehouseId(warehouseIdentifier),
            new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude)));
    }

    [Fact]
    public void WarehouseWithWrongAltitude()
    {
        string warehouseIdentifier = "WED";
        string designation = "armazem";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "38739-2024";
        string country = "Porto Portugal";
        float latitude = 0;
        float longitude = 0;
        float altitude = -2;

        Assert.Throws<ArgumentOutOfRangeException>(() => new Warehouse(new WarehouseId(warehouseIdentifier),
            new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude)));
    }

    [Fact]
    public void WarehouseWithWrongDesignation()
    {
        string warehouseIdentifier = "WED";
        string designation =
            "armazemghghgfuhfgvghcvgggggggggggggfffffffffffffffffffffffffffffffffffffffffffuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuttttttttttttttttttttttttttttttttffffffffffffffffffffffffffff";
        string street = "rua das oliveiras";
        int number = 2;
        string postalCode = "38739-2024";
        string country = "Porto Portugal";
        float latitude = 0;
        float longitude = 0;
        float altitude = 2;

        Assert.Throws<BusinessRuleValidationException>(() => new Warehouse(new WarehouseId(warehouseIdentifier),
            new WarehouseDesignation(designation),
            street, number, postalCode, country, latitude, longitude, new Altitude(altitude)));
    }
}