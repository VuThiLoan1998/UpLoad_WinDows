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
    public partial class Form1 : Form
    {
        QLBaoDBDataContext db = new QLBaoDBDataContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TreeNode n = new TreeNode();
            n.Text = "Danh Mục Báo";
            List<LoaiBao> lst = db.LoaiBaos.ToList();
            foreach (LoaiBao n1 in lst)
            {
                TreeNode node = new TreeNode();
                node.Text =n1.TenLoai;
                node.Tag = n1.MaLoai;
                n.Nodes.Add(node);
            }
            treeView1.Nodes.Add(n);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView1.Items.Clear();
            string ma = (string)treeView1.SelectedNode.Tag;
            List<Bao> lstb = db.Baos.Where(m=>m.MaLoai==ma).ToList();
            foreach (var item in lstb)
            {
                ListViewItem it = new ListViewItem();
                it.Text = item.MaBao;
                it.SubItems.Add(item.TenBao);
                it.SubItems.Add(item.SoLuongBaoTrongQuy.ToString());
                it.SubItems.Add(item.DonGia.ToString());
                listView1.Items.Add(it);


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Xóa
            string ma = (string)listView1.SelectedItems[0].Text;
            List<Bao> lstb = db.Baos.Where(m => m.MaBao == ma).ToList();

            if (lstb.Count() > 0)
            {
                db.Baos.DeleteOnSubmit(lstb.First());
                db.SubmitChanges();
                MessageBox.Show("Xóa Thành Công!", "Thông Báo.");
                Load_ListView();
            }
        }

        private void Load_ListView()
        {
            listView1.Items.Clear();
            string ma = (string)treeView1.SelectedNode.Tag;
            List<Bao> lstb = db.Baos.Where(m => m.MaLoai == ma).ToList();
            foreach (var item in lstb)
            {
                ListViewItem it = new ListViewItem();
                it.Text = item.MaBao;
                it.SubItems.Add(item.TenBao);
                it.SubItems.Add(item.SoLuongBaoTrongQuy.ToString());
                it.SubItems.Add(item.DonGia.ToString());
                listView1.Items.Add(it);
            }
        }
    }
}
