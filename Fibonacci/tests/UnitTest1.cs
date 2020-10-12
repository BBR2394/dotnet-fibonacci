using System;
using Xunit;
namespace Fibonacci.Tests
{
    public class FibonacciUnitTest
    {
    [Fact]
    public void Execute44ShouldRetrun701408733()
    {
        var result = Compute.Execute(new[] {"44"});
        Assert.Equal(701408733, result[0]); }
    }
}
