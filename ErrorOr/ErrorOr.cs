namespace ErrorOr;

public readonly record struct ErrorOr<TValue>
{
    private readonly TValue? _value = default;
    private readonly List<Error>? _errors = [];

    private ErrorOr(Error error)
    {
        _errors = [error];
    }

    private ErrorOr(TValue value)
    {
        _value = value;
    }

    public bool IsError
        => _errors.Count > 0;

    public TValue Value
    {
        get
        {
            return _value;
        }
    }

    public static implicit operator ErrorOr<TValue>(TValue value)
    {
        return new ErrorOr<TValue>(value);
    }

    public static implicit operator ErrorOr<TValue>(Error error)
    {
        return new ErrorOr<TValue>(error);
    }
}
