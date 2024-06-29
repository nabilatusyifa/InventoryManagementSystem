# InventoryManagementSystem

## Description
This project involves creating a simple inventory management application designed for a small store. The application tracks stock levels of products and records inventory transactions, facilitating efficient stock management.

## Business Process
- **Track product stock levels**: Maintain current stock levels of products.
- **Record inventory transactions**: Manage the addition and removal of stock through transactions.

## Database Tables
### Products
| Column     | Type         | Description          |
|------------|--------------|----------------------|
| ProductID  | Primary Key  | Unique identifier    |
| Name       | String       | Name of the product  |
| StockLevel | Integer      | Current stock level  |

### Transactions
| Column         | Type         | Description                 |
|----------------|--------------|-----------------------------|
| TransactionID  | Primary Key  | Unique identifier           |
| ProductID      | Foreign Key  | Reference to Products table |
| TransactionType| String       | Type of transaction (Add, Remove) |
| Quantity       | Integer      | Quantity of product         |
| Date           | DateTime     | Date of transaction         |

## Features
- **Product Management (ASP.NET Core)**: Add and update product details via a console application.
- **Inventory Transactions (ASP.NET Core)**: Record stock transactions through a web interface.
- **Stock Level Update (SQL Trigger)**: Automatically update product stock levels after each transaction.
- **Docker Deployment**: Containerize the application for deployment using Docker.

## Getting Started
### Prerequisites
- .NET Core SDK
- SQL Server
- Docker

### Installation
1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/simple-inventory-management.git
   cd simple-inventory-management

