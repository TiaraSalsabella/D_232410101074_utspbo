using D_232410101074_utspbo.App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winform_mvc.App.Context;
using winform_mvc.App.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace winform_mvc.Views
{
    public partial class AddAdminForm : Form
    {
        public bool IsEditMode { get; set; } = false;
        public int AdminId { get; set; }

        public AddAdminForm()
        {
            InitializeComponent();
            UpdateButtonText();
            LoadProdiData();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Inputan tidak valid");
                return;
            }

            M_Admin Admin = new M_Admin
            {
                nama = textBox1.Text,
                username = textBox2.Text,
                password = textBox3.Text,
                nama_buku = int.Parse(textBox4.Text),
                id_buku = (int)comboBox1.SelectedValue,
            };

            if (IsEditMode)
            {
                Admin.id = AdminId;
                AdminContext.UpdateAdmin(Admin);
                MessageBox.Show("Admin berhasil diupdate");
            }
            else
            {
                AdminContext.AddAdmin(Admin);
                MessageBox.Show("Admin baru berhasil ditambahkan");
            }

            ClearFields();

            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void LoadProdiData()
        {
            DataTable dataProdi = ProdiContext.All();
            comboBox1.DisplayMember = "nama_prodi";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = dataProdi;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
            string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                !int.TryParse(textBox4.Text, out _))
            {
                return false;
            }
            return true;
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        public void PopulateForm(M_Admin Admin)
        {
            LoadProdiData();

            textBox1.Text = Admin.nama;
            textBox2.Text = Admin.nim;
            textBox3.Text = Admin.email;
            textBox4.Text = Admin.semester.ToString();
            comboBox1.SelectedValue = Admin.id_prodi;
            IsEditMode = true;
            AdminId = Admin.id;
            UpdateButtonText();
        }

        private void UpdateButtonText()
        {
            buttonAdd.Text = IsEditMode ? "Update" : "Add";
        }
    }
}
