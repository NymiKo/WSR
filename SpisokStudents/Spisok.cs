using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SpisokStudents
{
    public partial class Spisok : Form
    {
        MySqlConnection conMy;
        BDConnection con;
        DataSet ds;
        MySqlDataAdapter adapter;
        MySqlCommandBuilder cmb;
        DataTable dt;

        public Spisok()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            formAdd Add = new formAdd();
            Add.Show();
        }

        private void Spisok_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void UpdateTable()
        {
            con = new BDConnection("Students", "127.0.0.1", "3306", "root", "");
            con.OpenConnection();
            conMy = con.returnCell();
            ds = new DataSet();
            adapter = new MySqlDataAdapter("SELECT * FROM students", conMy);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            ds.Tables.Clear();
            con.CloseConnection();
        }

        private void Spisok_Load(object sender, EventArgs e)
        {
            UpdateTable();
            dataGridView1.Columns[0].HeaderText = "Номер Студента";
            dataGridView1.Columns[1].HeaderText = "Дата добавления";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Фамилия";
            dataGridView1.Columns[4].HeaderText = "Отчество";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                con = new BDConnection("Students", "127.0.0.1", "3306", "root", "");
                con.OpenConnection();
                conMy = con.returnCell();
                ds = new DataSet();
                adapter = new MySqlDataAdapter("DELETE FROM students WHERE idStudents=" + textNumberDel.Text.ToString(), conMy);
                adapter.Fill(ds);
                ds.Tables.Clear();
                con.CloseConnection();
                UpdateTable();
                textNumberDel.Text = "";
            }
            catch
            {

                MessageBox.Show("Введите номер строки, которую необходимо удалить!", "Ошибка!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }
    }
}
