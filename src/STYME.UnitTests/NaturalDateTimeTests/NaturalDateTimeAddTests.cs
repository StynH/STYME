using AwesomeAssertions;

namespace STYME.UnitTests.NaturalDateTimeTests;

[TestClass]
public sealed class NaturalDateTimeDeductTests
{
    [TestMethod]
    public void Given_2025_01_01T10_00_00_When_Deducting_1_Day_Then_Returns_2024_12_31T10_00_00()
    {
        var baseDate = new DateTime(2025, 1, 1, 10, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("deduct 1 day");

        result.Should().Be(new DateTime(2024, 12, 31, 10, 0, 0));
    }

    [TestMethod]
    public void Given_2025_01_01T10_00_00_When_Deducting_30_Seconds_Then_Returns_2025_01_01T09_59_30()
    {
        var baseDate = new DateTime(2025, 1, 1, 10, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("deduct 30 seconds");

        result.Should().Be(new DateTime(2025, 1, 1, 9, 59, 30));
    }

    [TestMethod]
    public void Given_2025_01_01T08_30_00_When_Deducting_45_Minutes_Then_Returns_2025_01_01T07_45_00()
    {
        var baseDate = new DateTime(2025, 1, 1, 8, 30, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("deduct 45 minutes");

        result.Should().Be(new DateTime(2025, 1, 1, 7, 45, 0));
    }

    [TestMethod]
    public void Given_2025_01_01T08_30_00_When_Deducting_5_Hours_Then_Returns_2025_01_01T03_30_00()
    {
        var baseDate = new DateTime(2025, 1, 1, 8, 30, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("deduct 5 hours");

        result.Should().Be(new DateTime(2025, 1, 1, 3, 30, 0));
    }

    [TestMethod]
    public void Given_2025_01_01T00_00_00_When_Deducting_2_Weeks_Then_Returns_2024_12_18T00_00_00()
    {
        var baseDate = new DateTime(2025, 1, 1, 0, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("deduct 2 weeks");

        result.Should().Be(new DateTime(2024, 12, 18, 0, 0, 0));
    }

    [TestMethod]
    public void Given_2020_01_15T00_00_00_When_Deducting_1_Month_Then_Returns_2019_12_15T00_00_00()
    {
        var baseDate = new DateTime(2020, 1, 15, 0, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("deduct 1 month");

        result.Should().Be(new DateTime(2019, 12, 15, 0, 0, 0));
    }

    [TestMethod]
    public void Given_2019_06_10T12_00_00_When_Deducting_2_Years_Then_Returns_2017_06_10T12_00_00()
    {
        var baseDate = new DateTime(2019, 6, 10, 12, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("deduct 2 years");

        result.Should().Be(new DateTime(2017, 6, 10, 12, 0, 0));
    }

    [TestMethod]
    public void Given_2000_01_01T00_00_00_When_Deducting_1_Decade_Then_Returns_1990_01_01T00_00_00()
    {
        var baseDate = new DateTime(2000, 1, 1, 0, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("deduct 1 decade");

        result.Should().Be(new DateTime(1990, 1, 1, 0, 0, 0));
    }

    [TestMethod]
    public void Given_1900_01_01T00_00_00_When_Deducting_1_Century_Then_Returns_1800_01_01T00_00_00()
    {
        var baseDate = new DateTime(1900, 1, 1, 0, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("deduct 1 century");

        result.Should().Be(new DateTime(1800, 1, 1, 0, 0, 0));
    }

    [TestMethod]
    public void Given_2000_01_01T00_00_00_When_Deducting_1_Millennium_Then_Returns_1000_01_01T00_00_00()
    {
        var baseDate = new DateTime(2000, 1, 1, 0, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("deduct 1 millennium");

        result.Should().Be(new DateTime(1000, 1, 1, 0, 0, 0));
    }
}
