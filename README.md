# Dependency Injection Container

A lightweight, custom-built Dependency Injection (DI) container implementation in C# that demonstrates the core principles of Inversion of Control (IoC) and dependency management.

## Overview

This project implements a simple yet functional dependency injection container from scratch, showcasing how modern DI frameworks work under the hood. It supports constructor injection, automatic dependency resolution, and multiple service lifetimes.

## Features

- **Constructor Injection**: Automatically resolves and injects dependencies through constructors
- **Service Lifetimes**: 
  - **Singleton**: Creates a single instance shared across all requests
  - **Transient**: Creates a new instance for each request
- **Automatic Dependency Resolution**: Recursively resolves nested dependencies
- **Type-Safe API**: Generic methods for registering and resolving services

## Architecture

### Core Components

#### `DependencyContainer`
The container responsible for registering services with their respective lifetimes.

```csharp
var container = new DependencyContainer();
container.AddSingleton<ServiceConsumer>();
container.AddTransient<HelloService>();
```

#### `DependencyResolver`
Handles the resolution of services and their dependencies, creating instances using reflection.

```csharp
var resolver = new DependencyResolver(container);
var service = resolver.getService<ServiceConsumer>();
```

#### `Dependency`
Represents a registered dependency with its type, lifetime, and implementation instance (for singletons).

## Getting Started

### Prerequisites

- .NET 10.0 or later
- C# 10.0 or later

### Running the Application

1. Clone the repository:
```bash
git clone <repository-url>
cd Dependency_Injection
```

2. Build the project:
```bash
dotnet build
```

3. Run the application:
```bash
dotnet run --project Dependency_Injection
```

## Usage Example

```csharp
// Create a container
var container = new DependencyContainer();

// Register services with different lifetimes
container.AddSingleton<ServiceConsumer>();  // Single instance
container.AddTransient<HelloService>();     // New instance per request
container.AddTransient<MessageService>();   // New instance per request

// Create a resolver
var resolver = new DependencyResolver(container);

// Resolve services (dependencies are automatically injected)
var service = resolver.getService<ServiceConsumer>();
Console.WriteLine(service.Print());
```

## How It Works

1. **Registration**: Services are registered in the container with their desired lifetime (Singleton or Transient)

2. **Resolution**: When a service is requested:
   - The resolver finds the dependency registration
   - Examines the constructor parameters
   - Recursively resolves all dependencies
   - Creates an instance using reflection
   - Caches the instance if it's a Singleton

3. **Injection**: Dependencies are automatically injected through constructors

### Example Service Chain

```
ServiceConsumer
    └── HelloService
            └── MessageService
```

When you request `ServiceConsumer`, the resolver:
- Identifies it needs `HelloService`
- Identifies `HelloService` needs `MessageService`
- Creates `MessageService` first
- Creates `HelloService` with `MessageService` injected
- Creates `ServiceConsumer` with `HelloService` injected

## Key Concepts Demonstrated

- **Inversion of Control (IoC)**: Services don't create their dependencies; they receive them
- **Dependency Injection**: Dependencies are provided from the outside
- **Service Lifetimes**: Different lifecycle management strategies
- **Reflection**: Runtime type inspection and instantiation
- **Recursive Resolution**: Handling complex dependency graphs

## Supported Lifetimes

| Lifetime | Description | Use Case |
|----------|-------------|----------|
| **Singleton** | Single instance shared across the entire application | Stateless services, configuration, caches |
| **Transient** | New instance created for each request | Stateful services, per-operation data |

## Learning Outcomes

This project is ideal for understanding:
- How DI containers work internally
- Service lifetime management
- Constructor injection patterns
- Reflection and dynamic type creation
- Dependency graph resolution
