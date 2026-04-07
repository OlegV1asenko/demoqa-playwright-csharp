using System.Text.Json.Serialization;

namespace DemoQA.Api.Models;

public record UserRequest(
    [property: JsonPropertyName("userName")] string UserName,
    [property: JsonPropertyName("password")] string Password
);
