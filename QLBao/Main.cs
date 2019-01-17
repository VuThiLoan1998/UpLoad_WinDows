using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBao
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void loạiBáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (kiemtra("FormBao") == false)
            {
                Form1 frm = new Form1();
                frm.Name = "FormBao";
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private bool kiemtra(string Name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name.Equals(Name))
                {
                    frm.Activate();
                    return true;
                }
            }
            return false;
        }

        private void báoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
