using System.Text.Json.Serialization;

namespace DemoQA.Api.Models;

public record LoginResponse(
    [property: JsonPropertyName("userId")] string UserId,
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("password")] string Password,
    [property: JsonPropertyName("token")] string Token,
    [property: JsonPropertyName("expires")] string Expires,
    [property: JsonPropertyName("created_date")] string CreatedDate,
    [property: JsonPropertyName("isActive")] bool IsActive
);
