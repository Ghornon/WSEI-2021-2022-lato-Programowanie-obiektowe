using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace lab_4
{
    enum FileTypes
    {
        dir,
        image,
        audio,
        video,
        document,
        other
    };
    class Dir
    {
        protected string name, path;
        protected long size;
        protected FileTypes type;
        public string Name { get => name; }
        public string Path { get => path; }
        public long Size { get => size; }
        public string SizeWithSuffix { get => SizeSuffix(size); }
        public FileTypes Type { get => type; }
        public Dir(string path, long size)
        {
            this.path = path;
            this.size = size;
            this.name = path.Split('\\').Last();
            this.type = FileTypes.dir;
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
    }
    class File : Dir
    {
        private string extension;
        public string Extension { get => extension; }
        public File(string path, long size) : base (path, size)
        {
            this.extension = this.name.Split('.').Last();
            this.type = GetFileType();
        }

        private FileTypes GetFileType()
        {
            string[] images = { "png", "webp", "jpg", "gif", "tiff" };
            string[] audio = { "ogg", "mp2" };
            string[] video = { "mkv", "mp4", "webm" };
            string[] document = { "txt", "doc", "docx", "xml", "xlmx", "pdf" };

            if (images.Contains(this.extension))
                return FileTypes.image;

            if (audio.Contains(this.extension))
                return FileTypes.audio;

            if (video.Contains(this.extension))
                return FileTypes.video;

            if (document.Contains(this.extension))
                return FileTypes.document;

            return FileTypes.other;
        }
    }

    class FileReader
    {
        public List<Dir> DirsList = new List<Dir>();
        public List<File> FilesList = new List<File>();

        public FileReader(string path = "C:\\Skany")
        {
            try
            {
                FilesList = EnumerateFiles();
                DirsList = EnumerateDirectories();
            }
            catch (UnauthorizedAccessException uAEx)
            {
                Console.WriteLine(uAEx.Message);
            }
            catch (PathTooLongException pathEx)
            {
                Console.WriteLine(pathEx.Message);
            }


            foreach (var file in FilesList)
            {
                Console.WriteLine($"{file.Name} {file.Path} {file.SizeWithSuffix} {file.Extension} {file.Type}");
            }

            foreach (var dir in DirsList)
            {
                Console.WriteLine($"{dir.Name} {dir.Path} {dir.SizeWithSuffix} {dir.Type}");
            }
        }

        private List<File> EnumerateFiles(string path = "C:\\Skany")
        {
            List<File> list = new List<File>();

            var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                long length = new FileInfo(file).Length;
                list.Add(new File(file, length));
            }

            return list;
        }

        private List<Dir> EnumerateDirectories(string path = "C:\\Skany")
        {
            List<Dir> list = new List<Dir>();

            var dirs = Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories);
            

            foreach (string dir in dirs)
            {
                long length = 0;
                var files = EnumerateFiles(dir);

                foreach (File file in files)
                {
                    length += file.Size;
                }

                list.Add(new Dir(dir, length));

            }

            return list;
        }

    }


}
