using System.Text.Json.Serialization;

namespace DemoQA.Api.Models;

public record TokenResponse(
    [property: JsonPropertyName("token")] string? Token,
    [property: JsonPropertyName("expires")] string? Expires,
    [property: JsonPropertyName("status")] string? Status,
    [property: JsonPropertyName("result")] string? Result
);
