# Driving Vehicle License Department (DVLD) System 🚗

## 📌 Overview

The DVLD (Driving Vehicle License Department) System is a desktop-based application developed using **C# (Windows Forms)** and **SQL Server**.

It simulates a real-world driving license management system that handles the full lifecycle of license applications, including submission, testing, approval, and license issuance.

The system is built using **Three-Tier Architecture** to ensure clean structure, scalability, and maintainability.

---

## 🧱 Architecture

The application follows a structured 3-layer architecture:

* **Presentation Layer (UI)** → Windows Forms
* **Business Logic Layer (BLL)** → Handles validation and workflows
* **Data Access Layer (DAL)** → Handles database operations (ADO.NET)

---

## 🎯 Core Modules

* 👤 People Management
* 👥 Users Management
* 🚗 Drivers Management
* 📄 Applications Management

---

## 📄 Supported Application Types

* New Local Driving License
* Renew Driving License
* Replacement (Lost / Damaged)
* Release Detained License
* New International License
* Retake Test

---

## 🚦 License Workflow

1. Select or create a person (Custom Find Person Control)
2. Choose license class
3. Validate conditions (no duplicates, active license checks)
4. Schedule tests:

   * Vision Test
   * Written Test
   * Street Test
5. Issue license after passing all tests

---

## 🔍 Features

* Full application lifecycle management
* Sequential test system with validation
* Role-based access control
* Advanced filtering & search
* DataGridView with Context Menu actions
* Custom reusable controls
* Real-time validation and error handling


---

## ⚙️ Technologies Used

* C#
* .NET Framework 4.6
* Windows Forms
* SQL Server
* ADO.NET
* Three-Tier Architecture
* Object-Oriented Programming (OOP)

---

## 🧠 Key Concepts Applied

* Business Logic Implementation
* Workflow Management
* Role-Based Access Control
* Data Validation
* Database Design
* Layered Architecture

---

## ▶️ How to Run

1. Open the project in Visual Studio
2. Configure SQL Server connection
3. Restore the database
4. Build and run the application

---

## 🚀 Future Improvements

* Improve UI/UX design
* Add reporting system
* Add notifications system

---
