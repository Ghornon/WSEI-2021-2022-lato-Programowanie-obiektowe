using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace lab_4
{
    class File
    {
        private string name, path, extension;
        private long size;
        public string Name { get => name; }
        public string Path { get => path; }
        public string Size { get => SizeSuffix(size); }
        public string Extension { get => extension; }
        public File(string path, long size)
        {
            this.path = path;
            this.size = size;
            this.name = path.Split('\\').Last();
            this.extension = this.name.Split('.').Last();
        }

        static readonly string[] SizeSuffixes =
                  { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        static string SizeSuffix(long value)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }

            int i = 0;
            decimal dValue = (decimal)value;
            while (Math.Round(dValue / 1024) >= 1)
            {
                dValue /= 1024;
                i++;
            }

            return string.Format("{0:n1} {1}", dValue, SizeSuffixes[i]);
        }
    }

    class FileReader
    {
        public List<File> FilesList = new List<File>();

        public FileReader(string path = ".")
        {
            foreach (string file in Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories))
            {
                long length = new FileInfo(file).Length;
                FilesList.Add(new File(file, length));
            }

            foreach (var file in FilesList)
            {
                Console.WriteLine($"{file.Name} {file.Path} {file.Size} {file.Extension}");
            }
        }
    }
}
