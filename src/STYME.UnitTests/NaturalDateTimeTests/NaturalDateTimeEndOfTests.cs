using AwesomeAssertions;

namespace STYME.UnitTests.NaturalDateTimeTests;

[TestClass]
public sealed class NaturalDateTimeEndOfTests
{
    [TestMethod]
    public void Given_2025_01_15T09_30_00_When_Parsing_End_Of_The_Month_Then_Returns_2025_01_31T09_30_00()
    {
        var baseDate = new DateTime(2025, 1, 15, 9, 30, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("end of the month");

        result.Should().Be(new DateTime(2025, 1, 31, 9, 30, 0));
    }

    [TestMethod]
    public void Given_2024_02_10T15_00_00_When_Parsing_End_Of_Month_Then_Returns_2024_02_29T15_00_00()
    {
        var baseDate = new DateTime(2024, 2, 10, 15, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("end of month");

        result.Should().Be(new DateTime(2024, 2, 29, 15, 0, 0));
    }

    [TestMethod]
    public void Given_2025_06_15T20_45_00_When_Parsing_End_Of_The_Year_Then_Returns_2025_12_31T20_45_00()
    {
        var baseDate = new DateTime(2025, 6, 15, 20, 45, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("end of the year");

        result.Should().Be(new DateTime(2025, 12, 31, 20, 45, 0));
    }

    [TestMethod]
    public void Given_2025_01_08T12_00_00_When_Parsing_End_Of_The_Week_Then_Returns_2025_01_12T12_00_00()
    {
        var baseDate = new DateTime(2025, 1, 8, 12, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("end of the week");

        result.Should().Be(new DateTime(2025, 1, 12, 12, 0, 0));
    }

    [TestMethod]
    public void Given_2025_01_30T22_15_00_When_Parsing_End_Of_The_Month_And_Adding_2_Days_Then_Returns_2025_02_02T22_15_00()
    {
        var baseDate = new DateTime(2025, 1, 30, 22, 15, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("end of the month and add 2 days");

        result.Should().Be(new DateTime(2025, 2, 2, 22, 15, 0));
    }
}

