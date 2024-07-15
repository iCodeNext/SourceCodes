using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorOr;

public readonly record struct Error
{
    private Error(string code, string description, ErrorType type)
    {
        Code = code;
        Description = description;
        Type = type;
    }

    public string Code { get; }
    public string Description { get; }
    public ErrorType Type { get; }
    public int CodeNumeric { get; }

    public static Error Unexpected(string code = "General.Unexpected", string description = "An unexpected error has occurred.")
            => new(code, description, ErrorType.Unexpected);
}

public enum ErrorType
{
    Failure,
    Unexpected,
    Validation,
    Conflict,
    NotFound,
    Unauthorized,
    Forbidden

}