using Microsoft.Playwright;

namespace DemoQA.Pages;

public abstract class BasePage(IPage page)
{
    protected readonly IPage Page = page;
}
