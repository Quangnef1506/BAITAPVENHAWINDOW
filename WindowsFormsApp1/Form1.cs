using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//do ngoc quang 2280602537 
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtLN.Text) &&
                !string.IsNullOrWhiteSpace(txtFN.Text) &&
                !string.IsNullOrWhiteSpace(txtP.Text))
            {
                ListViewItem item = new ListViewItem(txtLN.Text);
                item.SubItems.Add(txtFN.Text);
                item.SubItems.Add(txtP.Text);
                lv.Items.Add(item);
                txtLN.Clear();
                txtFN.Clear();
                txtP.Clear();

                MessageBox.Show("Thêm thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lv.SelectedItems)
                {
                    lv.Items.Remove(item);
                }
                MessageBox.Show("Xóa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lv.SelectedItems[0];
                if (!string.IsNullOrWhiteSpace(txtLN.Text) &&
                    !string.IsNullOrWhiteSpace(txtFN.Text) &&
                    !string.IsNullOrWhiteSpace(txtP.Text))
                {
                    selectedItem.Text = txtLN.Text;
                    selectedItem.SubItems[1].Text = txtFN.Text;
                    selectedItem.SubItems[2].Text = txtP.Text;
               

                    MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
