﻿namespace OrderFlow.Domain.Abstractions;

public sealed record Error(
    string Code,
    string? Description = null
)
{
    public static readonly Error None = new(string.Empty);

    public static readonly Error NullValue = new("Error.NullValue", "Null value was provided");

    public static implicit operator Result(Error error) => Result.Failure(error);

    public Result ToResult() => Result.Failure(this);
}