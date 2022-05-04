using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    class Counter
    {
        public string Type;
        public int Count = 0;
        public long TotalSize = 0, AvgSize = 0, MinSize = 0, MaxSize =0;
        public Counter(string Type, List<File> FilesList)
        {
            this.Type = Type;

            foreach (File file in FilesList)
            {
                TotalSize += file.Size;
                if (MinSize >= file.Size || MinSize == 0)
                    MinSize = file.Size;

                if (MaxSize <= file.Size || MaxSize == 0)
                    MaxSize = file.Size;
            }

            Count = FilesList.Count;

            if (Count != 0)
                AvgSize = TotalSize / Count;
        }

        static readonly string[] SizeSuffixes = { "  ", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

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

        public override string ToString()
        {
            return $"\t\t{this.Type}\t\t{this.Count}\t\t{SizeSuffix(this.TotalSize)}\t\t{SizeSuffix(this.AvgSize)}\t\t{SizeSuffix(this.MinSize)}\t\t{SizeSuffix(this.MaxSize)}";
        }
    }
    class FileCounter
    {
        public List<Dir> DirsList = new List<Dir>();
        public List<File> FilesList = new List<File>();

        public FileCounter(List<File> FilesList, List<Dir> DirsList)
        {
            this.DirsList = DirsList;
            this.FilesList = FilesList;
        }

        private string GetNodes()
        {
            string nodes = "Nodes:\r\n\t\t\t[count]\t[total size]\r\n";
            nodes += "\tDirectories:";
            nodes += "\t" + DirsList.Count().ToString();

            long totalSize = 0;
            foreach(Dir dir in DirsList)
            {
                totalSize += dir.Size;
            }

            Dir tempDir = new Dir("temp", totalSize);

            nodes += "\t" + tempDir.SizeWithSuffix;

            nodes += "\r\n\tFiles:";
            nodes += "\t\t" + FilesList.Count().ToString();

            totalSize = 0;
            foreach (File file in FilesList)
            {
                totalSize += file.Size;
            }

            File tempFile= new File("temp", totalSize);
            nodes += "\t" + tempFile.SizeWithSuffix;

            return nodes;
        }

        public IEnumerable<Counter> GetNodesByType()
        {
            string[] types = { "image", "audio", "video", "document", "other" };

            List<Counter> results = new List<Counter>();

            foreach(string type in types)
            {
                IEnumerable<File> filteredFiles = from file in this.FilesList where file.Type.ToString() == type select file;
                results.Add(new Counter(type, filteredFiles.ToList()));
            }

            return results;
        }

        public IEnumerable<Counter> GetNodesByExtension()
        {
            string[] extensions = { "png", "webp", "jpg", "gif", "tiff", "ogg", "mp2", "mkv", "mp4", "webm", "txt", "doc", "docx", "xml", "xlmx", "pdf" };

            List<Counter> results = new List<Counter>();

            foreach (string extension in extensions)
            {
                IEnumerable<File> filteredFiles = from file in this.FilesList where file.Extension.ToString() == extension select file;
                results.Add(new Counter(extension, filteredFiles.ToList()));
            }

            return results;
        }

        public IEnumerable<Counter> GetNodesBySize()
        {
            IDictionary<string, long[]> sizes = new Dictionary<string, long[]>();
            sizes.Add("      . <= 1KB", new long[] { 0, 1024 });
            sizes.Add("1KB < . <= 1MB", new long[] { 1024, 1048576 });
            sizes.Add("1MB < . <= 1GB", new long[] { 1048576, 1073741824 });
            sizes.Add("1GB < .       ", new long[] { 1073741824, long.MaxValue });


            List<Counter> results = new List<Counter>();

            foreach(var size in sizes)
            {
                IEnumerable<File> filteredFiles = from file in this.FilesList where file.Size > size.Value[0] && file.Size <= size.Value[1] select file;
                results.Add(new Counter(size.Key, filteredFiles.ToList()));
            }

            return results;
        }

        public string GetHeadline()
        {
            return "\t\t\t\t[count]\t\t[total size]\t[avg size]\t[min size]\t[max size]";
        }

        public override string ToString()
        {
            return GetNodes();
        }
    }
}
