using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using DemoQA.Pages;

namespace DemoQA.Tests;

[TestFixture]
[Category("UI")]
public class UI_PracticeFormTests : TestBase
{
    [Test]
    public async Task ShouldSubmitPracticeFormSuccessfully()
    {
        var formPage = new PracticeFormPage(Page);

        await formPage.NavigateAsync(BaseUrl);
        await formPage.FillAndSubmitFormAsync(
            firstName: "John",
            lastName: "Doe",
            email: "john.doe@example.com",
            gender: "Male",
            mobile: "1234567890"
        );

        var modal = Page.Locator(".modal-content");
        await Expect(modal).ToBeVisibleAsync();
    }
}
