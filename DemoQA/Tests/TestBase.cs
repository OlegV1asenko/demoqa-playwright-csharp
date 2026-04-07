using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using DemoQA.Api.Clients;

namespace DemoQA.Tests;

public abstract class TestBase : PageTest
{
    protected string BaseUrl = null!;
    protected IAPIRequestContext ApiContext = null!;
    protected AccountClient AccountClient = null!;

    [OneTimeSetUp]
    public void GlobalSetup()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        BaseUrl = configuration["EnvironmentConfig:BaseUrl"] 
                  ?? throw new Exception("BaseUrl not found in appsettings.json");
    }

    [SetUp]
    public async Task BaseSetUp()
    {
        ApiContext = await Playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
        {
            BaseURL = BaseUrl
        });
        AccountClient = new AccountClient(ApiContext);
    }

    [TearDown]
    public async Task BaseTearDown()
    {
        if (ApiContext != null)
        {
            await ApiContext.DisposeAsync();
        }
    }
}
