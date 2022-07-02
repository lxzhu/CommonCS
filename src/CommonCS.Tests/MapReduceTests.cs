namespace CommonCS.Tests;
using System.Linq;

[TestClass]
public class MapReduceTests
{
    [TestMethod]
    public void WordCount()
    {
        var text = "USA China USA China";
        var words = text.Split(' ');
        var results = words
             .Map(x => x)
             .Reduce((key, elements) => elements.Count())
             .ToDictionary(x => x.Key, y => y.Value);

        results["USA"].Should().Be(2);
    }

    [TestMethod]
    public void ArraySum()
    {
        var items = new int[] { 1, 3, 4 };
        var result = items.Reduce(0, (x, y) => x + y);
        result.Should().Be(8);
    }
}