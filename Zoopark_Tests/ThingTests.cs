using Zoopark_ERP.Things;

namespace Zoopark_Tests;

public class ThingTests
{
    [Fact]
    public void Table_Constructor_SetsProperties()
    {
        var table = new Table("Стол", 201);
        Assert.Equal("Стол", table.Name);
        Assert.Equal(201, table.Number);
    }

    [Fact]
    public void Computer_Constructor_SetsProperties()
    {
        var computer = new Computer("Компьютер", 202);
        Assert.Equal("Компьютер", computer.Name);
        Assert.Equal(202, computer.Number);
    }
}
