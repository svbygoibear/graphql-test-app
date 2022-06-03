<h1 align="center">
  <a href="https://raw.githubusercontent.com/svbygoibear/graphql-test-app/master/img/graphql-hotchocolate.jpg"><img src="https://raw.githubusercontent.com/svbygoibear/graphql-test-app/master/img/graphql-hotchocolate.jpg" alt="graphql-test-app.hotchocolate" width="250"></a>
  <br>
  graphql-test-app.hotchocolate
  <br>
</h1>

<h4 align="center">Implementing GraphQL in C# using Hot Chocolate</h4>
<br>
<br>

## What is [Hot Chocolate](https://github.com/ChilliCream/hotchocolate)

[Hot Chocolate](https://github.com/ChilliCream/hotchocolate) is an open-source GraphQL server for the Microsoft .NET platform that is compliant with the newest GraphQL October 2021 spec + Drafts, which makes Hot Chocolate compatible to all GraphQL compliant clients like Strawberry Shake, Relay, Apollo Client, and various other clients and tools. [Hot Chocolate](https://github.com/ChilliCream/hotchocolate) can be used for:

- Stand-alone ASP.NET Core GraphQL Server.
- Serverless Azure Function or Amazon Lambda that serves up a GraphQL server.
- GraphQL Gateway for a federated data graph that pulls all your data sources together to create the one source of truth.

### Hot Chocolate

[Hot Chocolate](https://github.com/ChilliCream/hotchocolate) is the base for creating a GraphQL server, and there are various approaches to add it to a project;

- [Hot Chocolate Getting Started](https://chillicream.com/docs/hotchocolate/get-started)
- [Code First Example](https://www.learmoreseekmore.com/2021/03/overview-hotchocolate-graphql-implementation-in-pure-code-first-approach.html)

### Banana Cake Pop

[Banana Cake Pop](https://chillicream.com/docs/bananacakepop) is an interface that can be used to view and test any GraphQL server implementations. It works well with Hot Chocolate and any other GraphQL server.

This would be the GraphQL replacement in some ways for our `swaggerdocs`, but given that we can mix REST and GraphQL together, it is possible to have both documentation sets live alongside one-another.

## Getting Started

This sample application makes use of (and requires that you have it running on your machine);

- The latest .NET 6 (LTS)
- Docker (and docker client)

You can either use Docker to run this app in Visual Studio, or make use of IIS if you simply want to debug/have a look at it locally. First steps are to:

- Clone the repo
- Open the project up in Visual Studio
- Run in the `IIS Express` profile for quick local testing.
  Viola! As simple as that. But now for digging into how the code is setup...

### Code Setup

The first things to do on any project is to include the `Hot Chocolate` nuget package - this project uses the latest `v12` for .NET Core. Keep in mind that the syntax will be a bit different in older versions (as well as older versions of .NET). Refer to the official docs to see what the implementation is for your version. Using CLI, you can simply add the package.

```
dotnet add package HotChocolate.AspNetCore
```

#### Workspace Structure

Most of this project makes use of a simple MVC pattern, the difference is that we're introducing `Service` classes which contains our logic and then `Query` classes that calls the service class to expose queries to GraphQL.

```
$HOME
    |_ graphql-test-app.hotchocolate
        |_ GraphQLQueries
        |_ Models
        |_ Service
        |_ IService
            |_ etc.
```

#### Query Class

With `Hot Chocolate` you're only allowed to register 1 query per project, but you can get around this to logically separate out queries by decorating the query class with `ExtendObjectType`:

```
[ExtendObjectType(Name = "Query")]
public class WeatherForecastQuery
{
    ...
}
```

In our query class we make use of the service we've made to return a query - in this case it would be `WeatherForecasts` that is exposed as a query - which is build from the `GetForecasts` method.

```
private readonly IWeatherForecastService _weatherForecastService;

public WeatherForecastQuery(IWeatherForecastService weatherForecastService)
{
    _weatherForecastService = weatherForecastService;
}

public List<WeatherForecast> WeatherForecasts => _weatherForecastService.GetForecasts();
```

#### Add Services + Map Endpoints

Then it is as simple as mapping the queries in the `startup`/`project.cs` as part of the Services defined in the builder.

```
builder.Services
    .AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
    .AddTypeExtension<WeatherForecastQuery>();
```

Finally, you just need to map GraphQL in the same area on the app itself;

```
app.MapGraphQL();
```

And that is it! You can define a custom root/schema but this is the basic building blocks to build up a request - which can be queried, paginated and defined in terms of the schema from the consumer _without_ adding any extra code to achieve that.

### Looking at your API

For this project, when running it, it will automatically open up the swagger docs locally. To see your GraphQL queries and to access the `Banana Cake Pop` UI in the browser, locally, you can navigate to: [Local Host](https://localhost:44370/graphql/)

#### Browse Schema

Once you have this loaded, you can click on `Browse schema` to view the exposed Schemas. In this project's case, that would be the `WeatherForecasts` query that we created earlier.

<img src="https://raw.githubusercontent.com/svbygoibear/graphql-test-app/master/img/banana-cake-pop-landing-page.PNG" alt="banana-cake-pop-landing-page.PNG" width="250">

#### Sample Query

Now you're able to see all the queries and execute operations against them, in this example I am using the `weatherForecasts` query - but instead of returning the whole schema, I ask to return only 2 properties of the object;

<img src="https://raw.githubusercontent.com/svbygoibear/graphql-test-app/master/img/banana-cake-pop-sample-query.PNG" alt="banana-cake-pop-sample-query.PNG" width="250">

## Other Areas

The majority of the focus in this project is on the API side of things, but you can use GraphQL with Entity Framework to build from `queries` that are pre-defined.

### Pagination

This is something that you get out of the box with `GraphQL` (the impact on Entity is something that I still need to look into), but it does give you an easy way to achieve pagination without adding any additional logic. [Pagination GraphQL](https://graphql.org/learn/pagination/)

### Entity Framework

You can use EF by working with the `DbContext`, but you need to ensure that resolvers do not access the same scoped `DbContext` instance in parallel, which in turn means that you have to inject it using `ServiceKind.Synchronized`. As part of a future extension on this project, we'll include examples of this.

- [GraphQL Entity Framework](https://chillicream.com/docs/hotchocolate/integrations/entity-framework)

### React and GraphQL

The easiest ways to fetch data in React from GraphQL is to make use of a GraphQL compatible client. One such example is [Apollo Client](https://www.apollographql.com/). Not only can you use it to fetch remote data with GraphQL, but it allows us to manage data locally, both through an internal cache as well as an entire state management API.

You do not need to use a client either, it is possible to define this manually in just plain React, but it does make it easier. For more info on different libraries and frameworks that can be used, have a look here:

- [5 Ways to Fetch Data: React-GraphQL](https://www.freecodecamp.org/news/5-ways-to-fetch-data-react-graphql/)
