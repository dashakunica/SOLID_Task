using System;
using System.Collections.Generic;
using DAL.Contract;
using System.IO;

namespace DAL.Implementation
{
    public class FileProvider : IProvider<string>
    {
        private readonly string filePath;

        public FileProvider(string path)
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
