# Playwright SpecFlow Boilerplate

![Playwright](https://img.shields.io/nuget/v/Microsoft.Playwright?style=for-the-badge&logo=Playwright&label=Playwright&color=%2345ba4b&link=https%3A%2F%2Fwww.nuget.org%2Fpackages%2FMicrosoft.Playwright)
![SpecFlow](https://img.shields.io/nuget/v/SpecFlow?style=for-the-badge&logo=specflow&label=specflow&color=%23574897&link=https%3A%2F%2Fwww.nuget.org%2Fpackages%2FSpecFlow)

Boilerplate project to run Playwright tests with SpecFlow and .NET 8 to web applications.

## Prerequisites

Make sure you have installed and be configured the environment variables all the following prerequisites on your
development machine:

| OS      | .NET SDK                                     | Powershell                                 |
|---------|----------------------------------------------|--------------------------------------------|
| Windows | `winget install --id Microsoft.DotNet.SDK.8` | `winget install --id Microsoft.PowerShell` |
| macOS   | `brew install --cask dotnet-sdk`             | `brew install --cask powershell`           |

## Executing the Tests

- Clone the repository.

```git
git clone git@github.com:burakkaygusuz/Playright.SpecFlow.Boilerplate.git
```

- Change the directory.

```shell
cd Playwright.SpecFlow.Boilerplate
```

Build the project.

```shell
dotnet build
```

- Install the required browsers.

```shell
pwsh bin/Debug/net8.0/playwright.ps1 install
```

- Run the test.

```shell
dotnet test
```
