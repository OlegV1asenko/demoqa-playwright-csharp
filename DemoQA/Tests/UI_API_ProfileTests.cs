using System;
using System.Text.Json;
using System.Threading.Tasks;
using DemoQA.Api.Models;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;

namespace DemoQA.Tests;

[TestFixture]
[Category("Hybrid")]
public class UI_API_ProfileTests : TestBase
{
    [Test]
    public async Task ProfilePage_Should_Show_Username_When_Injected_Via_LocalStorage()
    {
        // 1. Arrange (Generate User Data)
        var uniqueString = Guid.NewGuid().ToString("N").Substring(0, 8);
        var username = $"TestUser_{uniqueString}";
        var password = "Password123*!";

        var userRequest = new UserRequest(username, password);

        // 2. Create User via API
        var createResponse = await AccountClient.CreateUserAsync(userRequest);
        createResponse.Status.Should().Be(201, "API: User creation failed");

        var createBodyText = await createResponse.TextAsync();
        var createData = JsonSerializer.Deserialize<UserResponse>(createBodyText);
        var userId = createData?.UserID;
        userId.Should().NotBeNullOrEmpty();

        // 3. Generate Token via API
        var tokenResponse = await AccountClient.GenerateTokenAsync(username, password);
        tokenResponse.Status.Should().Be(200, "API: Token generation failed");

        var tokenResponseBodyText = await tokenResponse.TextAsync();
        var tokenData = JsonSerializer.Deserialize<TokenResponse>(tokenResponseBodyText);
        tokenData.Should().NotBeNull();

        var token = tokenData!.Token!;
        var expires = tokenData.Expires!;

        token.Should().NotBeNullOrEmpty();
        expires.Should().NotBeNullOrEmpty();

        try
        {
            // 4. UI Injection - Seed auth data directly into Context and LocalStorage
            await Page.Context.AddCookiesAsync(new[]
            {
                new Cookie { Name = "userID", Value = userId!, Domain = "demoqa.com", Path = "/" },
                new Microsoft.Playwright.Cookie { Name = "userName", Value = username, Domain = "demoqa.com", Path = "/" },
                new Microsoft.Playwright.Cookie { Name = "token", Value = token, Domain = "demoqa.com", Path = "/" },
                new Microsoft.Playwright.Cookie { Name = "expires", Value = expires, Domain = "demoqa.com", Path = "/" }
            });

            await Page.Context.AddInitScriptAsync($@"
                window.localStorage.setItem('token', '{token}');
                window.localStorage.setItem('userID', '{userId}');
                window.localStorage.setItem('userName', '{username}');
                window.localStorage.setItem('expires', '{expires}');
            ");

            // 5. Act (Navigate directly to the profile page bypassing the login screen)
            await Page.GotoAsync($"{BaseUrl}/profile");

            // 6. Assert (Verify the user is logged in)
            var userNameLabel = Page.Locator("#userName-value");

            await Expect(userNameLabel).ToBeVisibleAsync();
            await Expect(userNameLabel).ToHaveTextAsync(username);
        }
        finally
        {
            // 7. Cleanup (Remove User from Database via API)
            if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(token))
            {
                var deleteResponse = await AccountClient.DeleteUserAsync(userId, token);
                deleteResponse.Status.Should().Be(204, "API Cleanup: Delete User failed");
            }
        }
    }
}
