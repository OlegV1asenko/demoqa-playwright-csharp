using System;
using System.Text.Json;
using System.Threading.Tasks;
using DemoQA.Api.Models;
using FluentAssertions;
using NUnit.Framework;

namespace DemoQA.Tests;

[TestFixture]
[Category("API")]
public class API_AccountTests : TestBase
{
    [Test]
    public async Task Should_Create_Login_Get_And_Delete_User_Successfully()
    {
        // 1. Arrange
        var uniqueString = Guid.NewGuid().ToString("N").Substring(0, 8);
        var username = $"TestUser_{uniqueString}";
        var password = "Qwer!234";

        var userRequest = new UserRequest(username, password);
        var loginRequest = new LoginRequest(username, password);

        // 2. Create User
        var createResponse = await AccountClient.CreateUserAsync(userRequest);
        createResponse.Status.Should().Be(201, "User creation failed");

        var createBodyText = await createResponse.TextAsync();
        var createData = JsonSerializer.Deserialize<UserResponse>(createBodyText);
        var userId = createData?.UserID;
        userId.Should().NotBeNullOrEmpty("UserID should not be null.");

        // 3. Generate Token
        var tokenResponse = await AccountClient.GenerateTokenAsync(username, password);
        tokenResponse.Status.Should().Be(200, "Token generation failed");

        var tokenResponseBodyText = await tokenResponse.TextAsync();
        var tokenData = JsonSerializer.Deserialize<TokenResponse>(tokenResponseBodyText);

        tokenData.Should().NotBeNull();
        tokenData!.Token.Should().NotBeNullOrEmpty("Token should not be empty");
        var validToken = tokenData.Token!;

        // 4. Login User
        var loginResponse = await AccountClient.LoginAsync(loginRequest);
        loginResponse.Status.Should().Be(200, "Login failed");

        // 5. Get User Details
        var getUserResponse = await AccountClient.GetUserAsync(userId!, validToken);
        getUserResponse.Status.Should().Be(200, "Get User failed");

        var getUserJson = await getUserResponse.TextAsync();
        var userData = JsonSerializer.Deserialize<UserResponse>(getUserJson);

        userData.Should().NotBeNull();
        userData!.Username.Should().Be(username, "Username should match");

        // 6. Delete User
        var deleteResponse = await AccountClient.DeleteUserAsync(userId!, validToken);
        deleteResponse.Status.Should().Be(204, "Delete User failed");

        // 7. Verify Deletion
        var verifyDeleteResponse = await AccountClient.GetUserAsync(userId!, validToken);
        verifyDeleteResponse.Status.Should().Be(401, "User should be unauthorized or not found after deletion");
    }
}
