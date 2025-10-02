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
    public void Given_2025_01_01T10_00_00_When_Adding_30_Seconds_Then_Returns_2025_01_01T10_00_30()
    {
        var baseDate = new DateTime(2025, 1, 1, 10, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("add 30 seconds");

        result.Should().Be(new DateTime(2025, 1, 1, 10, 0, 30));
    }

    [TestMethod]
    public void Given_2025_01_01T08_30_00_When_Adding_45_Minutes_Then_Returns_2025_01_01T09_15_00()
    {
        var baseDate = new DateTime(2025, 1, 1, 8, 30, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("add 45 minutes");

        result.Should().Be(new DateTime(2025, 1, 1, 9, 15, 0));
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
    public void Given_2025_01_01T00_00_00_When_Adding_2_Weeks_Then_Returns_2025_01_15T00_00_00()
    {
        var baseDate = new DateTime(2025, 1, 1, 0, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("add 2 weeks");

        result.Should().Be(new DateTime(2025, 1, 15, 0, 0, 0));
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

    [TestMethod]
    public void Given_2000_01_01T00_00_00_When_Adding_1_Decade_Then_Returns_2010_01_01T00_00_00()
    {
        var baseDate = new DateTime(2000, 1, 1, 0, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("add 1 decade");

        result.Should().Be(new DateTime(2010, 1, 1, 0, 0, 0));
    }

    [TestMethod]
    public void Given_1900_01_01T00_00_00_When_Adding_1_Century_Then_Returns_2000_01_01T00_00_00()
    {
        var baseDate = new DateTime(1900, 1, 1, 0, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("add 1 century");

        result.Should().Be(new DateTime(2000, 1, 1, 0, 0, 0));
    }

    [TestMethod]
    public void Given_1000_01_01T00_00_00_When_Adding_1_Millennium_Then_Returns_2000_01_01T00_00_00()
    {
        var baseDate = new DateTime(1000, 1, 1, 0, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("add 1 millennium");

        result.Should().Be(new DateTime(2000, 1, 1, 0, 0, 0));
    }
}
