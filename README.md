# EliteCare – Full Clinic Management System

**EliteCare** is a complete clinic management system designed to streamline various operations within a healthcare setting, including doctor & staff management, appointments, payments, and patient medical records. Built with the latest technologies, this project aims to provide an organized, scalable, and secure solution for modern clinics.

## Table of Contents
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Project Structure](#Project-Structure)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [Prerequisites](#Prerequisites)
- [License](#license)
- [Contact](#Contact)

## Features

- **Doctor, Nurse & Receptionist Management**: Manage staff data and assign appropriate permissions.
- **Appointment Scheduling System**: Book, modify, and cancel appointments.
- **Online Payment Integration**: Integration with **Paymob** for secure online payments.
- **Medical Records & Patient History**: Secure management of patient data and medical history.
- **Real-time Notifications**: SMS and email notifications for appointment reminders and updates.
- **Audit & Logging System**: Track all activities within the system for security and auditing purposes.
- **Multi-Tenant Support**: Manage multiple clinics independently with separate data.

## Tech Stack

- **Backend**: .NET 8, MediatR, CQRS
- **Architecture**: Clean Architecture
- **Authentication**: Identity with Role-based Access Control
- **Security**: Implemented OWASP security best practices to protect patient data
- **Caching**: Redis for caching frequently accessed data to optimize fetch operations and store operations like add, update, and delete
- **Database**: SQL Server or your preferred database
- **Payment Integration**: Paymob for online payments


## 📂 Project Structure
-EliteCare/
- ├── EliteCare.API/ # API Layer
- ├── EliteCare.Core/ # Core Domain Layer
- ├── EliteCare.Infrastructure/ # Infrastructure Layer
- └──  EliteCare.Application/ # Application Layer
 

## 🚀 Getting Started

### Prerequisites
- **.NET 8 SDK**
- **SQL Server**
- **Redis**
  

## Installation

To get started with the project locally, follow these steps:

1. Clone the repository:
   ```bash
   git clone https://github.com/beboo22/EliteCare.git
   ```

2. Navigate to the project directory:
   ```bash
   cd EliteCare
   ```

3. Install required dependencies:
   - If you're using **Visual Studio**, open the solution file (`.sln`) and build the project.
   - If you're using **.NET CLI**, run the following:
     ```bash
     dotnet restore
     ```

4. Configure your database connection and any other settings by modifying the `appsettings.json` file.

5. Run the application:
   - Using Visual Studio: Press **F5** to start the project.
   - Using .NET CLI:
     ```bash
     dotnet run
     ```

## Usage

- Once the application is running, you can access the Clinic Management System through your browser at `http://localhost:5000` (or the configured port).
- Sign up as an admin or user and explore the features like appointment scheduling, managing medical records, and online payments.

## 🤝 Contributing

We welcome contributions to make EliteCare better! Here’s how you can help:

1. Fork the repository
2. Create a new branch (`git checkout -b feature-name`)
3. Commit your changes (`git commit -am 'Add new feature'`)
4. Push to the branch (`git push origin feature-name`)
5. Open a Pull Request

## 📜 License

This project is licensed under the MIT License – see the [LICENSE](LICENSE) file for details.

## 📞 Contact

For any questions or suggestions, feel free to reach out:
Email: moammedtareq8@gmail.com
GitHub: beboo22

