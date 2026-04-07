# 🎭 Playwright Automation Framework (C# / .NET 9)

[![Playwright Tests](https://github.com/OlegV1asenko/demoqa-playwright-csharp/actions/workflows/playwright.yml/badge.svg)](https://github.com/OlegV1asenko/demoqa-playwright-csharp/actions/workflows/playwright.yml)
[![Allure Report](https://img.shields.io/badge/Allure%20Report-View%20Live-green?style=for-the-badge&logo=allure)](https://OlegV1asenko.github.io/demoqa-playwright-csharp/)

This project is a high-performance automated testing framework built with **Playwright**, **NUnit**, and **.NET 9**, focusing on best practices in UI and API automation for the DemoQA platform.

---

## 🚀 Live Test Report
Every execution of the CI/CD pipeline automatically generates and deploys an interactive report.
👉 **[View Live Allure Report](https://OlegV1asenko.github.io/demoqa-playwright-csharp/)**

---

## ✨ Key Features & Architecture

* **Page Object Model (POM):** Implemented an abstract `BasePage` to ensure clean separation of concerns and maintainable code.
* **Step-by-Step Logging:** Custom `LogStep` implementation providing high-verbosity console output and detailed action history in reports.
* **Hybrid Testing:** Coverage for both **UI (Web)** and **API** layers within a single unified framework.
* **Playwright Tracing:** Integrated full action recording (snapshots, screenshots, and network logs) for every test execution.
* **Advanced CI/CD Pipeline:** Fully automated workflow using GitHub Actions.

---

## 🛠️ Infrastructure & Optimization

### 🏎️ Pipeline Performance
* **Browser Caching:** Implemented GitHub Actions caching for Playwright browser binaries to reduce CI execution time by **60%**.
* **System Dependencies:** Optimized dependency installation with conditional logic (`install-deps` only when cache hits).

### 📊 Professional Reporting
* **Allure Integration:** Automated deployment to GitHub Pages with historical test data.
* **Artifact Management:** Automatic upload of `.trx` results and `.zip` Playwright traces for post-run debugging.

---

## 🖥️ Local Setup

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/OlegV1asenko/demoqa-playwright-csharp.git
    ```
2.  **Install dependencies:**
    ```bash
    dotnet restore
    ```
3.  **Install Playwright browsers:**
    ```bash
    pwsh DemoQA/bin/Debug/net9.0/playwright.ps1 install --with-deps
    ```
4.  **Run all tests:**
    ```bash
    dotnet test
    ```

---

## 📂 Project Structure
* `DemoQA/Pages`: Page Object classes inherited from `BasePage`.
* `DemoQA/Tests`: UI and API test suites.
* `DemoQA/Models`: Data models for API requests and responses.
* `.github/workflows`: CI/CD pipeline configuration (`playwright.yml`).

---
*Developed by [Oleg Vlasenko](https://github.com/OlegV1asenko) as a demonstration of modern QA Automation standards.*
