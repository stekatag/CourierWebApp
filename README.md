# 📦 Courier Web App

## ℹ️ About the Project

This is a web application for managing deliveries using ASP.NET MVC 8.0 with Entity Framework.

## 🚀 Features

- Authentication with authorization using Identity Framework
- CRUD operations on Deliveries, Customers, Items and Units
- Search deliveries by item name or item description

## 📋 Prerequisites

- Visual Studio 2022
- .NET Core 8.0+
- SQL Server Express or SQL Server Developer Edition

## 🏁 Getting Started

To get a local copy up and running follow these simple steps.

1. Clone this repository to your local machine
2. Open the project solution in Visual Studio
3. Connection string
   - Before running the project, you need to change the connection string in the `appsettings.json` file to match your SQL Server instance.
   - The default connection string is set to use SQL Server Express with Windows Authentication.
   - If you are using a different SQL Server instance or SQL Server Express with SQL Server Authentication, you need to change the connection string accordingly.
   - For example, if you are using SQL Server Express with SQL Server Authentication, you need to change the connection string to:
     ```json
      "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=aspnet-CourierWebApp;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
     ```
4. Apply migrations to the database using:

   - `Update-Database` in the Package Manager Console
   - or `dotnet ef database update` by opening a terminal in the project's folder

5. Run the project using IIS Express

## 📝 Usage

### Demo user

You can use the following demo user to test the application:

- Username: `admin@gmail.com`
- Password: `Admin123#`

## 📄 License

This project is licensed under the MIT License. See [license](https://github.com/stekatag/CourierWebApp/blob/master/LICENSE.txt) for more information.
