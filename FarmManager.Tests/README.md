# FarmManager.Tests/README.md

# FarmManager Tests

This project contains unit tests for the FarmManager application, specifically targeting the WebAPI and Core functionalities.

## Structure

- **FarmManager.WebAPI.Tests.csproj**: Project file for the WebAPI tests, including dependencies and settings.
- **FarmServiceTests.cs**: Contains unit tests for the `FarmService` class, ensuring that methods like `CreateFarm()` and `GetFarmById()` function as expected.

## Running Tests

To run the tests, use the following command in the terminal:

```
dotnet test
```

Ensure that you have the .NET SDK installed and that you are in the correct directory.

## Contribution

Feel free to add more tests as needed to cover additional functionalities and edge cases.