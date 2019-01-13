using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Text.RegularExpressions;
using System.Collections;

namespace ProjectHotel
{
    public partial class Admin : Form
    {
        //Get Material
        private readonly MaterialSkinManager materialSkinManager;

        //Data Type
        private string 
        Str, 
        kodebaru, nama, ttl, gender, warganegara, alamat, hp, email, username, status, type, quest,
        dataakun0, dataakun1, dataakun2, dataakun3, dataakun4,  dataakun5,  dataakun6,  dataakun7,  dataakun8,  dataakun9,  dataakun10,  dataakun11,  dataakun12,  dataakun13
            ;
        private int Code;
        
        public Admin()
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

        DataTable dt = new DataTable();
        ArrayList result = new ArrayList();
        private void Admin_Load(object sender, EventArgs e)
        {
            //Load Combo Box
            menucombobox();

            //Load 17 Tahun
            supaya17tahun();

            //Load Auto ID
            autoid();

            //Text Box AutoID
            materialSingleLineTextField15.Text = kodebaru;

            //Load Nama
            label3.Text = LoginForm.nama;

            //Load DataGridView
            isidtgv();
        }

        //BUAT ON/OFF LIHAT ANSWER
        private int showanswer;
        private void button2_Click(object sender, EventArgs e)
        {
            showanswer++;
            if (showanswer > 1) showanswer = 0;
            switch (showanswer)
            {
                case 0:
                    materialSingleLineTextField9.UseSystemPasswordChar = true;
                    break;
                case 1:
                    materialSingleLineTextField9.UseSystemPasswordChar = false;
                    break;
            }
        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField15_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField2_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            string akunid = materialSingleLineTextField15.Text;
            FileStream ambildata1 = new FileStream("Akun.txt", FileMode.Open, FileAccess.Read);
            StreamReader bacadata1 = new StreamReader(ambildata1);
            string linee = bacadata1.ReadLine();
            while (linee != null)
            {
                // Console.Clear();
                string[] dataakun = linee.Split('#');
                if (akunid == dataakun[0])
                {
                    dataakun0 = dataakun[0];
                    dataakun1 = dataakun[1];
                    dataakun2 = dataakun[2];
                    dataakun3 = dataakun[3];
                    dataakun4 = dataakun[4];
                    dataakun5 = dataakun[5];
                }
                else
                {
                }
                linee = bacadata1.ReadLine();
            }
            bacadata1.Close();
            ambildata1.Close();
            if (akunid == dataakun0)
            {
                string password = materialSingleLineTextField10.Text;

                //validasi email
                string vemail = materialSingleLineTextField12.Text;
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(vemail);

                //Load Data
                declaredata();

                //Load Encrypt
                string sandi = Encrypt(materialSingleLineTextField10.Text);
                string jawaban = Encrypt(materialSingleLineTextField9.Text);

                //Membersihkan Error
                errorProvider1.Clear();

                //Check Data Kosong
                if (nama.Trim().Length != 0)
                {
                    if (comboBox9.Text != "- Select Citizenship -")
                    {
                        if (alamat.Trim().Length != 0)
                        {
                            if (hp.Trim().Length != 0)
                            {
                                if (email.Trim().Length != 0)
                                {
                                    if (username.Trim().Length != 0)
                                    {
                                        if (password.Trim().Length != 0)
                                        {
                                            if (comboBox8.Text != "- Select Type -")
                                            {
                                                if (comboBox6.Text != "- Select Question -")
                                                {
                                                    if (jawaban.Trim().Length != 0)
                                                    {
                                                        if (match.Success)
                                                        {
                                                            string old = dataakun0 + "#" + dataakun1 + "#" + dataakun2 + "#" + dataakun3 + "#" + dataakun4 + "#" + dataakun5 + "#" + dataakun6 + "#" + dataakun7 + "#" + dataakun8 + "#" + dataakun9 + "#" + dataakun10 + "#" + dataakun11 + "#" + dataakun12 + "#" + dataakun13 + "#";
                                                            string neww = akunid + "#" + nama + "#" + ttl + "#" + gender + "#" + warganegara + "#" + alamat + "#" + hp + "#" + email + "#" + username + "#" + sandi + "#" + status + "#" + type + "#" + quest + "#" + jawaban + "#";
                                                            string update = File.ReadAllText("Akun.txt");
                                                            update = update.Replace(old, neww);
                                                            File.WriteAllText("Akun.txt", update);
                                                            MessageBox.Show("Account has been Updated.", "SUCCESS!");
                                                            if (LoginForm.username == username && type == "Hotel Technicians")
                                                            {
                                                                this.Hide();
                                                                var tc = new Technic();
                                                                tc.Closed += (s, args) => this.Close();
                                                                tc.Show();
                                                            }
                                                            else
                                                            {
                                                                if (LoginForm.username == username &&  type == "Receptionist")
                                                                {
                                                                    this.Hide();
                                                                    var hm = new Home();
                                                                    hm.Closed += (s, args) => this.Close();
                                                                    hm.Show();
                                                                }
                                                                else
                                                                {
                                                                    this.Hide();
                                                                    var ad = new Admin();
                                                                    ad.Closed += (s, args) => this.Close();
                                                                    ad.Show();
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            errorProvider1.SetError(materialSingleLineTextField12, "Please enter valid email!");
                                                        }

                                                    }
                                                    else
                                                    {
                                                        errorProvider1.SetError(materialSingleLineTextField9, "Must be filled!");
                                                    }
                                                }
                                                else
                                                {
                                                    errorProvider1.SetError(comboBox6, "Please select question!");
                                                }
                                            }
                                            else
                                            {
                                                errorProvider1.SetError(comboBox8, "Please select type account!");
                                            }
                                        }
                                        else
                                        {
                                            errorProvider1.SetError(materialSingleLineTextField10, "Must be filled!");
                                        }
                                    }
                                    else
                                    {
                                        errorProvider1.SetError(materialSingleLineTextField11, "Must be filled!");
                                    }
                                }
                                else
                                {
                                    errorProvider1.SetError(materialSingleLineTextField12, "Must be filled!");
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(materialSingleLineTextField13, "Must be filled!");
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(textBox2, "Must be filled!");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(comboBox9, "Please select citizenship!");
                    }
                }
                else
                {
                    errorProvider1.SetError(materialSingleLineTextField14, "Must be filled!");
                }
            }
            else
            {
                MessageBox.Show("Data not found, Try again!", "WRONG DATA!");
                materialSingleLineTextField24.Text = "";
                materialSingleLineTextField24.Focus();
            }
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            string akunid = materialSingleLineTextField15.Text;
            FileStream ambildata1 = new FileStream("Akun.txt", FileMode.Open, FileAccess.Read);
            StreamReader bacadata1 = new StreamReader(ambildata1);
            string linee = bacadata1.ReadLine();
            while (linee != null)
            {
                // Console.Clear();
                string[] dataakun = linee.Split('#');
                if (akunid == dataakun[0])
                {
                    dataakun0 = dataakun[0];
                    dataakun1 = dataakun[1];
                    dataakun2 = dataakun[2];
                    dataakun3 = dataakun[3];
                    dataakun4 = dataakun[4];
                    dataakun5 = dataakun[5];
                    username = dataakun[8];
                }
                else
                {
                }
                linee = bacadata1.ReadLine();
            }
            bacadata1.Close();
            ambildata1.Close();
            if (akunid == dataakun0)
            {
                if (LoginForm.username == username)
                {
                    MessageBox.Show("Can't delete your account", "FAILED");
                    var ad = new Admin();
                    ad.Closed += (s, args) => this.Close();
                    ad.Show();
                }
                else
                {
                    //Load Data
                    declaredata();
                    if (MessageBox.Show("Are you sure want to delete data?" + " " + dataakun1, "DELETE DATA!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string path = ("Akun.txt");
                        var oldlinelogin = File.ReadAllLines(path);
                        var newline = oldlinelogin.Where(line => !line.Contains(dataakun0 + "#"));
                        File.WriteAllLines(path, newline);
                        MessageBox.Show("Data has been deleted.", "SUCCESS!");
                        this.Hide();
                        var ad = new Admin();
                        ad.Closed += (s, args) => this.Close();
                        ad.Show();
                    }
                    else
                    {
                        this.Hide();
                        var ad = new Admin();
                        ad.Closed += (s, args) => this.Close();
                        ad.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("Data not found, Try again!", "WRONG DATA!");
                materialSingleLineTextField24.Text = "";
                materialSingleLineTextField24.Focus();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            dt.Clear();
            string sortby = comboBox1.Text;
            string filter = comboBox2.Text;

            int jml = File.ReadAllLines("Akun.txt").Count();
            string[] hasil = new string[jml];

            string[] data = result.ToArray(typeof(string)) as string[];

            if (sortby == "Name")
            {
                if (filter == "Ascending")
                {
                    BubbleSort bs = new BubbleSort();
                    hasil = bs.bubbleNameAsc(data);
                }
                else
                {
                    BubbleSort bs = new BubbleSort();
                    hasil = bs.bubbleNameDesc(data);
                }
            }

            foreach (var x in hasil)
            {
                string[] isi = x.Split('#');
                dt.Rows.Add(isi[0], isi[1], isi[2], isi[3], isi[4], isi[5], isi[6], isi[7], isi[8], isi[10], isi[11], isi[12]);
            }

            dataGridView1.DataSource = dt;
        }

        private void materialRaisedButton7_Click(object sender, EventArgs e)
        {
            dt.Clear();

            LinearSearch ls = new LinearSearch();
            result = ls.searchByName(materialSingleLineTextField1.Text);

            foreach (var x in result)
            {
                string[] isi = x.ToString().Split('#');
                dt.Rows.Add(isi[0], isi[1], isi[2], isi[3], isi[4], isi[5], isi[6],isi[7],isi[8],isi[10],isi[11],isi[12]);
            }

            dataGridView1.DataSource = dt;
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.Text == "Administrator")
            {
                //Combo Box 7
                comboBox7.SelectedIndex = 0;
                comboBox7.Enabled = false;
            }
            else
            {
                comboBox7.Enabled = true;   
            }
        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField3_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        //Buat Bersihin
        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField14.Text = "";
            dateTimePicker2.Value = DateTime.Now.AddYears(-17);
            materialRadioButton1.Checked = true;
            comboBox9.SelectedIndex = 0;
            textBox2.Text = "";
            materialSingleLineTextField13.Text = "";
            materialSingleLineTextField12.Text = "";
            materialSingleLineTextField11.Text = "";
            materialSingleLineTextField10.Text = "";
            materialSingleLineTextField9.Text = "";
            comboBox8.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
        }

        private void clear()
        {
            materialSingleLineTextField14.Text = "";
            dateTimePicker2.Value = DateTime.Now.AddYears(-17);
            materialRadioButton1.Checked = true;
            comboBox9.SelectedIndex = 0;
            textBox2.Text = "";
            materialSingleLineTextField13.Text = "";
            materialSingleLineTextField12.Text = "";
            materialSingleLineTextField11.Text = "";
            materialSingleLineTextField10.Text = "";
            materialSingleLineTextField9.Text = "";
            comboBox8.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
        }

        private void materialRaisedButton8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton10_Click(object sender, EventArgs e)
        {
            string idakun = materialSingleLineTextField24.Text;
            FileStream ambildata = new FileStream("Akun.txt", FileMode.Open, FileAccess.Read);
            StreamReader bacadata = new StreamReader(ambildata);
            string linee = bacadata.ReadLine();
            while (linee != null)
            {
                // Console.Clear();
                string[] dataakun = linee.Split('#');
                if (idakun == dataakun[0])
                {
                    dataakun0 = dataakun[0];
                    dataakun1 = dataakun[1];
                    dataakun2 = dataakun[2];
                    dataakun3 = dataakun[3];
                    dataakun4 = dataakun[4];
                    dataakun5 = dataakun[5];
                    dataakun6 = dataakun[6];
                    dataakun7 = dataakun[7];
                    dataakun8 = dataakun[8];
                    dataakun9 = dataakun[9];
                    dataakun10 = dataakun[10];
                    dataakun11 = dataakun[11];
                    dataakun12 = dataakun[12];
                    dataakun13 = dataakun[13];
                }
                else
                {
                }
                linee = bacadata.ReadLine();
            }
            bacadata.Close();
            ambildata.Close();

            if (idakun == dataakun0)
            {
                materialSingleLineTextField15.Text = dataakun0;
                materialSingleLineTextField14.Text = dataakun1;
                dateTimePicker2.Value = DateTime.Parse(dataakun2);
                if (dataakun3 == materialRadioButton1.Text)
                {
                    materialRadioButton1.Checked = true;
                }
                else
                {
                    materialRadioButton2.Checked = true;
                }
                comboBox9.Text = dataakun4;
                textBox2.Text = dataakun5;
                materialSingleLineTextField13.Text = dataakun6;
                materialSingleLineTextField12.Text = dataakun7;
                materialSingleLineTextField11.Text = dataakun8;
                materialSingleLineTextField11.Enabled = false;

                //DI DECRYPT DULU PASSNYA
                materialSingleLineTextField10.Text = Decrypt(dataakun9);


                comboBox7.Text = dataakun10;
                comboBox8.Text = dataakun11;
                comboBox6.Text = dataakun12;

                //DI DECRYPT DULU ANSWERNYA
                materialSingleLineTextField9.Text = Decrypt(dataakun13);

                if (LoginForm.username == materialSingleLineTextField11.Text)
                {
                    button1.Visible = true;
                    button2.Visible = true;
                }
                else
                {
                    button1.Visible = false;
                    button2.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Data not found, Try again!", "WRONG DATA!");
                clear();
                materialSingleLineTextField24.Text = "";
                materialSingleLineTextField24.Focus();
            }
        }

        //Button Logout
        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var lf = new LoginForm();
            lf.Closed += (s, args) => this.Close();
            lf.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        //BUAT ON/OFF LIHAT PASSWORD TEXTBOX
        private int showpassword;
        private void button1_Click(object sender, EventArgs e)
        {
            showpassword++;
            if (showpassword > 1) showpassword = 0;
            switch (showpassword)
            {
                case 0:
                    materialSingleLineTextField10.UseSystemPasswordChar = true;
                    break;
                case 1:
                    materialSingleLineTextField10.UseSystemPasswordChar = false;
                    break;
            }
        }

        //BUAT ID OTOMATIS
        public string autoid()
        {
            FileStream F = new FileStream("Akun.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(F);

            while ((Str = sr.ReadLine()) != null)
            {
                string lastLine = File.ReadLines("Akun.txt").Last();
                if (lastLine != null)
                {
                    string[] isi = lastLine.Split('#');
                    Code = Convert.ToInt32(isi[0].Substring(1, 4));
                    Code = Code + 1;
                    if (Code < 10)
                    {
                        kodebaru = "A000" + Code;
                    }
                    else if (Code >= 10 && Code < 99)
                    {
                        kodebaru = "A00" + Code;
                    }
                    else if (Code >= 100 && Code < 999)
                    {
                        kodebaru = "A0" + Code;
                    }
                    else if (Code >= 1000 && Code < 9999)
                    {
                        kodebaru = "A" + Code;
                    }
                    else
                    {
                        kodebaru = kodebaru = "full";
                    }
                    sr.Close();
                    F.Close();
                    return kodebaru;
                }
            }
            kodebaru = "A0001";
            sr.Close();
            F.Close();
            return kodebaru;
        }

        //MENU COMBO BOX
        private void menucombobox()
        {
            //Combo Box 9
            comboBox9.Items.Add("- Select Citizenship -");
            comboBox9.Items.Add("Indonesian Citizens");
            comboBox9.Items.Add("Foreign Nationals");
            comboBox9.SelectedIndex = 0;

            //Combo Box 8
            comboBox8.Items.Add("- Select Type -");
            comboBox8.Items.Add("Receptionist");
            comboBox8.Items.Add("Hotel Technicians");
            comboBox8.Items.Add("Administrator");
            comboBox8.SelectedIndex = 0;

            //Combo Box 7
            comboBox7.Items.Add("Active");
            comboBox7.Items.Add("Not Active");
            comboBox7.SelectedIndex = 0;

            //Combo Box 6
            comboBox6.Items.Add("- Select Question -");
            comboBox6.Items.Add("What is your nickname as a child?");
            comboBox6.Items.Add("What is your favorite food?");
            comboBox6.Items.Add("Which car brand do you like?");
            comboBox6.Items.Add("Who artist do you like?");
            comboBox6.Items.Add("What is your favorite activity?");
            comboBox6.SelectedIndex = 0;

            //Combo Box 1
            comboBox1.Items.Add("Name");
            comboBox1.SelectedIndex = 0;

            /*Combo Box 2*/
            comboBox2.Items.Add("Ascending");
            comboBox2.Items.Add("Descending");
            comboBox2.SelectedIndex = 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        //tanggal supaya 17tahun
        private void supaya17tahun()
        {
            dateTimePicker2.Value = DateTime.Now.AddYears(-17);
        }

        //Supaya text box multiline tidak kebawah ketika di enter
        private void enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        //Button Save
        private void materialRaisedButton6_Click(object sender, EventArgs e)
        {
            string akunid1 = materialSingleLineTextField15.Text;
            string password = materialSingleLineTextField10.Text;

            FileStream ambildata1 = new FileStream("Akun.txt", FileMode.Open, FileAccess.Read);
            StreamReader bacadata1 = new StreamReader(ambildata1);
            string linee = bacadata1.ReadLine();
            while (linee != null)
            {
                // Console.Clear();
                string[] dataakun = linee.Split('#');
                if (akunid1 == dataakun[0])
                {
                    dataakun0 = dataakun[0];
                    dataakun1 = dataakun[1];
                    dataakun2 = dataakun[2];
                    dataakun3 = dataakun[3];
                    dataakun4 = dataakun[4];
                    dataakun5 = dataakun[5];
                }
                else
                {
                }
                linee = bacadata1.ReadLine();
            }
            bacadata1.Close();
            ambildata1.Close();
            if (akunid1 != dataakun0)
            {
                //validasi email
                string vemail = materialSingleLineTextField12.Text;
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(vemail);

                //Untuk Validasi Username
                FileStream bd = new FileStream("Akun.txt", FileMode.Open, FileAccess.Read);
                StreamReader bdd = new StreamReader(bd);
                string line = bdd.ReadLine();
                string[] dataakun;
                int flag = 0;
                while (line != null)
                {
                    dataakun = line.Split('#');
                    if (materialSingleLineTextField11.Text == dataakun[8])
                    {
                        flag = 1;
                    }
                    else
                    {
                    }
                    line = bdd.ReadLine();
                }
                bdd.Close();
                bd.Close();

                //Load Data
                declaredata();

                //Load Encrypt
                string sandi = Encrypt(materialSingleLineTextField10.Text);
                string jawaban = Encrypt(materialSingleLineTextField9.Text);

                //Membersihkan Error
                errorProvider1.Clear();

                //Check Data Kosong
                if (nama.Trim().Length != 0)
                {
                    if (comboBox9.Text != "- Select Citizenship -")
                    {
                        if (alamat.Trim().Length != 0)
                        {
                            if (hp.Trim().Length != 0)
                            {
                                if (email.Trim().Length != 0)
                                {
                                    if (username.Trim().Length != 0)
                                    {
                                        if (password.Trim().Length != 0)
                                        {
                                            if (comboBox8.Text != "- Select Type -")
                                            {
                                                if (comboBox6.Text != "- Select Question -")
                                                {
                                                    if (jawaban.Trim().Length != 0)
                                                    {
                                                        if (match.Success)
                                                        {
                                                            if (flag != 1)
                                                            {
                                                                FileStream fs = new FileStream("Akun.txt", FileMode.Append, FileAccess.Write);
                                                                StreamWriter sw = new StreamWriter(fs);
                                                                string savedata = akunid1 + "#" + nama + "#" + ttl + "#" + gender + "#" + warganegara + "#" + alamat + "#" + hp + "#" + email + "#" + username + "#" + sandi + "#" + status + "#" + type + "#" + quest + "#" + jawaban + "#";
                                                                sw.WriteLine(savedata);
                                                                sw.Close();
                                                                fs.Close();
                                                                MessageBox.Show("Account has been added.", "SUCCESS!");
                                                                this.Hide();
                                                                var ad = new Admin();
                                                                ad.Closed += (s, args) => this.Close();
                                                                ad.Show();
                                                            }
                                                            else
                                                            {
                                                                errorProvider1.SetError(materialSingleLineTextField11, "Sorry username already exists!");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            errorProvider1.SetError(materialSingleLineTextField12, "Please enter valid email!");
                                                        }

                                                    }
                                                    else
                                                    {
                                                        errorProvider1.SetError(materialSingleLineTextField9, "Must be filled!");
                                                    }
                                                }
                                                else
                                                {
                                                    errorProvider1.SetError(comboBox6, "Please select question!");
                                                }
                                            }
                                            else
                                            {
                                                errorProvider1.SetError(comboBox8, "Please select type account!");
                                            }
                                        }
                                        else
                                        {
                                            errorProvider1.SetError(materialSingleLineTextField10, "Must be filled!");
                                        }
                                    }
                                    else
                                    {
                                        errorProvider1.SetError(materialSingleLineTextField11, "Must be filled!");
                                    }
                                }
                                else
                                {
                                    errorProvider1.SetError(materialSingleLineTextField12, "Must be filled!");
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(materialSingleLineTextField13, "Must be filled!");
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(textBox2, "Must be filled!");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(comboBox9, "Please select citizenship!");
                    }
                }
                else
                {
                    errorProvider1.SetError(materialSingleLineTextField14, "Must be filled!");
                }
            }
            else
            {
                MessageBox.Show("ID Account already exists!", "FAILED!");
                this.Hide();
                var ad = new Admin();
                ad.Closed += (s, args) => this.Close();
                ad.Show();
            }
        }

        //Input Hanya Angka

        private void hanyaangka_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        //declare data
        private void declaredata()
        {
            nama = materialSingleLineTextField14.Text;
            ttl = Convert.ToString(dateTimePicker2.Value.ToString("dd/MM/yyyy"));
            bool isChecked = materialRadioButton1.Checked;
            if (isChecked)
                gender = materialRadioButton1.Text;
            else
                gender = materialRadioButton2.Text;
            warganegara = comboBox9.Text;
            alamat = textBox2.Text;
            hp = materialSingleLineTextField13.Text;
            email = materialSingleLineTextField12.Text;
            username = materialSingleLineTextField11.Text;
            status = comboBox7.Text;
            type = comboBox8.Text;
            quest = comboBox6.Text;
        }

        //Encrypt
        private string Encrypt(string Encrypt)
        {
            try
            {
                byte[] encData_byte = new byte[Encrypt.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(Encrypt);
                string hasil = Convert.ToBase64String(encData_byte);
                return hasil;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Encrypt Password" + ex.Message);
            }
        }

        //Search Pake Enter
        private void searchenter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchenter();
            }
        }

        //Search Enter
        private void searchenter()
        {
            string idakun = materialSingleLineTextField24.Text;
            FileStream ambildata = new FileStream("Akun.txt", FileMode.Open, FileAccess.Read);
            StreamReader bacadata = new StreamReader(ambildata);
            string linee = bacadata.ReadLine();
            while (linee != null)
            {
                // Console.Clear();
                string[] dataakun = linee.Split('#');
                if (idakun == dataakun[0])
                {
                    dataakun0 = dataakun[0];
                    dataakun1 = dataakun[1];
                    dataakun2 = dataakun[2];
                    dataakun3 = dataakun[3];
                    dataakun4 = dataakun[4];
                    dataakun5 = dataakun[5];
                    dataakun6 = dataakun[6];
                    dataakun7 = dataakun[7];
                    dataakun8 = dataakun[8];
                    dataakun9 = dataakun[9];
                    dataakun10 = dataakun[10];
                    dataakun11 = dataakun[11];
                    dataakun12 = dataakun[12];
                    dataakun13 = dataakun[13];
                }
                else
                {
                }
                linee = bacadata.ReadLine();
            }
            bacadata.Close();
            ambildata.Close();

            if (idakun == dataakun0)
            {
                materialSingleLineTextField15.Text = dataakun0;
                materialSingleLineTextField14.Text = dataakun1;
                dateTimePicker2.Value = DateTime.Parse(dataakun2);
                if (dataakun3 == materialRadioButton1.Text)
                {
                    materialRadioButton1.Checked = true;
                }
                else
                {
                    materialRadioButton2.Checked = true;
                }
                comboBox9.Text = dataakun4;
                textBox2.Text = dataakun5;
                materialSingleLineTextField13.Text = dataakun6;
                materialSingleLineTextField12.Text = dataakun7;
                materialSingleLineTextField11.Text = dataakun8;
                materialSingleLineTextField11.Enabled = false;

                //DI DECRYPT DULU PASSNYA
                materialSingleLineTextField10.Text = Decrypt(dataakun9);

                comboBox7.Text = dataakun10;
                comboBox8.Text = dataakun11;
                comboBox6.Text = dataakun12;

                //DECRYPT DULU ANSWERNYA
                materialSingleLineTextField9.Text = Decrypt(dataakun13);

                if (LoginForm.username == materialSingleLineTextField11.Text)
                {
                    button1.Visible = true;
                    button2.Visible = true;
                }
                else
                {
                    button1.Visible = false;
                    button2.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Data not found, Try again!", "WRONG DATA!");
                materialSingleLineTextField24.Text = "";
                materialSingleLineTextField24.Focus();
                clear();
            }
        }

        //Decrypt
        private string Decrypt(string Dec)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(Dec);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }

        private void isidtgv()
        {
            dt.Columns.Add("ID Account");
            dt.Columns.Add("Name");
            dt.Columns.Add("Birthday");
            dt.Columns.Add("Gender");
            dt.Columns.Add("Citizenship");
            dt.Columns.Add("Address");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Email");
            dt.Columns.Add("Username");
            dt.Columns.Add("Status");
            dt.Columns.Add("Type");
            dt.Columns.Add("Question");

            LinearSearch ls = new LinearSearch();
            result = ls.searchByName(materialSingleLineTextField1.Text);

            foreach (var x in result)
            {
                string[] isi = x.ToString().Split('#');
                dt.Rows.Add(isi[0], isi[1], isi[2], isi[3], isi[4], isi[5], isi[6], isi[7], isi[8], isi[10], isi[11], isi[12]);
            }

            dataGridView1.DataSource = dt;
        }
    }
}
