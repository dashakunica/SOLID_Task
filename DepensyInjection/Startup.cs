using System;
using System.Xml.Linq;
using Bll.Contract;
using System.IO;
using BLL.Implementaion2;
using DAL.Contract;
using DAL.Implementation2;
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
            .AddJsonFile(@"C:\Users\User\source\repos\NET.Winter.2020.Kunickaya.25\DepensyInjection\jsconfig.json");

            IConfiguration config = builder.Build();

            try
            {
                services.AddSingleton<IProvider<string>>(new TxtProvider(config["InputFilePath"]));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }

            //services.AddSingleton<ILogger, LogAdapter>()
            //        .AddSingleton<IParser<string, Url>, Parser>()
            //        .AddSingleton<IValidator<string>, Validator>()
            //        .AddSingleton<IConverter<string, UrlXML>, StringToEntetiesConverter>()
            //        .AddSingleton<IPersister<Urls>>(new FilePersister(config["OutputFilePath"]))
            //        .AddSingleton<IDataManager, ManagerSaver<IEnumerable<string>, Urls>>();

            services
                    .AddSingleton<IParser<string, TradeProcess>, Parser>()
                    .AddSingleton<IValidator<string>, Validator>()
                    .AddSingleton<IConverter<string, TradeProcess>, StringToEntetiesConverter>()
                    .AddSingleton<IPersister<TradeProcess>>(new DataBasePersister(config["OutputFilePath"]))
                    .AddSingleton<IDataManager, ManagerSaver<IEnumerable<string>, TradeProcess>>();

            return services.BuildServiceProvider();
        }
    }
}
