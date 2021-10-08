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

namespace LoginView
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QRDKHOV;Initial Catalog=Royal;Integrated Security=True");
        string g;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(checkMale.Checked == true)
            {
                g = "male";
            }
            else
            {
                g = "female";
            }

            con.Open();
            string q = "insert into student (regNo,firstName,lastName,dateOfBirth,gender,address,email,mobilePhone,homePhone,parentName,nic,contacNo) values (" + cmbRegNo.SelectedItem + ",'" + txtFirstName.Text + "','" + txtLastName.Text + "','" + dateTimePicker.Text + "','" + g + "','" + txtAddress.Text + "','" + txtEmail.Text + "','" + txtMobilePhone.Text + "', '" + txtHomePhone.Text + "','" + txtParentName.Text + "','" + txtNIC.Text + "','" + txtContctNumber.Text + "')";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Added Succesfully","Alert",MessageBoxButtons.OK,MessageBoxIcon.Information);
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                {
                    if (control is TextBox)
                    {
                        (control as TextBox).Clear();
                    }
                    else
                    {
                        func(control.Controls);
                    }
                }
            };
            func(Controls);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure, Do you really went to LogOut..?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Application.Exit();
        }
    }
}
