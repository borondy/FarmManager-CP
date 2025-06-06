# FarmManager WebAPI

This project is part of the FarmManager solution and serves as the backend API for managing farm-related data and operations.

## Overview

The FarmManager.WebAPI project provides RESTful endpoints to interact with farm entities and services. It is built using ASP.NET Core and follows best practices for API development.

## Features

- **Weather Forecast API**: Provides weather forecast data.
- **Farm Management**: Endpoints for creating, retrieving, updating, and deleting farm entities.

## Getting Started

To run the project locally, follow these steps:

1. Clone the repository.
2. Navigate to the `FarmManager.WebAPI` directory.
3. Run the application using the command:
   ```
   dotnet run
   ```
4. Access the API at `http://localhost:5000`.

## API Endpoints

- `GET /weatherforecast`: Retrieves weather forecast data.

## Dependencies

This project relies on the following NuGet packages:

- Microsoft.AspNetCore.Mvc
- Microsoft.Extensions.DependencyInjection

## Contributing

Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.

## License

This project is licensed under the MIT License. See the LICENSE file for details.