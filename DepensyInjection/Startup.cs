using System;
using System.Xml.Linq;
using Bll.Contract;
using System.IO;
using BLL.Implementation;
using DAL.Contract;
using DAL.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;


namespace DepensyInjection
{
    public class Startup
    {
        public static ServiceProvider Configure()
        {
            IServiceCollection services = new ServiceCollection();

            string inputFilePath = "input.txt";
            string outputFilePath = "output.xml";

            try
            {
                services.AddSingleton<IProvider<string>>(new FileProvider(inputFilePath));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }

            services.AddSingleton<ILogger, LogAdapter>()
                    .AddSingleton<IParser<string, Url>, Parser>()
                    .AddSingleton<IConverter<IEnumerable<string>, Urls>, ToXDocumentConverter>()
                    .AddSingleton<IPersister<Urls>>(new FilePersister(outputFilePath))
                    .AddSingleton<IDataManager, ManagerSaver<IEnumerable<string>, Urls>>();

            return services.BuildServiceProvider();
        }
    }
}
