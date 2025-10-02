# 🏠 Hostly - Vacation Rental Management System

<div align="center">

[![.NET](https://img.shields.io/badge/.NET-8.0-purple.svg)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![Clean Architecture](https://img.shields.io/badge/Architecture-Clean%20Architecture-blue.svg)](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
[![DDD](https://img.shields.io/badge/Pattern-DDD-green.svg)](https://martinfowler.com/bliki/DomainDrivenDesign.html)
[![Entity Framework](https://img.shields.io/badge/ORM-Entity%20Framework-orange.svg)](https://docs.microsoft.com/en-us/ef/)
[![Dapper](https://img.shields.io/badge/ORM-Dapper-red.svg)](https://github.com/DapperLib/Dapper)
[![PostgreSQL](https://img.shields.io/badge/Database-PostgreSQL-blue.svg)](https://www.postgresql.org/)

**A modern, scalable vacation rental platform built with Clean Architecture, DDD principles, and enterprise-grade technologies.**

</div>

---

## 🚀 Overview

**Hostly** is a comprehensive vacation rental management system designed to handle apartment bookings, user management, and review systems. Built from the ground up using **Clean Architecture** principles, **Domain-Driven Design (DDD)**, and modern .NET technologies, this project demonstrates enterprise-level software development practices.

### 🎯 Key Features

- **🏢 Apartment Management** - Complete apartment listing and search functionality
- **📅 Booking System** - Advanced reservation management with pricing calculations
- **👥 User Management** - Secure user registration and authentication
- **⭐ Review System** - Customer feedback and rating management
- **💰 Dynamic Pricing** - Intelligent pricing service with amenities upcharge
- **📧 Email Notifications** - Automated email notifications for booking events
- **🔍 Advanced Search** - Powerful apartment search with filtering capabilities

---

## 🏗️ Architecture

This project follows **Clean Architecture** principles with clear separation of concerns:

```
📁 src/
├── 🏛️ Hostly.Domain/          # Core business logic and entities
├── 📱 Hostly.Application/      # Application services and use cases  
└── 🔧 Hostly.Infrastructure/   # Data access and external services
```

### 🎨 Design Patterns & Principles

- **🏛️ Clean Architecture** - Independent, testable, and maintainable code
- **🧠 Domain-Driven Design (DDD)** - Rich domain models with business logic encapsulation
- **📋 CQRS** - Command Query Responsibility Segregation with MediatR
- **🎭 Repository Pattern** - Data access abstraction
- **🏭 Unit of Work** - Transaction management
- **📢 Domain Events** - Decoupled event-driven architecture
- **✅ Result Pattern** - Functional error handling without exceptions
- **🛡️ Validation Pipeline** - Comprehensive input validation with FluentValidation

---

## 🛠️ Technology Stack

### Core Technologies
- **.NET 8.0** - Latest LTS version with performance improvements
- **C# 12** - Modern language features and nullable reference types
- **Entity Framework Core 9.0** - Code-first ORM with PostgreSQL
- **Dapper 2.1.66** - High-performance micro-ORM for complex queries
- **PostgreSQL** - Robust, open-source relational database
- **MediatR 13.0** - In-process messaging for CQRS implementation

### Key Libraries
- **FluentValidation** - Fluent validation library for .NET
- **Npgsql** - PostgreSQL database provider
- **EFCore.NamingConventions** - Snake case naming convention support

---

## 🏛️ Domain Model

### Core Entities

```csharp
// 🏠 Apartment Aggregate
public sealed class Apartment : Entity
{
    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Address Address { get; private set; }
    public Money Price { get; private set; }
    public List<Amenity> Amenities { get; private set; }
}

// 📅 Booking Aggregate
public sealed class Booking : Entity
{
    public Guid ApartmentId { get; private set; }
    public Guid UserId { get; private set; }
    public DateRange Duration { get; private set; }
    public Money TotalPrice { get; private set; }
    public BookingStatus Status { get; private set; }
}

// 👤 User Aggregate
public sealed class User : Entity
{
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }
}

// ⭐ Review Aggregate
public sealed class Review : Entity
{
    public Guid ApartmentId { get; private set; }
    public Guid BookingId { get; private set; }
    public Rating Rating { get; private set; }
    public Comment Comment { get; private set; }
}
```

### 💰 Value Objects
- **Money** - Currency-aware monetary values
- **DateRange** - Immutable date range operations
- **Rating** - Constrained rating values (1-5)
- **Address** - Complex address information

---

## 🚀 Getting Started

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/) 12+
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/hostly.git
   cd hostly
   ```

2. **Configure the database**
   ```bash
   # Update connection string in appsettings.json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Database=hostly_db;Username=your_user;Password=your_password"
   }
   ```

3. **Restore dependencies**
   ```bash
   dotnet restore
   ```

4. **Run database migrations**
   ```bash
   dotnet ef database update
   ```

5. **Build and run**
   ```bash
   dotnet build
   dotnet run --project src/Hostly.Infrastructure
   ```

---

## 📊 Database Schema

The application uses **Entity Framework Core** with **PostgreSQL** and follows snake_case naming conventions:

```sql
-- Core tables
apartments          -- Apartment listings
bookings           -- Reservation records  
users              -- User accounts
reviews            -- Customer reviews

-- Supporting tables
amenities          -- Available amenities
apartment_amenities -- Many-to-many relationship
```

---

## 🎯 Use Cases & Commands

### Booking Management
```csharp
// Reserve a new booking
public record ReserveBookingCommand(
    Guid ApartmentId,
    Guid UserId,
    DateOnly StartDate,
    DateOnly EndDate
) : ICommand<Guid>;

// Get booking details
public record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;
```

### Apartment Management
```csharp
// Search apartments with filters
public record SearchApartmentsQuery(
    string? SearchTerm,
    decimal? MinPrice,
    decimal? MaxPrice,
    DateOnly? StartDate,
    DateOnly? EndDate
) : IQuery<IEnumerable<ApartmentResponse>>;
```

### Review System
```csharp
// Add a new review
public record AddReviewCommand(
    Guid BookingId,
    int Rating,
    string Comment
) : ICommand;
```

---

## 🧪 Testing Strategy

The project is designed with testability in mind:

- **Unit Tests** - Domain logic and business rules
- **Integration Tests** - Repository and database interactions
- **Behavior Tests** - End-to-end application scenarios
- **Contract Tests** - API and external service contracts

---

## 🔧 Infrastructure Components

### Data Access Layer
- **Entity Framework Core** - Primary ORM for complex operations
- **Dapper** - High-performance queries and bulk operations
- **Repository Pattern** - Clean data access abstraction
- **Unit of Work** - Transaction management

### Cross-Cutting Concerns
- **Logging** - Structured logging with Microsoft.Extensions.Logging
- **Validation** - FluentValidation with pipeline behaviors
- **Error Handling** - Result pattern with custom exceptions
- **Email Service** - Abstraction for email notifications

---

## 🚧 Current Status

> **⚠️ Project Status: In Development**

This project is currently under active development. The core architecture and domain models are implemented, with the following areas completed:

### ✅ Completed Features
- [x] Clean Architecture setup
- [x] Domain models and entities
- [x] Repository implementations
- [x] Entity Framework configurations
- [x] Dapper integration
- [x] CQRS with MediatR
- [x] Validation pipeline
- [x] Logging infrastructure
- [x] Database schema design

### 🔄 In Progress
- [ ] API Controllers (Web API layer)
- [ ] Authentication & Authorization
- [ ] Comprehensive test suite
- [ ] Docker containerization
- [ ] CI/CD pipeline

### 📋 Planned Features
- [ ] Real-time notifications
- [ ] Payment integration
- [ ] Advanced analytics
- [ ] Mobile API endpoints
- [ ] Admin dashboard
- [ ] Performance monitoring

---

## 🤝 Contributing

This project demonstrates enterprise-level development practices and serves as a learning resource. Contributions, suggestions, and feedback are welcome!

### Development Guidelines
- Follow Clean Architecture principles
- Maintain high test coverage
- Use meaningful commit messages
- Follow C# coding conventions
- Document complex business logic

---

## 📚 Learning Resources

This project showcases several advanced concepts:

- **Clean Architecture** - [Uncle Bob's Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- **Domain-Driven Design** - [Eric Evans' DDD Book](https://www.domainlanguage.com/ddd/)
- **CQRS Pattern** - [Microsoft CQRS Documentation](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)
- **Result Pattern** - [Error Handling in C#](https://enterprisecraftsmanship.com/posts/functional-c-primitive-obsession/)

---

