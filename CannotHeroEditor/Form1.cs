using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CannotHeroEditor
{
    public partial class Form1 : Form
    {
        private DirsReader _dirsReader;
        private SaveReader _saveReader;
        public Form1()
        {
            InitializeComponent();
            _dirsReader = new DirsReader();
            _saveReader = new SaveReader(_dirsReader.Find("Saves"));            
            foreach(var item in _saveReader.values)
            {
                NumericUpDown nums = (NumericUpDown)Controls.Find(item.Item1, true)[0];
                nums.Value = item.Item2;
            }
        }
        private void Sumbit_Click(object sender, EventArgs e)
        {
            _saveReader.Write(new List<NumericUpDown>(Controls.OfType<NumericUpDown>()));
        }
    }
}
