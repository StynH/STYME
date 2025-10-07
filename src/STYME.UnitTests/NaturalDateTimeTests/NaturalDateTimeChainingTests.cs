using AwesomeAssertions;

namespace STYME.UnitTests.NaturalDateTimeTests;

[TestClass]
public sealed class NaturalDateTimeChainingTests
{
    [TestMethod]
    public void Given_2020_01_01T00_00_00_When_Add3DaysAndDeduct5Hours_Then_Returns_2020_01_03T19_00_00()
    {
        var baseDate = new DateTime(2020, 1, 1, 0, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("add 3 days and deduct 5 hours");

        result.Should().Be(new DateTime(2020, 1, 3, 19, 0, 0));
    }

    [TestMethod]
    public void Given_2019_06_10T12_00_00_When_Deduct5YearsAndAdd12Weeks_Then_Returns_2014_09_02T12_00_00()
    {
        var baseDate = new DateTime(2019, 6, 10, 12, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("deduct 5 years and add 12 weeks");

        result.Should().Be(new DateTime(2014, 9, 2, 12, 0, 0));
    }

    [TestMethod]
    public void Given_2025_01_01T08_00_00_When_Add1DayAdd2HoursDeduct30Minutes_Then_Returns_2025_01_02T09_30_00()
    {
        var baseDate = new DateTime(2025, 1, 1, 8, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("add 1 day and add 2 hours and deduct 30 minutes");

        result.Should().Be(new DateTime(2025, 1, 2, 9, 30, 0));
    }

    [TestMethod]
    public void Given_2025_01_01T00_00_00_When_MultipleAnds_Then_ChainedCorrectly()
    {
        var baseDate = new DateTime(2025, 1, 1, 0, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var result = sut.Parse("add 1 day and add 2 hours and add 30 minutes and deduct 15 seconds");

        result.Should().Be(new DateTime(2025, 1, 2, 2, 29, 45));
    }
}
