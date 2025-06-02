using ApnaBook.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.AddInfrastructureServices();
builder.Services.AddWebServices();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

await app.InitialiseDatabaseAsync();

app.UseOpenApi();

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseSwaggerUi(); // UseSwaggerUI Protected by if (env.IsDevelopment())
app.UseExceptionHandler(options => { });

app.MapFallbackToFile("index.html");


app.Map("/", () => Results.Redirect("/api"));

app.MapEndpoints();

app.Run();

public partial class Program { }
