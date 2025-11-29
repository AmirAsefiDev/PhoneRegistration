using ElmahCore;
using ElmahCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PhoneRegistration.Application;
using PhoneRegistration.Infrastructure;
using PhoneRegistration.Persistence;
using PhoneRegistration.Persistence.Context;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigins",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<PhoneRegistrationDbContext>(option =>
        option.UseSqlServer(builder.Configuration["ConnectionStrings:MainConnection"]));

builder.Services.ConfigurePersistenceServices();
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructureServices();

builder.Services.AddElmah<XmlFileErrorLog>(options =>
{
    options.LogPath = Path.Combine(builder.Environment.ContentRootPath, "logs/elmah");
});
//builder.Logging.ClearProviders();

builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddSwaggerGen(s =>
{
    s.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "PhoneRegistration.Api.xml"), true);
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PhoneRegistration.Api",
        Version = "v1"
    });
});

// config Serilog
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.Seq("http://localhost:5341") //SEQ Address
    .CreateLogger();

//replace default ASP.NET Core logger with Serilog
builder.Host.UseSerilog((ctx, lc) =>
    lc.ReadFrom.Configuration(ctx.Configuration));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

app.UseHttpsRedirection();
//Using Routing for forward Requests
app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI
(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhoneRegistration API");
    c.RoutePrefix = "swagger"; //Show Swagger in route domain
});

app.UseElmah();

//Applying CORS policy
app.UseCors("AllowOrigins");
app.UseAuthentication();
app.UseAuthorization();
// Configure the HTTP request pipeline.

app.MapControllers(); //API
app.MapRazorPages(); //Razor Pages
app.MapControllerRoute( //MVC
    "default",
    "{controller=PhoneNumbersMvc}/{action=Create}/{id?}");

app.Run();