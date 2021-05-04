using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CannotHeroEditor
{
    public partial class Form1 : Form
    {
        private DirsReader _dirsReader;
        public Form1()
        {
            InitializeComponent();
            _dirsReader = new DirsReader();
        }
    }
}
