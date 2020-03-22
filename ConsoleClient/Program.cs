using System;
using DepensyInjection;
using Bll.Contract;

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
