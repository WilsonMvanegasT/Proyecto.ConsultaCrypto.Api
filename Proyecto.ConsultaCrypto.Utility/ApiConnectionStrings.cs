using Microsoft.Extensions.Configuration;
using System;

namespace Proyecto.ConsultaCrypto.Utility
{
    public static class ApiConnectionStrings
    {
        static ApiConnectionStrings()
        {

        }

        public static string ConnectionStringMece_Logistico
        {
            get
            {
                var builder = new ConfigurationBuilder();
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                builder.AddJsonFile($"appsettings.{env}.json", optional: true);

                var configuration = builder.Build();
                var connectionString = configuration.GetConnectionString("base_pruebas");
                return connectionString;
            }
        }

        public static string ConnectionStringNormalizarDireccionesMDM
        {
            get
            {
                var builder = new ConfigurationBuilder();
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                builder.AddJsonFile($"appsettings.{env}.json", optional: true);

                var configuration = builder.Build();
                var connectionString = configuration.GetConnectionString("NormalizarDireccionesMDM");
                return connectionString;
            }
        }

        public static string ConnectionStringApiCrypto
        {
            get
            {
                var builder = new ConfigurationBuilder();
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                builder.AddJsonFile($"appsettings.{env}.json", optional: true);

                var configuration = builder.Build();
                var connectionString = configuration.GetConnectionString("Api_Crypto");
                return connectionString;
            }
        }

        public static string ConnectionStringMerfIngresos
        {
            get
            {
                var builder = new ConfigurationBuilder();
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                builder.AddJsonFile($"appsettings.{env}.json", optional: true);

                var configuration = builder.Build();
                var connectionString = configuration.GetConnectionString("Merf_Ingresos");
                return connectionString;
            }
        }
    }
}
