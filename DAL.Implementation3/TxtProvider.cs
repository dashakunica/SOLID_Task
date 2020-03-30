using System;
using DAL.Contract;
using System.Collections.Generic;
using System.IO;

namespace DAL.Implementation3
{
    public class TxtProvider : IProvider<string>
    {
        private readonly string filePath;

        public TxtProvider(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            this.filePath = path;
        }

        public IEnumerable<string> GetData()
        {
            string line = null;

            using StreamReader reader = new StreamReader(filePath);
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}
