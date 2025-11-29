# 📱 Phone Registration – .NET 8

A clean, modular sample project built with **ASP.NET Core (.NET 8)** for registering phone numbers, designed as a technical recruitment task.

This project demonstrates **Clean Architecture**, **Repository Pattern**, **MVC + Web API**, and **structured logging with Serilog**.

---

## 🚀 Features

* ✅ Register mobile numbers via a clean MVC UI
* ✅ RESTful API endpoint for phone registration
* ✅ Phone number validation (Iran mobile format)
* ✅ Repository Pattern for data access
* ✅ EF Core (SQL Server)
* ✅ Clean Architecture (Application / Infrastructure / Persistence)
* ✅ SMS sending service (Stub – ready for future integration)
* ✅ Structured logging with **Serilog**
* ✅ Swagger (OpenAPI) documentation
* ✅ Razor View UI
* ✅ Centralized error logging with **Elmah**

---

## 🧱 Project Architecture

The solution follows **Clean Architecture** principles:

```
PhoneRegistration
│
├── PhoneRegistration.API
│   ├── Controllers (API + MVC)
│   ├── Views
│   ├── Program.cs
│
├── PhoneRegistration.Application
│   ├── Contracts
│   │   ├── Infrastructure
│   │   │   └── ISmsService.cs
│   ├── Services
│   │   └── PhoneNumber
│   └── DTOs
│
├── PhoneRegistration.Infrastructure
│   └── Services
│       └── SmsService.cs (Stub)
│
├── PhoneRegistration.Persistence
│   ├── Context
│   ├── Repositories
│   └── Entity Configurations
```

✅ Business logic is isolated
✅ Infrastructure concerns are replaceable
✅ Easily extendable for future requirements

---

## 🔌 Technologies Used

* .NET 8
* ASP.NET Core MVC + Web API
* Entity Framework Core
* SQL Server
* Serilog (Structured Logging)
* Swagger / OpenAPI
* Bootstrap 5
* Elmah

---

## 📖 API Documentation

Swagger UI is available at:

```
/swagger
```

Example:

```
https://localhost:xxxx/swagger
```

---

## 🖥 MVC UI

Phone number registration page:

```
/
or
/PhoneNumbersMvc/Create
```

This page submits data asynchronously and displays validation and success messages dynamically.

---

## 📲 SMS Service (Stub)

The SMS service is intentionally implemented as a **stub**:

```csharp
public Task SendAsync(string mobile)
```

* Logs invocation using Serilog
* Ready for future integration with real SMS providers

📝 *This approach keeps the domain logic independent from external services.*

---

## 🪵 Logging

The project uses **Serilog** for structured logging.

Example log when SMS service is called:

```
[Information] Send sms called for mobile 09123456789
```

Logging providers can easily be extended to write to:

* File
* Seq
* Elasticsearch

---

## ⚙️ Database

* SQL Server
* EF Core
* Unique Index on Mobile Number
* `nvarchar(15)` for phone number storage

---

## ▶️ How to Run

1. Update connection string in `appsettings.json`
2. Apply database migrations (if needed)
3. Run the project
4. Navigate to `/` or `/swagger`

---

## ✅ Notes

* Phone numbers are validated before insertion
* Duplicate numbers are prevented at Database and Application level
* Designed for scalability and real-world extension

---

## 👨‍💻 Author

**Amir Asefi**
Backend Developer (.NET / Clean Architecture)
