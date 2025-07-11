﻿using System;

namespace petFamily.Domain.Shared;

public class Result
{
    public Result(bool isSuccess, string? error)
    {
        if (isSuccess && error is not null)
        {
            throw new InvalidCastException();
        }

        if (isSuccess == false && error == null)
        {
            throw new InvalidCastException();
        }
        IsSuccess = isSuccess;
        Error = error;
    }
    public string? Error  { get; set; }
    public bool IsSuccess { get;}
    public bool IsFailure => !IsSuccess;
    
    public static Result Success() => new (true, null);
    public static Result Failure(string? error) => new (false, error);
    public static implicit operator Result(string error) => new (default!, error);

}
public class Result<TValue> : Result
{
    public Result(TValue value, bool isSuccess, string? error)
        : base(isSuccess, error)
    {
        _value = value;
    }
    public readonly TValue _value;
    public TValue Value => IsSuccess 
    ? _value
        : throw new InvalidOperationException("The value of a failure result can not be accessed");
    public static Result<TValue> Success(TValue value) => new (value, true, null);
    public static Result<TValue> Failure(string? error) => new (default!, false, error);
    
    public static implicit operator Result<TValue>(TValue value) => new (value, true, null);
    public static implicit operator Result<TValue>(string error) => new (default!, false, error);
}