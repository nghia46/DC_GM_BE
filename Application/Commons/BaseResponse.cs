using Microsoft.AspNetCore.Http;

namespace Application.Commons;

public class BaseResponse<T>
{
    public required Guid Id { get; init; }
    public int StatusCode { get; init; }
    public string? Message { get; init; }
    public bool Success { get; init; }
    public T? Data { get; init; }
    public List<string>? Errors { get; init; }
    public DateTimeOffset Timestamp { get; init; }

    private static DateTimeOffset Now => DateTimeOffset.UtcNow.AddHours(7);
    private static Guid NewId() => Guid.NewGuid();

    private static BaseResponse<T> Create(
        int statusCode,
        bool success,
        string message,
        T? data = default,
        List<string>? errors = null
    ) => new()
    {
        Id = NewId(),
        StatusCode = statusCode,
        Message = message,
        Success = success,
        Data = data,
        Errors = errors,
        Timestamp = Now
    };

    public static BaseResponse<T> SuccessReturn(T data, string message = "Thành công") =>
        Create(StatusCodes.Status200OK, true, message, data);

    public static BaseResponse<T> NotFound(string message = "Không tìm thấy dữ liệu") =>
        Create(StatusCodes.Status404NotFound, false, message);

    public static BaseResponse<T> InternalServerError(string message = "Lỗi hệ thống") =>
        Create(StatusCodes.Status500InternalServerError, false, message);

    public static BaseResponse<T> Unauthorized(string message = "Không có quyền truy cập, chưa đăng nhập hoặc phiên làm việc hết hạn") =>
        Create(StatusCodes.Status401Unauthorized, false, message);

    public static BaseResponse<T> BadRequest(string message = "Yêu cầu không hợp lệ") =>
        Create(StatusCodes.Status400BadRequest, false, message);

    public static BaseResponse<T> CustomResponse(
        int statusCode,
        string message,
        bool success,
        List<string>? errors = null
    ) => Create(statusCode, success, message, default, errors);
}
