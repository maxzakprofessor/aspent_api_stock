# 📦 Warehouse Management System (High-Performance .NET 10 API)

[🇷🇺 Перейти к русской версии](#-система-управления-складом-high-performance-net-10-api-ru)

A professional enterprise-grade backend implementation built with **.NET 10 (LTS)**. This repository represents the high-performance stage of the ecosystem's architectural evolution, focusing on type safety, architectural integrity, and scalability.

## 🚀 Architectural Excellence: .NET Core Power
The system is built using **Clean Architecture** principles and **SOLID** design patterns. It provides a robust API for warehouse accounting, designed to handle complex inventory movements with transactional integrity.

## 🛠 Technology Stack
*   **Runtime & Framework:** .NET 10 (LTS) / ASP.NET Core Web API.
*   **Architecture Patterns:** Clean Architecture, Repository Pattern, Dependency Injection (DI).
*   **ORM & Data Access:** Entity Framework Core (EF Core) with Optimized LINQ & TPL.
*   **Security & Auth:** Microsoft Identity, JWT Bearer Authentication, Role-Based Access Control (RBAC).
*   **Database:** PostgreSQL (Primary Relational Store).
*   **Validation & Logic:** FluentValidation (Strongly-typed rules), Business Logic Services.
*   **Reporting:** QuestPDF (High-speed asynchronous PDF generation).
*   **API Documentation:** Swagger / OpenAPI 3.0.

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
*   **Docker Multi-stage Build:** Optimized container images by separating SDK (build) and Runtime (execution) stages.
*   **CI/CD Ready:** Fully configured for automated deployment via Vercel, Render, Azure, and GitHub Actions.

## 🔗 Source Code
*   🚀 **[.NET 10 Backend Repo](https://github.com/maxzakprofessor/aspent_api_stock.git)**
*   🅰️ **[Angular 19 Frontend Repo](https://github.com/maxzakprofessor/angular-api-sklad.git)**

## 🔑 Demo Access
*   🌐 **[Live Angular 19 App](https://angular-api-sklad-sho9.vercel.app)**
*   **Login:** `admin` 
*   **Password:** `Admin123!`
*   *Note: Please allow ~50s for the **"Cold Start"** on the free Render tier during the initial request.*

## 👨‍💻 Developer
**Zakiryanov M.M.**  
Fullstack Developer and System Migration Architect.

---

# 📦 Система управления складом (High-Performance .NET 10 API) [RU]

[🇺🇸 Switch to English](#-warehouse-management-system-high-performance-net-10-api)

Профессиональная реализация бэкенда корпоративного уровня на базе **.NET 10 (LTS)**. Данный репозиторий представляет собой высокопроизводительный этап эволюции экосистемы, ориентированный на строгую типизацию, чистоту архитектуры и масштабируемость.

## 🚀 Архитектурное совершенство: Мощь .NET Core
Система построена на принципах **Clean Architecture** и паттернах проектирования **SOLID**. Предоставляет надежный API для складского учета, разработанный для обработки сложных перемещений запасов с сохранением транзакционной целостности.

## 🛠 Технологический стек
*   **Платформа:** .NET 10 (LTS) / ASP.NET Core Web API.
*   **Архитектура:** Clean Architecture, Repository Pattern, Dependency Injection (DI).
*   **ORM и работа с данными:** Entity Framework Core (EF Core), LINQ, Task Parallel Library (TPL).
*   **Безопасность:** Microsoft Identity, JWT Bearer Authentication, ролевая модель (RBAC).
*   **База данных:** PostgreSQL (Реляционное хранилище).
*   **Валидация:** FluentValidation (строгая типизация правил).
*   **Отчетность:** QuestPDF (асинхронная высокоскоростная генерация PDF).
*   **Документация:** Swagger / OpenAPI 3.0.

## 🌟 Технические особенности

### 1. Оптимизация БД (EF Core)
Успешно решена проблема **N+1 запросов**:
*   **Eager Loading:** Стратегическое использование `.Include()` и `.ThenInclude()` для сложных связей ТМЦ.
*   **Read-Only Performance:** Использование `.AsNoTracking()` для ускорения работы дашбордов.
*   **LINQ Optimization:** Минимизация передачи данных между БД и приложением.

### 2. Безопасность и Аутентификация
*   **Stateless JWT:** Реализовано через `JwtBearer` для обеспечения горизонтального масштабирования.
*   **Identity System:** Интеграция с **Microsoft Identity** для управления пользователями и паролями.
*   **RBAC:** Ролевая модель доступа для разграничения прав администраторов и сотрудников.

### 3. DevOps и Контейнеризация
*   **Docker Multi-stage Build:** Оптимизация Docker-образов через разделение стадий сборки (SDK) и запуска (Runtime).
*   **CI/CD Ready:** Полная готовность к автоматизированному деплою через Vercel, Render, Azure и GitHub Actions.

## 🔗 Исходный код
*   🚀 **[.NET 10 Backend репозиторий](https://github.com/maxzakprofessor/aspent_api_stock.git)**
*   🅰️ **[Angular 19 Frontend репозиторий](https://github.com/maxzakprofessor/angular-api-sklad.git)**

## 🔑 Демонстрационный доступ
*   🌐 **[Angular 19 Приложение (Vercel)](https://angular-api-sklad-sho9.vercel.app)**
*   **Логин:** `admin` 
*   **Пароль:** `Admin123!`
*   *Примечание: Пожалуйста, подождите около 50 секунд для "холодного старта" на бесплатном тарифе Render при первом запросе.*
