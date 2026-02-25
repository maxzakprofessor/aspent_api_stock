# 📦 Warehouse Management System (High-Performance .NET 10 API)

[🇷🇺 Перейти к русской версии](#-система-управления-складом-high-performance-net-10-api-ru)

A professional enterprise-grade backend implementation built with **.NET 10 (LTS)**. This repository represents the high-performance stage of the ecosystem's architectural evolution, focusing on type safety, architectural integrity, and scalability.

## 🚀 Architectural Excellence: .NET Core Power
The system is built using **Clean Architecture** principles and **SOLID** design patterns. It provides a robust API for warehouse accounting, designed to handle complex inventory movements with transactional integrity.

## 🛠 Technology Stack
*   **Runtime:** .NET 10 (LTS)
*   **Framework:** ASP.NET Core Web API
*   **ORM:** Entity Framework Core (EF Core)
*   **Security:** Microsoft Identity & JWT Bearer Authentication
*   **Database:** PostgreSQL (Primary Relational Store)
*   **Reporting:** QuestPDF (High-speed PDF generation)
*   **Data Logic:** LINQ, Task Parallel Library (TPL)

## 🌟 Technical Highlights

### 1. Database Optimization (EF Core)
Successfully eliminated the **N+1 query problem**:
*   **Eager Loading:** Strategic use of `.Include()` and `.ThenInclude()` for complex stock movement relationships.
*   **Read-Only Performance:** Utilizing `.AsNoTracking()` for high-speed dashboard telemetry.
*   **Filtered Includes:** Optimized LINQ queries to minimize data transfer.

### 2. Enterprise Security & Auth
*   **Stateless JWT:** Implemented via `Microsoft.AspNetCore.Authentication.JwtBearer`.
*   **Identity System:** Integration with **Microsoft Identity** for robust user management.
*   **Access Control:** Role-Based Access Control (RBAC) ensuring secure operations.

### 3. DevOps & Deployment
*   **Docker Multi-stage:** Optimized container images (SDK for build, Runtime for execution).
*   **CI/CD Ready:** Fully configured for deployment via Render/Azure/GitHub Actions.

## 🔗 Project Links & Source Code
*   📂 **GitHub Repository:** [https://github.com](https://github.com)
*   🌐 **Angular 19 Frontend:** [https://angular-api-sklad.vercel.app](https://angular-api-sklad.vercel.app)
*   ☁️ **Backend API (Render):** [https://aspent-api-stock.onrender.com](https://aspent-api-stock.onrender.com)

## 🔑 Demo Access
*   **Login:** `admin` 
*   **Password:** `StocKZ2026$`
*   *Note: Please allow ~50s for the **"Cold Start"** on the free Render tier during the initial request.*

## 👨‍💻 Developer
**Zakiryanov M.M.**  
Fullstack Developer and System Migration Architect.

---

# 📦 Система управления складом (High-Performance .NET 10 API) [RU]

[🇺🇸 Switch to English](#-warehouse-management-system-high-performance-net-10-api)

Профессиональная реализация бэкенда на базе **.NET 10 (LTS)**. Ориентирована на строгую типизацию, чистоту архитектуры (SOLID) и высокую производительность.

## 🛠 Технологический стек
*   **.NET 10 / ASP.NET Core API**
*   **Entity Framework Core:** Решение проблемы N+1 и оптимизация запросов.
*   **Microsoft Identity:** Безопасная аутентификация и RBAC (роли).
*   **PostgreSQL:** Реляционное хранилище.

## 🔗 Ссылки проекта
*   📂 **Исходный код (GitHub):** [https://github.com](https://github.com)
*   🌐 **Frontend (Angular 19):** [https://angular-api-sklad.vercel.app](https://angular-api-sklad.vercel.app)
*   🔑 **Логин:** `admin` | **Пароль:** `StocKZ2026$`
