# 🎯 Purpose

This test project is built to automate functional testing of the Android application with the following configuration:

* Package Name: com.example.babylon_nexus

* Main Activity: com.example.babylon_nexus.MainActivity

* Device ID: 192.168.56.102:5555

* Platform Name: Android

* Automation Engine: UiAutomator2

* Device Name: Android Device

* Appium Server URI: http://127.0.0.1:4723/


This setup is intended for execution on a Genymotion virtual device connected via ADB.
# ✅ Prerequisites

To run this project, make sure the following tools are installed:

* .NET SDK (version 6.0 or higher)
* Visual Studio 2022 or later

* Android SDK (used by ADB and Appium)

* Genymotion (Android emulator)

* Node.js (required to install Appium)

* Appium server

# 🚀 Getting Started

## 1. Clone the Repository

`git clone https://github.com/DungPham6Sotatek/apptestbycsharp.git`

`cd apptestbycsharp`

## 2. Restore NuGet Packages

`dotnet restore`

## 3. Build the Project

`dotnet build`

## 4. Install Appium (via Node.js)

`npm install -g appium`

`npm install -g appium-doctor`

## 5. Verify Setup

`appium-doctor`

  Ensure all dependencies are correctly installed.

## 6. Start Appium Server

`appium`

Appium should start on http://127.0.0.1:4723 by default.

## 7. Run Tests

### a. Using Visual Studio Test Explorer:

Open the solution file (.sln) in Visual Studio

Go to Test > Test Explorer

Click Run All Tests

### b. Using .NET CLI:

`dotnet test`

## 🦚 Test Structure

Test cases are located in the Automation/TestSuite/ directory. They use the NUnit framework and follow the Page Object Model design to promote readability and reusability.

## 📊 Allure Reporting

This project integrates Allure to generate rich, visual test reports.

### Install Allure CLI

* On Windows (via Scoop):

    `scoop install allure`

* On macOS (via Homebrew):

     `brew install allure`

* Generate Report

   Run your tests:

   `dotnet test`

   Serve the Allure report:

   `allure serve allure-results`

Make sure allureConfig.json is copied to the output directory and points to the correct result folder.

## ⚙️ Configuration Notes

* All app-specific constants (like package name, activity, device ID, platform name, etc.) are stored in:

   Automation/constanst/CT_App_Constanst.cs

* Ensure that:

  Your Genymotion virtual device is running

  It appears in the output of adb devices

  Appium is connected to the correct DEVICE_ID (e.g., 192.168.56.102:5555)

## 📌 Additional Notes

* Start Genymotion emulator before running tests

* Ensure Appium server is running on http://127.0.0.1:4723

* Use TestContext.WriteLine() for logs to appear in Visual Studio Test Explorer

* Update locators in constanst/ if your app UI changes