using Xunit;

namespace Wordle.Tests;

public class WordleUnitTests
{
    [Fact]
    public void PassingTest() => Assert.True(true);

    [Fact]
    public void FailingTest() => Assert.True(false);
}