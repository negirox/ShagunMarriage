# ShagunMarriage

ShagunMarriage is a web application built using Razor Pages in .NET 8.0. The application provides user registration and login functionality with password encryption and session management. It uses the Repository pattern for data access and AutoMapper for mapping models to view models.

## Features

- User registration with basic details
- Password encryption using SHA-256
- User login with session management
- Repository pattern for data access
- AutoMapper for model-view model mapping
- Bootstrap for UI styling

## Technologies Used

- .NET 8.0
- Razor Pages
- Entity Framework Core
- AutoMapper
- Bootstrap
- Microsoft SQL Server

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- SQL Server

### Installation

1. Clone the repository:

   git clone https://github.com/yourusername/ShagunMarriage.git

2. Install the required packages:
   
3. Update the database:
   
### Configuration

1. Update the connection string in `appsettings.json`:
   
### Running the Application

1. Build and run the application:
   
2. Open your browser and navigate to `https://localhost:5001`.

## Project Structure

- **Controllers**: Contains the `AccountController` for handling user registration and login.
- **Models**: Contains the `UserModel` and `UserViewModel` classes.
- **Repository**: Contains the `UserRepository` and `IUserRepository` for data access.
- **Services**: Contains the `UserService` and `MappingProfile` for business logic and model mapping.
- **Pages**: Contains the Razor Pages for user registration and login.

## Usage

### Register a New User

1. Navigate to `/Account/Register`.
2. Fill in the registration form with your username, email, and password.
3. Click the "Register" button.

### Login

1. Navigate to `/Account/Login`.
2. Enter your username and password.
3. Click the "Login" button.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Acknowledgements

- [AutoMapper](https://automapper.org/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [Bootstrap](https://getbootstrap.com/)

