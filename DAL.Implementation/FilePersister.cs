using System;
using System.Xml.Linq;
using System.IO;

namespace DAL.Implementation
{
    public class FilePersister
    {
        private readonly string path;

        public FilePersister(string path)
        {
            this.path = path;
        }

        public void Save(XDocument source)
        {
            using FileStream stream = new FileStream(path, FileMode.Create);
            source.Save(stream);
        }
    }
}
