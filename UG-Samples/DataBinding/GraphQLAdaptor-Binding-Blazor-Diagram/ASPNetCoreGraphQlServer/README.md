# Create an ASP.NET Core GraphQL Server

GraphQL is a query language for APIs with which you can get exactly what you need and nothing more. The GraphQLAdaptor provides an option to retrieve data from the GraphQL server.

## Steps to run the project

### Create a new ASP.NET Core project:
Open Visual Studio and create a new ASP.NET Core Web Application.

### Define GraphQL Schema:
Define your GraphQL schema using GraphQL types. You can create a class that represents your data types and define a schema using GraphQL types. For example:
```cshtml
public class Order
{
    public int? OrderID { get; set; }
    public string? CustomerID { get; set; }
    public string EmployeeID { get; set; }        
}
```
### Create a GraphQL Query:
Define a GraphQL query for fetching Order. For example:
```cshtml
public class GraphQLQuery
{

    #region OrdersData Resolver
    public ReturnType<Order> OrdersData(DataManagerRequest dataManager)
    {
        IEnumerable<Order> result = Orders;
        int count = result.Count();
        return dataManager.RequiresCounts ? new ReturnType<Order>() { Result = result, Count = count } : new ReturnType<Order>() { Result = result };
    }
}
```
Ensure you have the necessary NuGet packages installed, like HotChocolate.AspNetCore
### Configure Services:
In the Program.cs file, add the necessary services for GraphQL:
```cshtml
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer().AddQueryType<GraphQLQuery>();
```
### Run the Application:
Run your ASP.NET Core GraphQL server. You can use the GraphQL Playground (usually available at /graphql) to test your queries.