using Microsoft.Extensions.Configuration;
using System;

namespace Proyecto.ConsultaCrypto.Utility
{
    public static class GetAppsettings
    {

        public static string GetVarDataBase(string dataBase)
        {

            ConfigurationBuilder builder = new ConfigurationBuilder();
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            builder.AddJsonFile($"appsettings.{env}.json", optional: true);

            IConfigurationRoot configuration = builder.Build();
            string connectionString = configuration.GetConnectionString(dataBase);
            return connectionString;

        }

    }
}
