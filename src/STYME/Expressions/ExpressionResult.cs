namespace STYME.Expressions;

internal sealed class ExpressionResult
{
    public ExpressionResult(object? value)
    {
        Value = value;
    }

    public static ExpressionResult Empty { get; } = new(null);

    public object? Value { get; }

    public bool HasValue => Value is not null;

    public bool Is<T>()
    {
        return Value is T;
    }

    public bool TryGet<T>(out T value)
    {
        if (Value is T t)
        {
            value = t;
            return true;
        }

        if (Value is null)
        {
            value = default!;
            return true;
        }

        try
        {
            var targetType = typeof(T);

            if (targetType.IsEnum)
            {
                if (Value is string s && Enum.TryParse(targetType, s, true, out var enumObj))
                {
                    value = (T)enumObj!;
                    return true;
                }

                var underlying = Convert.ChangeType(Value, Enum.GetUnderlyingType(targetType), System.Globalization.CultureInfo.InvariantCulture);
                value = (T)Enum.ToObject(targetType, underlying);
                return true;
            }

            var converted = Convert.ChangeType(Value, Nullable.GetUnderlyingType(targetType) ?? targetType, System.Globalization.CultureInfo.InvariantCulture);
            value = (T)converted!;
            return true;
        }
        catch
        {
            value = default!;
            return false;
        }
    }
}
