# microservice

## To create project in .net8

- To create solution
 ```
  dotnet new sln -n DemoMicroserviceSolutin
 ```
 - To create webapi with name and path
 ```
  dotnet new webapi -n CustomerWebApi -o \src
 ```

 - To create add reference the project webapi with solution
 ```
  dotnet sln DemoMicroserviceSolution.sln  add .\src\
 ```
 
 ## Create microsservice to foudation learn
 
 - package should install to intial the project with microservice
 ```C#
    dotnet add package Microsoft.EntityFrameworkCore.Design -v 8.0.0
    dotnet add package Microsoft.EnitityFrameworkCore.SqlServer -v 8.0.0
    dotnet add package Microsoft.EntityFrameworkCore.Tools -v 8.0.0
 ```
  
 ## Command to run project  

```dotnetcli
    dotnet watch --project projectName run
```