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

            IEnumerable<File> files = from file in FilesList select file;

            foreach (File file in files)
            {
                Count++;
                TotalSize += file.Size;
                if (MinSize >= file.Size || MinSize == 0)
                    MinSize = file.Size;

                if (MaxSize <= file.Size || MaxSize == 0)
                    MaxSize = file.Size;
            }

            if (Count == 0)
                throw new ArgumentOutOfRangeException();

            AvgSize = TotalSize / Count;
        }

        static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

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

        private string GetNodesBy()
        {
            string result = "\t ";



            return result;
        }

        public override string ToString()
        {
            return GetNodes();
        }
    }
}
