using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lab_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("name", "Name");
            dataGridView1.Columns.Add("age", "Age");

            // Thêm một số người mẫu vào DataGridView
            List<Person> people = new List<Person>
            {
                new Person { ID = "1", Name = "Nguyen Van A", Age = 20 },
                new Person { ID = "2", Name = "Tran Thi B", Age = 22 },
                new Person { ID = "3", Name = "Le Van C", Age = 25 }
            };

            foreach (var person in people)
            {
                dataGridView1.Rows.Add(person.ID, person.Name, person.Age);
            }
        }

        // Sự kiện khi nhấn nút Thêm
        private void btn_them_Click(object sender, EventArgs e)
        {
            // Tạo và mở Form2
            Form2 form2 = new Form2();
            form2.ShowDialog();  // Mở Form2 dưới dạng hộp thoại

            // Khi Form2 đóng lại, bạn có thể thêm dữ liệu vào DataGridView nếu có dữ liệu mới
            if (form2.NewPerson != null)  // Nếu Form2 trả về một Person hợp lệ
            {
                dataGridView1.Rows.Add(form2.NewPerson.ID, form2.NewPerson.Name, form2.NewPerson.Age);
            }
        }

        // Sự kiện khi nhấn nút Sửa
        private void btn_sua_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có dòng nào được chọn
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy dữ liệu từ dòng đã chọn
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Tạo đối tượng Person từ dữ liệu dòng được chọn
                Person selectedPerson = new Person
                {
                    ID = selectedRow.Cells["id"].Value.ToString(),
                    Name = selectedRow.Cells["name"].Value.ToString(),
                    Age = int.Parse(selectedRow.Cells["age"].Value.ToString())
                };

                // Tạo và mở Form2 với dữ liệu người cần sửa
                Form2 form2 = new Form2
                {
                    PersonToEdit = selectedPerson  // Chuyển thông tin người cần sửa vào Form2
                };

                // Mở Form2 dưới dạng hộp thoại
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    // Nếu Form2 trả về thông tin đã sửa
                    if (form2.EditedPerson != null)
                    {
                        // Cập nhật lại dữ liệu trong DataGridView với thông tin mới
                        selectedRow.Cells["id"].Value = form2.EditedPerson.ID;
                        selectedRow.Cells["name"].Value = form2.EditedPerson.Name;
                        selectedRow.Cells["age"].Value = form2.EditedPerson.Age;
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Sự kiện khi nhấn nút Xóa
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.Remove(row);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    // Lớp Person dùng để lưu trữ thông tin người
    public class Person
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
