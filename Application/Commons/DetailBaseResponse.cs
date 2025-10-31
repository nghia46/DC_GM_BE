﻿using Microsoft.AspNetCore.Http;
namespace Application.Commons;

public class DetailBaseResponse<T>
{
    public required Guid Id { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public bool Success { get; set; }
    public T? Data { get; set; }
    public IEnumerable<ErrorDetail>? Errors { get; set; }
    public DateTime Timestamp { get; set; }

    internal static DetailBaseResponse<T> SuccessReturn(string Message, T classInstance)
    {
        return new DetailBaseResponse<T>
        {
            Id = Guid.NewGuid(),
            StatusCode = StatusCodes.Status200OK,
            Message = Message,
            Success = true,
            Data = classInstance,
            Timestamp = DateTime.UtcNow
        };
    }
    internal static DetailBaseResponse<T> InternalServerError(string message = "Có lỗi xảy ra")
    {
        return new DetailBaseResponse<T>
        {
            Id = Guid.NewGuid(),
            StatusCode = StatusCodes.Status500InternalServerError,
            Message = message,
            Success = false,
            Timestamp = DateTime.UtcNow
        };
    }
    internal static DetailBaseResponse<string> Unauthorized()
    {
        return new DetailBaseResponse<string>
        {
            Id = Guid.NewGuid(),
            StatusCode = StatusCodes.Status401Unauthorized,
            Message = "Không có quyền truy cập, chưa đăng nhập hoặc phiên làm việc hết hạn",
            Success = false,
            Timestamp = DateTime.UtcNow
        };
    }
    internal static DetailBaseResponse<T> NotFound(string message = "Không tìm thấy dữ liệu")
    {
        return new DetailBaseResponse<T>
        {
            Id = Guid.NewGuid(),
            StatusCode = StatusCodes.Status404NotFound,
            Message = message,
            Success = false,
            Timestamp = DateTime.UtcNow
        };
    }

}
