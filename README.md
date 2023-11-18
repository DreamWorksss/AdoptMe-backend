# Adopt Me - Server

This application serves as the backend application for the AdoptMe platform.



## Tech Stack
**ASP.NET Core 7.0**  
**PostgreSQL 16**


## Pre-requisites

Install PostgreSQL with default settings and the password set to **Admin**

Create a database from pgAdmin4 with the name **AdoptMe_RO_CJ**, on port **5432**

Install Visual Studio 2022 Community (I think Rider works too, I should test this. Also, EntityFramework tools should be installed when the VS is configuring the project)
    
## Run Locally

Clone the project

```bash
git clone https://github.com/DreamWorksss/AdoptMe-backend.git
```

Open the solution in Visual Studio (Rider compatibility not documented yet)

Update the database(You can use LCTRL + ` to open a terminal in VS)

```bash
dotnet ef database update --project AdoptMe.Repository --startup-project AdoptMe.Web
```

Start the server from VS

## Adding migrations

Migrations have a special command as we need to specify both the project containing the DbContext and the project containing the connection strings.

When you want to add a migration you should use

```bash
dotnet ef migrations add Migration_Name --project AdoptMe.Repository --startup-project AdoptMe.Web
```

