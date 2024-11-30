using System;
using System.Windows.Forms;

namespace lab_03
{
    public partial class Form2 : Form
    {
        // Thuộc tính dùng để lưu thông tin của người cần sửa
        public Person PersonToEdit { get; set; }

        // Thuộc tính dùng để lưu thông tin của người sau khi sửa
        public Person EditedPerson { get; set; }

        // Thuộc tính trả về thông tin người sau khi thêm
        public Person NewPerson { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (PersonToEdit != null)
            {
                // Khi mở Form2, nếu có PersonToEdit, thì điền dữ liệu vào các TextBox
                txt_id.Text = PersonToEdit.ID;
                txt_name.Text = PersonToEdit.Name;
                txt_age.Text = PersonToEdit.Age.ToString();
            }
        }

        // Sự kiện khi nhấn nút "Đồng ý"
        private void btn_dongy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_id.Text) || string.IsNullOrEmpty(txt_name.Text) || string.IsNullOrEmpty(txt_age.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu đang sửa người
            if (PersonToEdit != null)
            {
                // Lưu thông tin đã sửa vào đối tượng Person
                EditedPerson = new Person
                {
                    ID = txt_id.Text,
                    Name = txt_name.Text,
                    Age = int.Parse(txt_age.Text)
                };

                DialogResult = DialogResult.OK;  // Đóng Form2 và trả về kết quả OK
                this.Close();  // Đóng Form2
            }
            else
            {
                // Nếu không phải sửa mà thêm người mới
                NewPerson = new Person
                {
                    ID = txt_id.Text,
                    Name = txt_name.Text,
                    Age = int.Parse(txt_age.Text)
                };

                DialogResult = DialogResult.OK;  // Đóng Form2 và trả về kết quả OK
                this.Close();  // Đóng Form2
            }
        }

        // Sự kiện khi nhấn nút "Thoát"
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();  // Đóng Form2 mà không làm gì
        }
    }
}
