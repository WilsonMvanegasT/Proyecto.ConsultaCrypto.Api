using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Proyecto.ConsultaCrypto.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Proyecto.ConsultaCrypto.BL.Interfaces;
using Proyecto.ConsultaCrypto.BL;
using Proyecto.ConsultaCrypto.Entities.Tickers;
using Proyecto.ConsultaCrypto.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Construcción de la aplicación
// Configuración del archivo de configuración
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Obtiene el entorno del archivo de configuración
var environment = builder.Configuration.GetSection("EnvironmentVariables")["Environment"];

// Configuración de Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = $"Minimal API with NET 8 - CryptoCurrency API  - {environment}", Version = "v1" });
});

// Configuración del servicio de explorador de API Endpoints
builder.Services.AddEndpointsApiExplorer();

// Registro de servicios
builder.Services.AddTransient<IResponseCrypto, ResponseCrypto>();
builder.Services.AddControllers();
var app = builder.Build();
app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();

app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:4200", "*.*") // Reemplaza con tu origen específico
           .AllowAnyMethod()
           .AllowAnyHeader();
         //  .AllowAnyOrigin();
});

// Definir endpoints
app.MapGet("/api/ConsultasCryptos/Tickers", () => "Obtener datos de Tickers");


//app.UseAuthorization();

//app.MapControllers();


// Uso de Swagger
app.UseSwagger();

// Configuración de las rutas de la aplicación
app.MapGet("/", () => "WELCOME TO MINIMAL API NET 8 SOFTWARE ARCHITECTURE - PLEASE ADD IN YOUR BROWSER :  /swagger/index.html")
    .ExcludeFromDescription();

//Consulta de las primeras 100 criptomonedas
app.MapPost("api/ConsultasCryptos/Tickers",
async () =>
{
    var appSetting = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();
    Ticker listticker = new Ticker();

    try
    {
        ResponseCrypto responseCrypto = new ResponseCrypto();
        listticker = await responseCrypto.ConsultarCryptos();

        return Results.Ok(listticker);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

//Consulta de las criptomonedas por id separado por ","
app.MapPost("api/ConsultarTicker/IdTicker",
async (string id) =>
{
    var appSetting = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();
    object listticker = new object();

    try
    {
        ResponseCrypto responseCrypto = new ResponseCrypto();
        listticker = await responseCrypto.ConsultarSpecificCryptoData(id);

        return Results.Ok(listticker);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

// Uso de Swagger UI
app.UseSwaggerUI();
// Ejecución de la aplicación
app.Run();

public partial class Program { }
