namespace STYME.Handling;

internal interface IMutableTime
{
    IMutableTime Add(TimeSpan value);

    IMutableTime AddMonths(int months);

    IMutableTime AddYears(int years);

    DateTime ToExternal();
}
