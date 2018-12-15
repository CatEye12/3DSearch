using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DSearch
{
    public partial class AddFromFolders : UserControl
    {
        public AddFromFolders()
        {
            InitializeComponent();
        }

        private void menuBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
