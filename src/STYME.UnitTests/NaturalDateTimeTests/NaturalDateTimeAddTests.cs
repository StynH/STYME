using AwesomeAssertions;

namespace STYME.UnitTests.NaturalDateTimeTests;

[TestClass]
public sealed class NaturalDateTimeAddTests
{
    [TestMethod]
    public void Given_2025_01_01T10_00_00_When_Adding_1_Day_Then_Returns_2025_01_02T10_00_00()
    {
        var baseDate = new DateTime(2025, 1, 1, 10, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("add 1 day");

        result.Should().Be(new DateTime(2025, 1, 2, 10, 0, 0));
    }

    [TestMethod]
    public void Given_2025_01_01T08_30_00_When_Adding_5_Hours_Then_Returns_2025_01_01T13_30_00()
    {
        var baseDate = new DateTime(2025, 1, 1, 8, 30, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("add 5 hours");

        result.Should().Be(new DateTime(2025, 1, 1, 13, 30, 0));
    }

    [TestMethod]
    public void Given_2020_01_15T00_00_00_When_Adding_1_Month_Then_Returns_2020_02_15T00_00_00()
    {
        var baseDate = new DateTime(2020, 1, 15, 0, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("add 1 month");

        result.Should().Be(new DateTime(2020, 2, 15, 0, 0, 0));
    }

    [TestMethod]
    public void Given_2019_06_10T12_00_00_When_Adding_2_Years_Then_Returns_2021_06_10T12_00_00()
    {
        var baseDate = new DateTime(2019, 6, 10, 12, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("add 2 years");

        result.Should().Be(new DateTime(2021, 6, 10, 12, 0, 0));
    }
}
