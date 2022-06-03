using graphql_test_app.hotchocolate.IService;
using graphql_test_app.hotchocolate.Models;
using graphql_test_app.hotchocolate.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Adds GraphQL Queries
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

// Add a custom scoped service.
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<Query>();
//builder.Services.AddGraphQL(p => SchemaBuilder.New().AddServices(p)
//    .AddType<WeatherForecast>()
//    .AddQueryType<Query>()
//    .Create()
//);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGraphQL();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
