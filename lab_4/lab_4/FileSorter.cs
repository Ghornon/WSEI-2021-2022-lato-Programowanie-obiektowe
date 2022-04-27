using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    class FileSorter
    {
        public List<Dir> DirsList = new List<Dir>();
        public List<File> FilesList = new List<File>();

        public FileSorter(List<File> FilesList, List<Dir> DirsList)
        {
            this.DirsList = DirsList;
            this.FilesList = FilesList;
        }

        public string GetNodes()
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

        public override string ToString()
        {
            return GetNodes();
        }
    }
}
