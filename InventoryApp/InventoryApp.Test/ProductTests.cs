using System.Globalization;
using InventoryApp.Model.Models;
using Xunit;

public class ProductTests
{

      public ProductTests()
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
    }
    [Fact]
    public void FullName_ReturnsCorrectValue()
    {
        // Arrange
        var product = new Product
        {
            Code = "ABC",
            Description = "Test Product",
            Weight = 1.5m
        };

        // Act
        var result = product.FullName;

        // Assert
        Assert.Equal("ABC - Test Product - 1.5 kg", result);
    }

    [Fact]
    public void FullName_ReturnsCorrectValue_WhenCodeAndDescriptionAreEmpty()
    {
        // Arrange
        var product = new Product
        {
            Weight = 1.5m
        };

        // Act
        var result = product.FullName;

        // Assert
        Assert.Equal(" -  - 1.5 kg", result);
    }

    [Fact]
    public void FullName_ReturnsCorrectValue_WhenWeightIsZero()
    {
        // Arrange
        var product = new Product
        {
            Code = "ABC",
            Description = "Test Product",
            Weight = 0m
        };

        // Act
        var result = product.FullName;

        // Assert
        Assert.Equal("ABC - Test Product - 0 kg", result);
    }
}