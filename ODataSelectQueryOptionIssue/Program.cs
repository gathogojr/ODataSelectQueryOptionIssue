using ODataSelectQueryOptionIssue.Data;
using ODataSelectQueryOptionIssue.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Machine>("Machines");

var contentRoot = builder.Configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
var connectionString = $"Server=(localdb)\\MSSQLLocalDB;AttachDBFilename={contentRoot}Data\\ProjectDb.mdf;Integrated Security=True;TrustServerCertificate=True;";

builder.Services.AddDbContext<ProjectDbContext>(
    options => options.UseSqlServer(connectionString));
builder.Services.AddControllers().AddOData(
    options => options.EnableQueryFeatures().AddRouteComponents(
        model: modelBuilder.GetEdmModel()));

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
