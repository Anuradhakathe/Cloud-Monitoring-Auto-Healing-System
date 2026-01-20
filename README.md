# ☁️ Cloud Monitoring & Auto-Healing System

## 📌 Overview
The **Cloud Monitoring & Auto-Healing System** is an enterprise-style backend application built using **ASP.NET Core** that continuously monitors server health (CPU, memory, availability), detects incidents, and simulates automatic recovery actions.

This project is designed to reflect **real-world cloud monitoring systems** used by managed service providers and data center companies such as ESDS.

---

## 🎯 Key Features
- Real-time server health monitoring
- Background job scheduling using Hangfire
- Automatic incident detection and logging
- Auto-healing simulation for unhealthy servers
- RESTful APIs for monitoring data
- Dashboard for system visibility
- Clean, scalable, enterprise-style architecture

---

## 🏗️ High-Level Architecture
Client / Dashboard
       |
       v
ASP.NET Core Web API
       |
       v
Background Jobs (Hangfire)
       |
       v
SQL Server Database


---

## 🛠️ Tech Stack
- **Backend:** ASP.NET Core (.NET 8)
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **Background Jobs:** Hangfire
- **API Documentation:** Swagger
- **UI:** Razor Views
- **Tools:** Visual Studio, Git, GitHub

---

## 🔁 How Monitoring Works (Simple Flow)

1. A background job runs every minute.
2. It checks:
   - CPU usage
   - Memory usage
   - Server availability
3. If thresholds are crossed:
   - An incident is created
   - Server status changes to Warning or Critical
4. Auto-healing logic simulates recovery actions.
5. All monitoring data is stored in SQL Server.
6. APIs expose current status and historical data.
7. Dashboard displays system health in real time.

---

## ▶️ How to Run the Project

1. Clone the repository
```bash
git clone https://github.com/Anuradhakathe/Cloud-Monitoring-Auto-Healing-System.git
```
2.Open the solution in Visual Studio
3.Update the SQL Server connection string in appsettings.json
4.Apply database migrations
```bash
  Update-Database
```
5.Run the application
```bash
  dotnet run
```
6.Open in browser:
Swagger UI: https://localhost:7216/swagger
Dashboard: https://localhost:7216/Dashboard

