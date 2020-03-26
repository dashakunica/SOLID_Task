using System;
using Bll.Contract;
using DAL.Contract;

namespace BLL.Implementaion2
{
    public class ManagerSaver<TSource, TResult> : IDataManager
    {
        private readonly IConverter<TSource, TResult> converter;
        private readonly IProvider<TSource> loader;
        private readonly IPersister<TResult> saver;

        public ManagerSaver(IProvider<TSource> loader, IPersister<TResult> saver, IConverter<TSource, TResult> converter)
        {
            this.loader = loader;
            this.saver = saver;
            this.converter = converter;
        }

        public void Run()
        {
            this.saver.Save(this.converter.Convert(this.loader.GetData()));
        }
    }
}
