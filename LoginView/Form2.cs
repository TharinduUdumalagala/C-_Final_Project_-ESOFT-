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
        
        string g;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QRDKHOV;Initial Catalog=Royal;Integrated Security=True");

   
            if (checkMale.Checked == true)
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
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QRDKHOV;Initial Catalog=Royal;Integrated Security=True");

            if (checkMale.Checked == true)
            {
                g = "male";
            }
            else
            {
                g = "female";
            }

            con.Open();

            SqlCommand cmd = new SqlCommand("Update student set firstName=@firstName,lastName=@lastName,dateOfBirth=@dateOfBirth,gender=@gender,address=@address,email=@email,mobilePhone=@mobilePhone,homePhone=@homePhone,parentName=@parentName,nic=@nic,contacNo=@contacNo where regNo =@regNo", con);
            cmd.Parameters.AddWithValue("@regNo", cmbRegNo.SelectedItem);
            cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@lastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@dateOfBirth", dateTimePicker.Text);
            cmd.Parameters.AddWithValue("@gender", g);
            cmd.Parameters.AddWithValue("@address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@mobilePhone", txtMobilePhone.Text);
            cmd.Parameters.AddWithValue("@homePhone", txtHomePhone.Text);
            cmd.Parameters.AddWithValue("@parentName", txtParentName.Text);
            cmd.Parameters.AddWithValue("@nic", txtNIC.Text);
            cmd.Parameters.AddWithValue("@contacNo", txtContctNumber.Text);

            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Record Update Succesfully", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QRDKHOV;Initial Catalog=Royal;Integrated Security=True");

            con.Open();

            SqlCommand cmd = new SqlCommand("Delete student where regNo=@regNo",con);
            cmd.Parameters.AddWithValue("@regNo", cmbRegNo.SelectedItem);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Are you suer, Doyou really want to Delete this Record..?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            MessageBox.Show("Record Update Succesfully","Alert",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
