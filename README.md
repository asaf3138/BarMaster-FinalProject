# Bar Master – Final Project

🎓 **Project Grade:** 92  
🛠️ **Technologies:** C#, Windows Forms, SQL Server, Guna UI  
📁 **Type:** Software Engineering Graduation Project  

---

## 📌 Overview

Bar Master is a complete bar management desktop system developed as a final project in a software engineering program.

The system provides an intuitive interface for managing customers, cocktails, inventory, sales, and user permissions. Built with C# using Windows Forms and SQL Server, it integrates Guna UI to deliver a modern and responsive user experience.

The main goal was to create a simple, efficient, and expandable solution for small to medium-sized bars, allowing full control of operations under one unified platform. Key system elements include:

- Customer tracking with status levels (Silver / Gold / Platinum)
- Cocktail management and preview
- Inventory and shortage alerts
- Purchase flow with discounts
- Graph-based sales and revenue analysis
- Role-based access for bartenders, waiters, and managers

Bar Master was developed following best practices in OOP, UI/UX design, and secure data handling (e.g., SHA256 password hashing).





## ✨ Features

- **Cocktail Management** – Add, edit, preview, and purchase cocktails. Includes dynamic ingredient handling and visual "SOLD OUT" indicators.
- **Customer Management** – Full CRUD operations for customers, including tracking of purchase history and automatic status updates (Silver / Gold / Platinum).
- **Inventory Management** – Track stock levels with real-time shortage alerts. Add, update, or delete products with a simple UI.
- **Sales Analysis** – Visual charts (bar and line graphs) of sales data, top cocktails, and monthly revenue.
- **Dashboard** – Real-time insights into key metrics like top customers, best-selling cocktails, and low-stock products.
- **Role-Based Access** – Secure login with role permissions (Admin, Bartender, Waiter).
- **Modern UI/UX** – Clean interface built with Guna UI2 components, animations (Zoom-In for previews), and user-friendly design.
- **Data Security** – Password hashing using SHA256 and SQL query protection.





## 🚀 Getting Started

To run the Bar Master system locally, follow these steps:

### ✅ Prerequisites
- Windows 10 or higher
- Visual Studio 2022 or newer
- SQL Server (local installation or SQL Server Express)

### 📥 Clone the repository
```bash
git clone https://github.com/asaf3138/BarMaster-FinalProject.git
📂 Open the project
Open the BarMaster-FinalProject folder in Visual Studio.

Open the barmaster.sln solution file.

Build the solution (Ctrl+Shift+B).

🛠 Configure the database
Ensure your SQL Server instance is running locally.

Open App.config and update the connection string if needed:

xml
Copy
Edit
<connectionStrings>
  <add name="DB" connectionString="Data Source=localhost;Initial Catalog=BarMaster;Integrated Security=True" />
</connectionStrings>
Use the included SQL script (or your own) to create the necessary tables:

Cocktails

Products

Customers

Sales

Users

▶️ Run the program
Press F5 to launch the system.

Log in using a predefined user or register a new one.






## 📂 Database Structure

The system uses a SQL Server database consisting of five main tables:

### 🥂 Cocktails
| Column     | Type        | Description                         |
|------------|-------------|-------------------------------------|
| ID                | int              | Primary Key                         |
| Name          | nvarchar(50)| Cocktail name                       |
| Price            | float       | Price of the cocktail               |
| Ingredients | text        | Ingredients list (e.g. "Gin=50")    |
| Image         | text        | Path to image file                  |

---

### 👥 Customers
| Column        | Type         | Description                          |
|---------------|--------------|--------------------------------------|
| ID            | int          | Primary Key                          |
| First_Name    | nvarchar(50) | Customer first name                  |
| Last_Name     | nvarchar(50) | Customer last name                   |
| IDNumber      | nvarchar(9)  | Israeli ID number                    |
| Phone         | nvarchar(20) | Phone number                         |
| Email         | nvarchar(100)| Email address                        |
| PurchaseCount | int          | Number of purchases                  |
| Status        | nvarchar(20) | Customer level (Silver/Gold/Platinum)|
| CreatedAt     | datetime     | Join date                            |

---

### 📦 Products
| Column   | Type          | Description             |
|----------|---------------|-------------------------|
| ProductID| int           | Primary Key             |
| Name     | nvarchar(50)  | Product name            |
| Amount   | int           | Quantity in stock       |
| Price    | decimal(10,2) | Unit price              |
| Category | nvarchar(50)  | Alcohol, Syrup, Juice...|

---

### 🛒 Sales
| Column      | Type         | Description                      |
|-------------|--------------|----------------------------------|
| ID          | int          | Primary Key                      |
| CustomerID  | int          | Foreign Key to `Customers.ID`    |
| CocktailName| nvarchar(50) | Cocktail bought                  |
| Price       | float        | Price at time of purchase        |
| Amount      | int          | Number of items purchased        |
| CreatedAt   | datetime     | Purchase date                    |

---

### 🔐 Users
| Column   | Type         | Description                     |
|----------|--------------|---------------------------------|
| UserID   | int          | Primary Key                     |
| FullName | nvarchar(100)| Full name                       |
| Phone    | nvarchar(20) | Contact number                  |
| Email    | nvarchar(100)| Login email                     |
| Password | nvarchar(64) | Hashed with SHA256              |
| Role     | nvarchar(20) | Admin / Manager / Bartender     |




## 🧠 System Logic & Highlights

### 🛒 Smart Purchase Flow
- Customers (including guests) can buy cocktails via a dedicated purchase form.
- Discounts are applied automatically based on customer status:
  - Silver: no discount
  - Gold: 10%
  - Platinum: 20%
- Purchases update stock quantities and increment the customer’s purchase count.
- Customer status is upgraded dynamically:
  - 5 purchases → Gold
  - 10 purchases → Platinum

### 🍸 Inventory-Aware Cocktails
- Each cocktail has a list of required ingredients (e.g., "Gin=50").
- When stock is insufficient, the cocktail is marked as *SOLD OUT* and grayed out visually.
- The system prevents purchases of cocktails that can't be made due to missing ingredients.

### 🔄 Dynamic Forms
- Cocktail creation form includes dynamic ingredient selectors with add/remove support.
- Inventory and customer forms include dynamic validation and search as you type.

### 🔐 Role-Based Access
- Users are assigned roles (Admin, Manager, Bartender).
- Permissions are enforced in the UI – e.g., waiters cannot delete customers or access settings.
- Passwords are stored hashed using SHA256 for basic security.

### 📊 Interactive Analytics
- The system includes dashboards with:
  - Bar charts for most sold cocktails
  - Monthly revenue graphs
  - Top customers
  - Product shortage lists
- All charts are generated from SQL queries and rendered with Guna Charts.

### 🧭 Form Navigation Engine
- All screens use a navigation manager to move between forms seamlessly.
- Enhances the UX with smooth transitions and consistent structure.

### 🎨 Zoom-In Preview
- Clicking a cocktail opens a large preview with ingredients, image, and a Buy button.
- Preview includes a smooth zoom-in animation for a modern user experience.

