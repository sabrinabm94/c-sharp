# Resume
Apis to control bank accounts, bank actios and users.

## Methods variables

### Acounts
* list

* list by id

* register

* delete


### Bank actions
* deposit

* transfer

* withdraw


### Users
* list

* list by id

* register

* delete

* login

* update

---

# Project architecture

* Framework: ASP.NET Core

* Api data format: json

* Database: MySql

* Database creation and manipulation: Entity Framework

* Front end: html, css and jQuery

---

# Instalation
Install the Entity Framework for MySQL using the comand below in NuGet Console.

Install-Package Pomelo.EntityFrameworkCore.MySql

---

# Migration
After making changes in the models or the database, perform a new migration using the commands below.

Add-Migration your-migration-name

Update-Database
