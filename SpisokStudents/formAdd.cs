using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace SpisokStudents
{
    public partial class formAdd : Form
    {
        MySqlConnection conMy;
        BDConnection con;
        DataSet ds;
        MySqlDataAdapter adapter;
        MySqlCommandBuilder cmb;
        DataTable dt;

        public formAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new BDConnection("Students", "127.0.0.1", "3306", "root", "");
            con.OpenConnection();
            conMy = con.returnCell();
            ds = new DataSet();
            adapter = new MySqlDataAdapter("INSERT INTO students.students(data, name, surname, otch) " +
                                           "VALUES(" + "'" + DateTime.Now.ToShortDateString() + "'" + ", " + "'" + textName.Text.ToString() + "'" + ", " + "'" +textSurname.Text.ToString() + "'" + ", " + "'" + textOtch.Text.ToString() + "'" + ")", conMy);
            adapter.Fill(ds);
            ds.Tables.Clear();
            con.CloseConnection();
            Spisok spisok = new Spisok();
            spisok.UpdateTable();
        }

        private void formAdd_Load(object sender, EventArgs e)
        {
            
        }
    }
}
