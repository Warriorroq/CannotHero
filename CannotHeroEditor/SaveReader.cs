using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
namespace CannotHeroEditor
{
    public class SaveReader
    {
        public List<(string, int)> values;
        private string _path;
        public SaveReader(string path)
        {
            _path = path;
            values = new();
            ParceFile(File.ReadAllText(_path).Split("\r\n"));
        }
        private void ParceFile(string[] file)
        {
            foreach (var raw in file)
            {
                if(raw.Length > 0 && !raw[0].Equals('<'))
                {
                    var data = raw.Split();
                    if(int.TryParse(data[1], out int value))
                        values.Add((data[0], Math.Abs(value)));
                }
            }
        }
        public void Write(List<NumericUpDown> controls)
        {
            string text = string.Empty;
            foreach (var control in controls)
            {
                text += WriteControl(control);
            }
            File.WriteAllText(_path, text);
        }
        private string WriteControl(NumericUpDown control)
        {
            using (StreamReader sr = new StreamReader(_path))
            {
                do
                {
                    var line = sr.ReadLine();
                    var data = line.Split();
                    if (data.Length == 2)
                    {
                        if(data[0].Equals(control.Name))
                        {
                            return $"{data[0]} {control.Value}" + Environment.NewLine;
                        }
                    }
                } while (sr.EndOfStream == false);
                return string.Empty;
            }
        }
        public override string ToString()
        {
            var result = string.Empty;
            foreach(var value in values)
            {
                result += value.ToString();
            }
            return result;
        }
    }
}
