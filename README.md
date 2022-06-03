<h1 align="center">
  <a href="https://raw.githubusercontent.com/svbygoibear/graphql-test-app/master/img/header-img.png"><img src="https://raw.githubusercontent.com/svbygoibear/graphql-test-app/master/img/header-img.png" alt="graphql-test-app" width="250"></a>
  <br>
  getting graph-ty with GraphQL in C#
  <br>
</h1>

<h4 align="center">A sample of how GraphQL can be used in C# to make APIs and retrieving data simpler</h4>
<br>
<br>

# Introduction

Ah yes, the age old battle... REST VS [GraphQL](https://graphql.org/)! Well, to be honest, both have their place. Currently, one glaring issue with REST APIs if if you have to retrieve multiple sets of complex data from various entities, this means that more often than not you either have to call multiple endpoints, or you create a monstrosity of an endpoint to return the specific data needed in that case.

Either you sit with a whole bunch of round-trips to retrieve data, or you create a specialized endpoint which in a bigger team can sometimes be mutated/changed to the point of being inefficient for its original use. [GraphQL](https://graphql.org/) attempts to solve this problem by eliminating over-fetching data from the API and gives a simpler way of nesting objects in queries.

More info can be found at this [Introduction to GraphQL](https://youtu.be/anW5Qpuh5kI) video.

## What is GraphQL?

If you thought I was not going to copy-and-paste some stuff here, then you were wrong! [GraphQL](https://graphql.org/) is a query language for APIs and a runtime for fulfilling those queries with your existing data. GraphQL provides a complete and understandable description of the data in your API, gives clients the power to ask for exactly what they need and nothing more, makes it easier to evolve APIs over time, and enables powerful developer tools.

## Why use GraphQL?

[GraphQL](https://graphql.org/) allows making multiple resources request in a single query call, which saves a lot of time and bandwidth by reducing the number of network round trips to the server. It also helps to save waterfall network requests, where you need to resolve dependent resources on previous requests.

## Pros and Cons

### Pros

- Strongly-typed Schema
- No Over-Fetching or Under-Fetching
- Saves Time and Bandwidth
- Schema Stitching for Combining Schemas
- Versioning Is Not Required
- Transform Fields and Resolve With Required Shape

### Cons

- GraphQL Rate Limiting is hard to specify
- GraphQL Caching is Complicated
- GraphQL Query Complexity

## Setting up

TBA

## More reading

[Why and when to use GraphQL](https://dzone.com/articles/why-and-when-to-use-graphql-1)
[You Don't Need GraphQL](https://dzone.com/articles/you-dont-need-graphql)
