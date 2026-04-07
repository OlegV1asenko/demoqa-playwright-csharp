using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DemoQA.Api.Models;

public record UserResponse(
    [property: JsonPropertyName("userID")] string UserID,
    [property: JsonPropertyName("username")] string Username,
    [property: JsonPropertyName("books")] List<BookResponse>? Books
);

public record BookResponse(
    [property: JsonPropertyName("isbn")] string Isbn,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("subTitle")] string SubTitle,
    [property: JsonPropertyName("author")] string Author,
    [property: JsonPropertyName("publish_date")] string PublishDate,
    [property: JsonPropertyName("publisher")] string Publisher,
    [property: JsonPropertyName("pages")] int Pages,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("website")] string Website
);
