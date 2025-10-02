namespace STYME.Values.TimeShifts;

internal static class TimeShiftFactory
{
    public static ITimeShift CreateFromUnit(double amount, string unit)
    {
        if (string.IsNullOrWhiteSpace(unit))
        {
            throw new ArgumentException("unit is required", nameof(unit));
        }

        var normalized = unit.Trim().ToLowerInvariant();

        return normalized switch
        {
            "second" or "seconds" => new TimeSpanShift(TimeSpan.FromSeconds(amount)),
            "minute" or "minutes" => new TimeSpanShift(TimeSpan.FromMinutes(amount)),
            "hour" or "hours" => new TimeSpanShift(TimeSpan.FromHours(amount)),
            "day" or "days" => new TimeSpanShift(TimeSpan.FromDays(amount)),
            "week" or "weeks" => new TimeSpanShift(TimeSpan.FromDays(amount * 7)),
            "month" or "months" => new MonthShift((int)amount),
            "year" or "years" => new YearShift((int)amount),
            "decade" or "decades" => new DecadeShift((int)amount),
            "century" or "centuries" => new CenturyShift((int)amount),
            "millennium" or "millennia" or "millenium" => new MillenniumShift((int)amount),
            _ => new TimeSpanShift(TimeSpan.FromDays(amount))
        };
    }
}
