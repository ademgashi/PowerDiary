using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PowerDiary.Application;
using PowerDiary.Console;
using PowerDiary.Persistence;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var logger = host.Services.GetRequiredService<ILogger<Program>>();
logger.LogDebug("Host created.");

var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<ChatDbContext>();
    
    DbInitializer.Initialize(context);

    services.GetRequiredService<App>().Run(args);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            services.AddDbContext<ChatDbContext>();
            // add repositories
            //services.AddScoped<IChatEventRepository, ChatEventRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();
          
            // add service
            services.AddScoped<IChatHistoryService, ChatHistoryService>();


            services.AddSingleton<App>();
        });
}

