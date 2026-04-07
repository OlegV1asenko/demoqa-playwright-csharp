using System;
using Microsoft.Playwright;

namespace DemoQA.Pages;

public abstract class BasePage(IPage page)
{
    protected readonly IPage Page = page;

    protected void LogStep(string stepDescription)
    {
        Console.WriteLine($"[STEP] {DateTime.Now:HH:mm:ss} - {stepDescription}");
    }
}
