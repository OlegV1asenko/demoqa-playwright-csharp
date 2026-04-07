# Playwright Automation Project (C# / .NET 9)

[![Playwright Tests](https://github.com/OlegV1asenko/demoqa-playwright-csharp/actions/workflows/playwright.yml/badge.svg)](https://github.com/OlegV1asenko/demoqa-playwright-csharp/actions/workflows/playwright.yml)
[![Allure Report](https://img.shields.io/badge/Allure%20Report-View%20Live-green?style=flat-square&logo=allure)](https://OlegV1asenko.github.io/demoqa-playwright-csharp/)

A demo automation framework for **DemoQA** using **Playwright** and **NUnit**. This project demonstrates basic UI and API testing patterns with a configured CI/CD pipeline.

---

## 📊 Test Report
The latest test results are automatically deployed to GitHub Pages.
👉 **[Open Allure Report](https://OlegV1asenko.github.io/demoqa-playwright-csharp/)**

---

## Implementation Details

* **Pattern:** Page Object Model (POM) with a common `BasePage`.
* **Logging:** Step-by-step console logging for easier debugging in CI.
* **Coverage:** Basic UI scenarios and API endpoint validation.
* **Tracing:** Playwright Trace Viewer enabled for all test runs.
* **CI/CD:** Automated workflow via GitHub Actions with browser caching for faster execution.

---

## Local Setup

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/OlegV1asenko/demoqa-playwright-csharp.git](https://github.com/OlegV1asenko/demoqa-playwright-csharp.git)
    ```
2.  **Restore and Build:**
    ```bash
    dotnet build
    ```
3.  **Install Playwright Browsers:**
    ```bash
    pwsh DemoQA/bin/Debug/net9.0/playwright.ps1 install --with-deps
    ```
4.  **Run Tests:**
    ```bash
    dotnet test
    ```

---

## Project Structure
* `DemoQA/Pages` - Page Objects and logic.
* `DemoQA/Tests` - UI & API test suites.
* `.github/workflows` - GitHub Actions configuration.

---
*Created by [Oleg Vlasenko](https://github.com/OlegV1asenko)*
