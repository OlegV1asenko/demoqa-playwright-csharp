using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Playwright;
using DemoQA.Api.Models;

namespace DemoQA.Api.Clients;

public class AccountClient
{
    private readonly IAPIRequestContext _requestContext;

    public AccountClient(IAPIRequestContext requestContext)
    {
        _requestContext = requestContext;
    }

    public async Task<IAPIResponse> CreateUserAsync(UserRequest request)
    {
        return await _requestContext.PostAsync("/Account/v1/User", new APIRequestContextOptions
        {
            DataObject = request
        });
    }

    public async Task<IAPIResponse> LoginAsync(LoginRequest request)
    {
        return await _requestContext.PostAsync("/Account/v1/Login", new APIRequestContextOptions
        {
            DataObject = request
        });
    }

    public async Task<IAPIResponse> GetUserAsync(string uuid, string token)
    {
        return await _requestContext.GetAsync($"/Account/v1/User/{uuid}", new APIRequestContextOptions
        {
            Headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {token}" }
            }
        });
    }

    public async Task<IAPIResponse> DeleteUserAsync(string uuid, string token)
    {
        return await _requestContext.DeleteAsync($"/Account/v1/User/{uuid}", new APIRequestContextOptions
        {
            Headers = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {token}" }
            }
        });
    }

    public async Task<IAPIResponse> GenerateTokenAsync(string username, string password)
    {
        return await _requestContext.PostAsync("/Account/v1/GenerateToken", new APIRequestContextOptions()
        {
            DataObject = new LoginRequest(username, password)
        });
    }
}
