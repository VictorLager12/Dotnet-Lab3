# Ikimina Manager

A Windows Forms application (C# / .NET) that helps the treasurer of an ikimina, a community savings and credit group, manage members, contributions, loans and repayments. Data is stored in a MariaDB database and the code follows the MVC pattern.

## Features

- Login with username and password validation
- Members: register, edit, remove, search and view a statement
- Contributions: record contributions and see member and group totals
- Loans: eligibility check, interest calculation, approval, repayments and an overdue report
- Fund summary on the Choose screen

## Technology

C#, .NET Windows Forms, ADO.NET, MySqlConnector, MariaDB (XAMPP), phpMyAdmin



## Project structure

- `Models`: data classes and repositories (all SQL)
- `Controllers`: the business rules
- `Views`: the forms