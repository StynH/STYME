using AwesomeAssertions;

namespace STYME.UnitTests.NaturalDateTimeTests;

[TestClass]
public sealed class NaturalDateTimeNextTests
{
    [TestMethod]
    public void Given_2025_01_01T10_00_00_When_Parsing_Next_Monday_Then_Returns_2025_01_06T10_00_00()
    {
        var baseDate = new DateTime(2025, 1, 1, 10, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("next monday");

        result.Should().Be(new DateTime(2025, 1, 6, 10, 0, 0));
    }

    [TestMethod]
    public void Given_2025_01_06T10_00_00_When_Parsing_Next_Monday_Then_Returns_2025_01_13T10_00_00()
    {
        var baseDate = new DateTime(2025, 1, 6, 10, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("next Monday");

        result.Should().Be(new DateTime(2025, 1, 13, 10, 0, 0));
    }

    [TestMethod]
    public void Given_2025_01_01T10_30_00_When_Parsing_Next_February_Then_Returns_2025_02_01T10_30_00()
    {
        var baseDate = new DateTime(2025, 1, 1, 10, 30, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("next february");

        result.Should().Be(new DateTime(2025, 2, 1, 10, 30, 0));
    }

    [TestMethod]
    public void Given_2025_12_31T23_15_45_When_Parsing_Next_February_Then_Returns_2026_02_28T23_15_45()
    {
        var baseDate = new DateTime(2025, 12, 31, 23, 15, 45);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("next February");

        result.Should().Be(new DateTime(2026, 2, 28, 23, 15, 45));
    }

    [TestMethod]
    public void Given_2025_01_01T08_00_00_When_Parsing_Next_Friday_And_Adding_2_Hours_Then_Returns_2025_01_03T10_00_00()
    {
        var baseDate = new DateTime(2025, 1, 1, 8, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("next friday and add 2 hours");

        result.Should().Be(new DateTime(2025, 1, 3, 10, 0, 0));
    }
}

