using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3sdnMap
{
    public partial class formConfigur : Form
    {
        public formConfigur()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            forConfigurAdd forConfigurAdd = new forConfigurAdd();
            forConfigurAdd.Show();
        }
    }
}
