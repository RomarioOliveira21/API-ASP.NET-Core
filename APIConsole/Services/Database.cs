


using Microsoft.Extensions.Configuration;

namespace APIConsole.Services
{
    public class Database
    {

        public static string? GetConnectionString()
        {
            // Configuração da leitura do appsettings.json
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string? connectionString = configuration.GetConnectionString("DefaultConnection");

            // Acesso à connection string
            return connectionString;
        }
    }
}
