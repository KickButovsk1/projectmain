using FluentAssertions;
using Xunit;

namespace Tests;


public class Test1
{
    [Fact]
    public void TestMethod1()
    {
        var sut = new Calculator();
        
        double result = sut.Sum(10, 20);
        
        result.Should().Be(30);
    }
}