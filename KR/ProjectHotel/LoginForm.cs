using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.IO;

namespace ProjectHotel
{
    public partial class LoginForm : Form
    {
        public static string akunid, username, password, sandi, nama, jenisakun;
        private readonly MaterialSkinManager materialSkinManager;
        public LoginForm()
        {
            InitializeComponent();

            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme
                (
                Primary.LightBlue800,
                Primary.LightBlue800,
                Primary.LightBlue800,
                Accent.LightBlue200,
                TextShade.WHITE
                );
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Login Lewat Button
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            username = materialSingleLineTextField1.Text;
            sandi = EncryptPassword(materialSingleLineTextField2.Text);

            errorProvider1.Clear();
            if (username.Trim().Length != 0)
            {
                FileStream fs = new FileStream("Akun.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string line = sr.ReadLine();
                string[] dataakun;
                int flag = 0;
                while (line != null)
                {
                    dataakun = line.Split('#');
                    if (dataakun[8] == username && dataakun[9] == sandi)
                    {
                        flag = 1;
                        akunid = dataakun[0];
                        LoginForm.nama = dataakun[1];
                        LoginForm.jenisakun = dataakun[11];
                        if (dataakun[10] == "Active")
                        {
                            MessageBox.Show("Welcome," + " " + LoginForm.nama, "LOGIN SUCCESS!");
                            if ("Receptionist" == LoginForm.jenisakun)
                            {
                                this.Hide();
                                var hm = new Home();
                                hm.Closed += (s, args) => this.Close();
                                hm.Show();
                            }
                            if ("Hotel Technicians" == LoginForm.jenisakun)
                            {
                                this.Hide();
                                var tec = new Technic();
                                tec.Closed += (s, args) => this.Close();
                                tec.Show();
                            }
                            if ("Administrator" == LoginForm.jenisakun)
                            {
                                this.Hide();
                                var ad = new Admin();
                                ad.Closed += (s, args) => this.Close();
                                ad.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Account Not Active", "LOGIN FAILED! ");
                            materialSingleLineTextField1.Text = "";
                            materialSingleLineTextField2.Text = "";
                            materialSingleLineTextField1.Focus();
                        }
                    }
                    else
                    {

                    }
                    line = sr.ReadLine();
                }

                sr.Close();
                fs.Close();
                if (flag == 0)
                {
                    MessageBox.Show("Wrong Username or Password", "LOGIN FAILED! ");
                    materialSingleLineTextField1.Text = "";
                    materialSingleLineTextField2.Text = "";
                    materialSingleLineTextField1.Focus();
                }
            }
            else
            {
                errorProvider1.SetError(materialSingleLineTextField1, "Enter your username!");
            }
        }
        private int showpassword;

        //Untuk Hide/Show Password
        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            showpassword++;
            if (showpassword > 1) showpassword = 0;
            switch (showpassword)
            {
                case 0:
                    materialSingleLineTextField2.UseSystemPasswordChar = true;
                    break;
                case 1:
                    materialSingleLineTextField2.UseSystemPasswordChar = false;
                    break;
            }
        }

        //Encrypt Password
        private string EncryptPassword(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                sandi = Convert.ToBase64String(encData_byte);
                return sandi;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Read Password" + ex.Message);
            }
        }

        //Login Pake Enter
        private void loginenter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        //Ngambil Perintah Login
        private void login()
        {
            username = materialSingleLineTextField1.Text;
            sandi = EncryptPassword(materialSingleLineTextField2.Text);

            errorProvider1.Clear();
            if (username.Trim().Length != 0)
            {
                FileStream fs = new FileStream("Akun.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string line = sr.ReadLine();
                string[] dataakun;
                int flag = 0;
                while (line != null)
                {
                    dataakun = line.Split('#');
                    if (dataakun[8] == username && dataakun[9] == sandi)
                    {
                        flag = 1;
                        akunid = dataakun[0];
                        LoginForm.nama = dataakun[1];
                        LoginForm.jenisakun = dataakun[11];
                        if (dataakun[10] == "Active")
                        {
                            MessageBox.Show("Welcome," + " " + LoginForm.nama, "LOGIN SUCCESS!");
                            if ("Receptionist" == LoginForm.jenisakun)
                            {
                                this.Hide();
                                var hm = new Home();
                                hm.Closed += (s, args) => this.Close();
                                hm.Show();
                            }
                            if ("Hotel Technicians" == LoginForm.jenisakun)
                            {
                                this.Hide();
                                var tec = new Technic();
                                tec.Closed += (s, args) => this.Close();
                                tec.Show();
                            }
                            if ("Administrator" == LoginForm.jenisakun)
                            {
                                this.Hide();
                                var ad = new Admin();
                                ad.Closed += (s, args) => this.Close();
                                ad.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Account Not Active", "LOGIN FAILED! ");
                            materialSingleLineTextField1.Text = "";
                            materialSingleLineTextField2.Text = "";
                            materialSingleLineTextField1.Focus();
                        }
                    }
                    else
                    {

                    }
                    line = sr.ReadLine();
                }

                sr.Close();
                fs.Close();
                if (flag == 0)
                {
                    MessageBox.Show("Wrong Username or Password", "LOGIN FAILED! ");
                    materialSingleLineTextField1.Text = "";
                    materialSingleLineTextField2.Text = "";
                    materialSingleLineTextField1.Focus();
                }
            }
            else
            {
                errorProvider1.SetError(materialSingleLineTextField1, "Enter your username!");
            }
        }
    }
}
