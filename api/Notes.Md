Packages use :
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.0
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.0

Mapping done by
dotnet tool install --global dotnet-ef
dotnet ef --version
dotnet ef migrations add InitialCreate
dotnet ef database update

Resource Link -

https://www.c-sharpcorner.com/article/create-a-model-with-database-table-in-net-8-using-ef-core/

https://www.c-sharpcorner.com/article/net-8-web-api-crud-operations/