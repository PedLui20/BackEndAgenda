using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AppAgenda.Infraestructure.Context;

public class AgendaDbContextFactory : IDesignTimeDbContextFactory<AgendaDbContext>
{
    public AgendaDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets<AgendaDbContextFactory>()
            .Build();
        string connectionString = configuration["ConnectionStrings:localConnection"];
        Console.WriteLine(connectionString);
        if (string.IsNullOrEmpty(connectionString))
        {
            Console.WriteLine(connectionString);
            throw new ArgumentNullException(nameof(connectionString),
                "La cadena de conexión no puede ser nula ni estar vacía.");
        }

        var optionsBuilder = new DbContextOptionsBuilder<AgendaDbContext> ();
        optionsBuilder.UseSqlServer(connectionString);
        return new AgendaDbContext(optionsBuilder.Options);
    }
}