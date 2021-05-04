using System.Collections.Generic;
using System.IO;
using System.Reflection;
namespace CannotHeroEditor
{
    public class DirsReader
    {
        private string _dirsFolder;
        public List<(string, string)> files;
        public DirsReader()
        {
            files = new();
            _dirsFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Dirs";
            if (Directory.Exists(_dirsFolder))
                if (ContainsSave(out var path, Directory.GetFiles(_dirsFolder), "Dirs.txt"))
                    LoadFiles(path);
        }
        public string Find(string value)
        {
            foreach(var file in files)
            {
                if (file.Item1.Equals(value))
                    return file.Item2;
            }
            return null;
        }
        private void LoadFiles(string path)
        {
            string[] data = File.ReadAllText(path).Split("\n");
            foreach (var raw in data)
            {
                var dataInput = raw.Split();
                files.Add((dataInput[0], dataInput[1]));
            }
        }
        private bool ContainsSave(out string param, string[] filesInDir, string saveName)
        {
            param = null;
            foreach (var fullFileName in filesInDir)
            {
                int fileNameLenght = fullFileName.Length - _dirsFolder.Length - 1;
                var fileName = fullFileName.Substring(_dirsFolder.Length + 1, fileNameLenght);
                if (fileName.Equals(saveName))
                {
                    param = fullFileName;
                    return true;
                }
            }
            return false;
        }
    }
}
