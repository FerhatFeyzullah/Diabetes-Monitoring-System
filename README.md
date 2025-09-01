# 🩺 Diabetes Monitoring System

This project is a comprehensive web application that allows diabetes patients to monitor their blood sugar levels. Users can enter measurements based on specific time periods (morning, noon, afternoon, evening, night) to analyze their health data. The system is fully integrated with a React frontend, .NET Web API backend, and PostgreSQL database.

---

## ✅ Features

- User registration and login (JWT Token)
- Blood sugar data entry and listing through React frontend
- Categorization of measurements based on time periods
- Graphical data visualization
- Easy setup with Docker
- Advanced backend architecture (CQRS, MediatR, Repository, AutoMapper)

---

## ⚙️ Technologies Used

| Layer       | Technology                         |
|-------------|------------------------------------|
| Frontend    | React, Vite, Axios, Tailwind CSS   |
| Backend     | ASP.NET Core Web API (.NET 8)      |
| Database    | PostgreSQL                         |
| Security    | JWT Token                          |
| ORM         | Entity Framework Core              |
| Patterns    | CQRS, MediatR, Repository          |
| Deployment  | Docker, Docker Compose             |

---

## 🛠️ Installation

### 🚀 Clone the Project

```bash
git clone https://github.com/FerhatFeyzullah/Diabetes-Monitoring-System.git
cd Diabetes-Monitoring-System
```

### ⚡ Run the Full System with Docker

```bash
docker-compose up --build
```

> `frontend` → http://localhost:3000  
> `backend` → http://localhost:7014  
> `PostgreSQL` → http://localhost:5432  
> `PgAdmin` → http://localhost:5050  

---

## 🧑‍💻 Manual Startup (If not using Docker)

### Backend

```bash
cd backend
dotnet restore
dotnet ef database update
dotnet run
```

### Frontend

```bash
cd frontend
npm install
npm run dev
```

---

## 🔐 Authentication

JWT Token is used for authentication. After login, the token is stored in `Cookie` on the frontend and is included in Authorization headers for protected API requests.

---

## 📬 API Usage

### Login

```http
POST /api/Auths/Login
{
  "tc": "12345678901",
  "password": "Ornek123*"
}
```

### Create Measurement

```http
POST /api/BloodSugars/CreateBloodSugar
Authorization: Bearer {token}

{
  "value": 100,
  "timePeriod": 1,
  "symptoms": [
    "Polidipsi"
  ],
  "patientId": 2
}
```

### Get Measurements

```http
GET /api/GetBS_ByPatientAndGroupedByDateDaily
Authorization: Bearer {token}
```

---

## 🕒 Time Periods

| Period | Time Range          |
|--------|----------------------|
| 1      | Morning (07:00 - 08:00) |
| 2      | Noon    (12:00 - 13:00) |
| 3      | Afternoon (15:00 - 16:00) |
| 4      | Evening (18:00 - 19:00)   |
| 5      | Night   (22:00 - 23:00)   |

---

## 📷 Screenshots

> If you add screenshots to the `frontend/public` directory, you can reference them like this:

```md
![Login Screen](public/screenshots/login.png)
![Dashboard](public/screenshots/dashboard.png)
![Archive Screen](public/screenshots/archive.png)
```
