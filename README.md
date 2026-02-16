# Dapper Core Tutorial

A .NET 10 tutorial project demonstrating how to use **Dapper ORM** with a clean layered architecture pattern.

[![.NET](https://img.shields.io/badge/.NET-10.0-purple)](https://dotnet.microsoft.com/)
[![Dapper](https://img.shields.io/badge/Dapper-ORM-blue)](https://github.com/DapperLib/Dapper)

---

## 🌐 Languages | Diller

- [English](#english)
- [Türkçe](#türkçe)

---

## English

### 📋 Overview

This is a Unit Test project that demonstrates Dapper ORM methods using .NET 10 infrastructure. Northwind database is used as the sample database.

> **Note:** On 16.02.2026, all projects were upgraded to .NET 10.
 
### 🏗️ Project Structure

```
DapperCoreTutorial/
├── Models/                    # Entity classes (Northwind entities)
│   ├── Product.cs
│   ├── Category.cs
│   ├── Order.cs
│   ├── OrderDetail.cs
│   └── IEntity.cs
├── DataAccess/                # Data access layer
│   ├── Abstract/
│   │   ├── IProductDal.cs
│   │   └── ICategoryDal.cs
│   ├── Concrete/Dapper/
│   │   ├── DapperProductDal.cs
│   │   └── DapperCategoryDal.cs
│   ├── DapperGenericRepository.cs
│   ├── IEntityRepository.cs
│   └── DbConnect.cs
├── Business/                  # Business logic layer
│   ├── Abstract/
│   │   ├── IProductService.cs
│   │   └── ICategoryService.cs
│   ├── Concrete/
│   │   ├── ProductManager.cs
│   │   └── CategoryManager.cs
│   ├── QueryMethods.cs
│   ├── ExecuteMethods.cs
│   └── DapperAsyncMethods.cs
└── DapperORMUnitTest/         # Unit tests
    └── DapperUnitTest.cs
```

### 🛠️ Technologies

- **.NET 10**
- **Dapper** - Micro ORM
- **Dapper.Contrib.Extensions** - CRUD extensions for Dapper
- **System.Data.SqlClient** - SQL Server connectivity
- **Microsoft.Extensions.Configuration** - Configuration management

### ✨ Features

| Layer | Description |
|-------|-------------|
| **DataAccess** | Generic Repository pattern for Dapper. Dapper.Contrib NuGet package is used to design the generic repository easily. Abstract interfaces and Concrete classes are created for each entity. This design satisfies basic CRUD operations. |
| **Business** | Contains `QueryMethods` and `ExecuteMethods` class files which have Dapper's built-in Query and Execute methods respectively. Also includes `DapperAsyncMethods` file for asynchronous operations support. |
| **Models** | Contains entities compatible with the Northwind database (Products, Categories tables, etc.) |

![image](https://user-images.githubusercontent.com/37337606/142295329-7d1429f5-f3b8-4e67-98ac-eccc37f0800b.png)

### 📖 Sample Code

**IProductDal**

![image](https://user-images.githubusercontent.com/37337606/142295690-584edca1-8742-42b1-ba9e-f85cae1425f1.png)

**DapperProductDal**

![image](https://user-images.githubusercontent.com/37337606/142295729-0911da31-146c-407d-b61b-e03edc8e3134.png)

### 🚀 Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/mertmtn/DapperCoreTutorial.git
   ```

2. Update the connection string in `DbConnect.cs` to point to your SQL Server instance with Northwind database.

3. Build the solution:
   ```bash
   dotnet build
   ```

4. Run the tests:
   ```bash
   dotnet test
   ```

---

## Türkçe

### 📋 Genel Bakış

Dapper ORM'ine ait metotları barındıran unit test projesidir. .NET 10 alt yapısına sahiptir. Northwind veritabanı kullanılmıştır.

> **Not:** 16.02.2026 tarihinde bütün projeler .NET 10'a yükseltildi.

### ✨ Özellikler

| Katman | Açıklama |
|--------|----------|
| **DataAccess** | Dapper için GenericRepository tasarımı yapıldı. Her entity için Abstract interface ve Concrete sınıflar oluşturuldu. Dapper.Contrib nuget paketi kurularak metotları temel CRUD işlemleri için geliştirildi. |
| **Business** | QueryMethods ve ExecuteMethods dosyaları bulunur. Bu dosyalar sırasıyla Dapper'a ait Query ve Execute metodlarını barındırır. Ayrıca Asenkron işlemleri de desteklediği için DapperAsyncMethods dosyası da bulunur. |
| **Models** | Northwind'e uyumlu entityler mevcuttur (Products, Categories tabloları vs.) |

`DapperUnitTest.cs`'de örnek testleri bulabilirsiniz.

DataAccess projesinde Abstract interface'de oluşturulan metotlar, generic repository'deki ortak metotlara ek olarak oluşturulabilir.

---

## 📄 License

This project is open source and available for learning purposes.

## 👤 Author

**mertmtn** - [GitHub](https://github.com/mertmtn)
