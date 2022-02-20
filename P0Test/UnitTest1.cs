using Xunit;
using P0Model;

namespace P0Test;

public class NutrientTest
{
    [Fact]
    public void AgeSetData()
    {
        // Arrange
        Customer c = new Customer();
        int validage = 10;

        //Act
       c.Age = validage; 

       //Assert
       Assert.NotNull(c.Age);
       Assert.Equal(validage, c.Age);
        
    }
    [Fact]
    public void NameSetData1()
    {
        //Arrange
        SmoothieModel smo = new SmoothieModel(1);
        string name = "CoconutFusion";

        //Act
        string _name = smo.Name;

        //Assert
        Assert.NotNull(smo.Name);
        Assert.Equal(name, _name);

    }

    [Fact]
    public void NameSetData2()
    {
        //Arrange
        SmoothieModel smo = new SmoothieModel(2);
        string name = "VeryBerry";

        //Act
        string _name = smo.Name;

        //Assert
        Assert.NotNull(smo.Name);
        Assert.Equal(name, _name);

    }

    [Fact]
    public void NameSetData3()
    {
        //Arrange
        SmoothieModel smo = new SmoothieModel(3);
        string name = "TropicalBreeze";

        //Act
        string _name = smo.Name;

        //Assert
        Assert.NotNull(smo.Name);
        Assert.Equal(name, _name);

    }

    [Fact]
    public void NameSetData4()
    {
        //Arrange
        SmoothieModel smo = new SmoothieModel(4);
        string name = "ProtienShake";

        //Act
        string _name = smo.Name;

        //Assert
        Assert.NotNull(smo.Name);
        Assert.Equal(name, _name);

    }
    [Fact]
    public void ProductPriceSet1()
    {
        //Arrange
        Product pro = new Product("small");
        double expectedPrice = 5.00;

        //Act
        double price = pro.Price;

        //Assert
        Assert.NotNull(pro.Price);
        Assert.Equal(expectedPrice, price);

    }

[Fact]
    public void ProductPriceSet2()
    {
        //Arrange
        Product pro = new Product("medium");
        double expectedPrice = 6.50;

        //Act
        double price = pro.Price;

        //Assert
        Assert.NotNull(pro.Price);
        Assert.Equal(expectedPrice, price);

    }

    [Fact]
    public void ProductPriceSet3()
    {
        //Arrange
        Product pro = new Product("large");
        double expectedPrice = 7.00;

        //Act
        double price = pro.Price;

        //Assert
        Assert.NotNull(pro.Price);
        Assert.Equal(expectedPrice, price);

    }

}