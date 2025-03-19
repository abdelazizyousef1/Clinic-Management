# Clinic Management API

An API for managing clinic appointments using ASP.NET Core and Entity Framework Core, focusing on performance and security.

## Features
- **Appointment Management:**
  - Create new appointments with availability checks for doctors and patients.
  - Retrieve appointments with filters (by `patientId` and `doctorId`).
  - Update appointments with conflict validation.
  - Delete appointments.
- **Security:**
  - Supports Authentication using JWT to secure endpoints.
- **Performance & Maintenance:**
  - Event logging using Logging to track operations and errors.
  - Uses Repository Pattern to separate database logic.
  - Uses DTOs for efficient data transfer.
- **Database Management:**
  - Uses Entity Framework Core with Migrations for database creation and updates.

## Project Structure
- `Controllers/`: Contains the API endpoints (e.g., `AppointmentController`).
- `DTOs/`: Contains Data Transfer Objects (e.g., `AppointmentDto`).
- `Interfaces/`: Contains service interfaces (e.g., `IAppointmentService`).
- `Models/`: Contains entities (e.g., `Appointment`, `Doctor`, `Patient`).
- `Repository/`: Contains repositories (e.g., `AppointmentRepository`).
- `Services/`: Contains business logic (e.g., `AppointmentService`).
- `Data/`: Contains database configuration (e.g., `AppDbContext`).
- `Helpers/`, `Middlewares/`, `Utility/`: Helper tools for improved functionality.

## Technologies Used
- ASP.NET Core
- Entity Framework Core
- SQL Server
- JWT Authentication
- Logging

## How to Run
1. Clone the repository:
