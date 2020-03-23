using System;
using DepensyInjection;
using Bll.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = Startup.Configure().GetService<IDataManager>();
            service.Run();
        }
    }
}
