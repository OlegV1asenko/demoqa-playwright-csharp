# 🎭 DemoQA Test Automation Framework

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)
![Playwright](https://img.shields.io/badge/Playwright-v1.40+-2EAD33?logo=playwright&logoColor=white)
![NUnit](https://img.shields.io/badge/NUnit-3.13+-0073C0?logo=nunit&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white)

An Enterprise-level E2E, API, and Hybrid Test Automation Framework for [DemoQA](https://demoqa.com/) using C# and Playwright.

## 🚀 Key Features & Architecture
- **Hybrid Testing (UI + API):** Bypasses slow UI login screens by injecting API-generated JWT tokens directly into the browser's `LocalStorage` and `Cookies` via Playwright's `AddInitScriptAsync`.
- **API Clients:** Custom API clients using `IAPIRequestContext` for fast data preparation and teardown (CRUD operations).
- **Environment Management:** Uses `IConfiguration` and `appsettings.json` to avoid hardcoded URLs and manage test environments seamlessly.
- **Base Classes:** Centralized setup and teardown logic to keep test classes clean and maintainable.

## ⚙️ Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
- Node.js (for Playwright browsers)
