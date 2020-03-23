using System;
using System.Xml.Linq;
using Bll.Contract;
using System.IO;
using BLL.Implementation;
using DAL.Contract;
using DAL.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;


namespace DepensyInjection
{
    public class Startup
    {
        public static ServiceProvider Configure()
        {
            IServiceCollection services = new ServiceCollection();

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("Configuration.json");

            IConfiguration config = builder.Build();

            try
            {
                services.AddSingleton<IProvider<string>>(new FileProvider(config["InputFilePath"]));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }

            services.AddSingleton<ILogger, LogAdapter>()
                    .AddSingleton<IParser<string, Url>, Parser>()
                    .AddSingleton<IValidator<string>, Validator>()
                    .AddSingleton<IConverter<string, Urls>, StringToEntetiesConverter>()
                    .AddSingleton<IPersister<Urls>>(new FilePersister(config["OutputFilePath"]))
                    .AddSingleton<IDataManager, ManagerSaver<IEnumerable<string>, Urls>>();

            return services.BuildServiceProvider();
        }
    }
}
