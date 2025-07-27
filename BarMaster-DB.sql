
-- BarMaster-DB.sql
-- Database structure for the Bar Master Final Project

-- Create database (optional)
CREATE DATABASE BarMaster;
GO
USE BarMaster;
GO

-- Users Table
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20),
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(64) NOT NULL, -- SHA256 hash
    Role NVARCHAR(20) CHECK (Role IN ('Admin', 'Manager', 'Bartender')) NOT NULL
);
GO

-- Customers Table
CREATE TABLE Customers (
    ID INT PRIMARY KEY IDENTITY(1,1),
    First_Name NVARCHAR(50) NOT NULL,
    Last_Name NVARCHAR(50) NOT NULL,
    IDNumber NVARCHAR(9) NOT NULL UNIQUE,
    Phone NVARCHAR(20),
    Email NVARCHAR(100),
    PurchaseCount INT DEFAULT 0,
    Status NVARCHAR(20) CHECK (Status IN ('Silver', 'Gold', 'Platinum')) DEFAULT 'Silver',
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- Products Table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    Amount INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Category NVARCHAR(50)
);
GO

-- Cocktails Table
CREATE TABLE Cocktails (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    Price FLOAT NOT NULL,
    Ingredients TEXT,
    Image TEXT
);
GO

-- Sales Table
CREATE TABLE Sales (
    ID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT,
    CocktailName NVARCHAR(50),
    Price FLOAT,
    Amount INT,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CustomerID) REFERENCES Customers(ID)
);
GO
