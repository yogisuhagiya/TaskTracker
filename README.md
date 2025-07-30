# 🗂️ TaskTracker

A simple console-based task management application built using **Clean Architecture**, **.NET 8**, and **Dependency Injection (DI)** principles.

---

## 📐 Architecture Overview

This project uses **Clean Architecture** to separate concerns:

- **Domain**: Core entities and logic (`TaskItem`)
- **Application**: Business logic & service interfaces (`ITaskService`)
- **Infrastructure**: Data storage and implementation (`InMemoryTaskRepository`)
- **ConsoleApp**: Presentation layer with user interaction (`App`, `Program.cs`)


---

## 🧪 Features

- Add tasks
- List all tasks
- Mark a task as complete
- All operations via simple menu
- Uses in-memory storage

---

## 🛠️ Tech Stack

- [.NET 8](https://dotnet.microsoft.com/)
- C#
- xUnit (Unit Testing)
- Moq (Mocking)
- Microsoft.Extensions.DependencyInjection

---

## 🚀 Getting Started

### Prerequisites

- [Visual Studio Code](https://code.visualstudio.com/)
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)

### Installation

```bash
git clone https://github.com/yogisuhagiya/TaskTracker.git
cd TaskTracker
dotnet restore
