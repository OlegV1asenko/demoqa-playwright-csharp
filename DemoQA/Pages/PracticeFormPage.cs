using System.Threading.Tasks;
using Microsoft.Playwright;

namespace DemoQA.Pages;

public class PracticeFormPage(IPage page) : BasePage(page)
{
    private ILocator FirstNameInput => Page.GetByPlaceholder("First Name");
    private ILocator LastNameInput => Page.GetByPlaceholder("Last Name");
    private ILocator EmailInput => Page.GetByPlaceholder("name@example.com");
    private ILocator MobileInput => Page.GetByPlaceholder("Mobile Number");
    private ILocator SubmitButton => Page.Locator("#submit");

    public async Task NavigateAsync(string baseUrl)
    {
        LogStep($"Navigating to practice form page at {baseUrl}/automation-practice-form");
        await Page.GotoAsync($"{baseUrl}/automation-practice-form");
    }

    public async Task FillAndSubmitFormAsync(string firstName, string lastName, string email, string gender, string mobile)
    {
        LogStep("Entering first name");
        await FirstNameInput.FillAsync(firstName);

        LogStep("Entering last name");
        await LastNameInput.FillAsync(lastName);

        LogStep("Entering email address");
        await EmailInput.FillAsync(email);

        // DemoQA custom radios require clicking the corresponding label
        LogStep($"Selecting gender: {gender}");
        await Page.GetByText(gender, new() { Exact = true }).ClickAsync();

        LogStep("Entering mobile number");
        await MobileInput.FillAsync(mobile);

        LogStep("Clicking the submit button");
        await SubmitButton.ClickAsync();
    }
}
