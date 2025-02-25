﻿namespace DotNet8WebApi.EFCoreRelationshipExample.Models;

public class Result<T>
{
    public T Data { get; set; }
    public string Message { get; set; }
    public EnumStatusCode StatusCode { get; set; }
    public bool IsSuccess { get; set; }
    public bool IsError => !IsSuccess;

    public static Result<T> SuccessResult(
        string message = "Success.",
        EnumStatusCode statusCode = EnumStatusCode.Success
    )
    {
        return new Result<T>
        {
            Message = message,
            StatusCode = statusCode,
            IsSuccess = true
        };
    }

    public static Result<T> SuccessResult(
        T data,
        string message = "Success.",
        EnumStatusCode statusCode = EnumStatusCode.Success
    )
    {
        return new Result<T>
        {
            Data = data,
            Message = message,
            StatusCode = statusCode,
            IsSuccess = true
        };
    }

    public static Result<T> SaveSuccessResult(string message = "Saving Successful.") =>
        Result<T>.SuccessResult(message);

    public static Result<T> UpdateSuccessResult(string message = "Updating Successful.") =>
        Result<T>.SuccessResult(message);

    public static Result<T> DeleteSuccessResult(string message = "Deleting Successful.") =>
        Result<T>.SuccessResult(message);

    public static Result<T> FailureResult(
        string message = "Fail.",
        EnumStatusCode statusCode = EnumStatusCode.BadRequest
    )
    {
        return new Result<T>
        {
            Message = message,
            StatusCode = statusCode,
            IsSuccess = false
        };
    }

    public static Result<T> FailureResult(Exception ex)
    {
        return new Result<T>
        {
            Message = ex.ToString(),
            StatusCode = EnumStatusCode.InternalServerError,
            IsSuccess = false
        };
    }

    public static Result<T> NotFoundResult(string message = "No Data Found.") =>
        Result<T>.FailureResult(message, EnumStatusCode.NotFound);

    public static Result<T> DuplicateResult(string message = "Duplicate Data.") =>
        Result<T>.FailureResult(message, EnumStatusCode.Conflict);
}
