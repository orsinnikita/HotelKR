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
using System.Text.RegularExpressions;
using System.Collections;

namespace ProjectHotel
{
    public partial class Technic : Form
    {
        private readonly MaterialSkinManager materialSkinManager;

        //Data Type
        private string Str, kodebaru, RoomNumber, Roomclass, Capacityroom, Price, Roomstatus, Roomcondition;
        private string dataroom0, dataroom1, dataroom2, dataroom3, dataroom4, dataroom5;
        private string nama, ttl, gender, warganegara, alamat, hp, email, username, status, type, quest;
        private string dataakun0, dataakun1, dataakun2, dataakun3, dataakun4, dataakun5, dataakun6, dataakun7, dataakun8, dataakun9, dataakun10, dataakun11, dataakun12, dataakun13;
        private int Code;

        DataTable dt = new DataTable();
        ArrayList result = new ArrayList();
        public Technic()
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            string room1 = materialSingleLineTextField6.Text;
            FileStream ambildata1 = new FileStream("Room.txt", FileMode.Open, FileAccess.Read);
            StreamReader bacadata1 = new StreamReader(ambildata1);
            string linee = bacadata1.ReadLine();
            while (linee != null)
            {
                // Console.Clear();
                string[] dataroom = linee.Split('#');
                if (room1 == dataroom[0])
                {
                    dataroom0 = dataroom[0];
                    dataroom1 = dataroom[1];
                    dataroom2 = dataroom[2];
                    dataroom3 = dataroom[3];
                    dataroom4 = dataroom[4];
                    dataroom5 = dataroom[5];
                }
                else
                {
                }
                linee = bacadata1.ReadLine();
            }
            bacadata1.Close();
            ambildata1.Close();
            if (room1 == dataroom0)
            {
                //Load Data
                declaredata();

                //Membersihkan Error
                errorProvider1.Clear();

                //Check Data Kosong
                if (RoomNumber.Trim().Length != 0)
                {
                    if (comboBox1.Text != "- Select Room Class -")
                    {
                        if (Capacityroom.Trim().Length != 0)
                        {
                            if (Price.Trim().Length != 0)
                            {
                                if (comboBox2.Text != "- Select Room Status -")
                                {
                                    if (comboBox3.Text != "- Select Room Condition -")
                                    {
                                        string old = dataroom0 + "#" + dataroom1 + "#" + dataroom2 + "#" + dataroom3 + "#" + dataroom4 + "#" + dataroom5 + "#";
                                        string neww = RoomNumber + "#" + Roomclass + "#" + Capacityroom + "#" + Price + "#" + Roomstatus + "#" + Roomcondition + "#";
                                        string update = File.ReadAllText("Room.txt");
                                        update = update.Replace(old, neww);
                                        File.WriteAllText("Room.txt", update);
                                        MessageBox.Show("Data has been updated.", "SUCCESS!");
                                        this.Hide();
                                        var tc = new Technic();
                                        tc.Closed += (s, args) => this.Close();
                                        tc.Show();
                                    }
                                    else
                                    {
                                        errorProvider1.SetError(comboBox3, "Please select room condition!");
                                    }
                                }
                                else
                                {
                                    errorProvider1.SetError(comboBox2, "Please select room status!");
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(materialSingleLineTextField3, "Must be filled!");
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(materialSingleLineTextField2, "Must be filled!");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(comboBox1, "Please select roomclass!");
                    }
                }
                else
                {
                    errorProvider1.SetError(materialSingleLineTextField1, "Must be filled!");
                }
            }
            else
            {
                MessageBox.Show("Data not found, Try again!", "WRONG DATA!");
                materialSingleLineTextField6.Text = "";
                materialSingleLineTextField6.Focus();
            }
        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            string room1 = materialSingleLineTextField6.Text;
            FileStream ambildata1 = new FileStream("Room.txt", FileMode.Open, FileAccess.Read);
            StreamReader bacadata1 = new StreamReader(ambildata1);
            string linee = bacadata1.ReadLine();
            while (linee != null)
            {
                // Console.Clear();
                string[] dataroom = linee.Split('#');
                if (room1 == dataroom[0])
                {
                    dataroom0 = dataroom[0];
                    dataroom1 = dataroom[1];
                    dataroom2 = dataroom[2];
                    dataroom3 = dataroom[3];
                    dataroom4 = dataroom[4];
                    dataroom5 = dataroom[5];
                }
                else
                {
                }
                linee = bacadata1.ReadLine();
            }
            bacadata1.Close();
            ambildata1.Close();
            if (room1 == dataroom0)
            {
                //Load Data
                declaredata();
                if (MessageBox.Show("Are you sure want to delete data?" + " " + dataroom0, "DELETE DATA!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string path = ("Room.txt");
                    var oldlinelogin = File.ReadAllLines(path);
                    var newline = oldlinelogin.Where(line => !line.Contains(room1 + "#"));
                    File.WriteAllLines(path, newline);
                    MessageBox.Show("Data has been deleted.", "SUCCESS!");
                    this.Hide();
                    var tc = new Technic();
                    tc.Closed += (s, args) => this.Close();
                    tc.Show();
                }
                else
                {
                    this.Hide();
                    var tc = new Technic();
                    tc.Closed += (s, args) => this.Close();
                    tc.Show();
                }
            }
            else
            {
                MessageBox.Show("Data not found, Try again!", "WRONG DATA!");
                materialSingleLineTextField6.Text = "";
                materialSingleLineTextField6.Focus();
            }
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            materialSingleLineTextField2.Text = "";
            materialSingleLineTextField3.Text = "";
            comboBox3.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        //BUAT HAPUS
        private void hapus()
        {
            comboBox1.SelectedIndex = 0;
            materialSingleLineTextField2.Text = "";
            materialSingleLineTextField3.Text = "";
            comboBox3.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void materialSingleLineTextField6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField15_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var lf = new LoginForm();
            lf.Closed += (s, args) => this.Close();
            lf.Show();
        }

        private void label3_Click(object sender, EventArgs e)
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

        private void materialRaisedButton9_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            string room = materialSingleLineTextField6.Text;
            FileStream ambildata = new FileStream("Room.txt", FileMode.Open, FileAccess.Read);
            StreamReader bacadata = new StreamReader(ambildata);
            string linee = bacadata.ReadLine();
            while (linee != null)
            {
                // Console.Clear();
                string[] dataroom = linee.Split('#');
                if (room == dataroom[0])
                {
                    dataroom0 = dataroom[0];
                    dataroom1 = dataroom[1];
                    dataroom2 = dataroom[2];
                    dataroom3 = dataroom[3];
                    dataroom4 = dataroom[4];
                    dataroom5 = dataroom[5];
                }
                else
                {
                }
                linee = bacadata.ReadLine();
            }
            bacadata.Close();
            ambildata.Close();

            if (room == dataroom0)
            {
                materialSingleLineTextField1.Text = dataroom0;
                comboBox1.Text = dataroom1;
                materialSingleLineTextField2.Text = dataroom2;
                materialSingleLineTextField3.Text = dataroom3;
                comboBox2.Text = dataroom4;
                comboBox3.Text = dataroom5;

            }
            else
            {
                MessageBox.Show("Data not found, Try again!", "WRONG DATA!");
                this.Hide();
                var tc = new Technic();
                tc.Closed += (s, args) => this.Close();
                tc.Show();
            }
        }

        private void materialRaisedButton8_Click(object sender, EventArgs e)
        {
            string akunid = materialSingleLineTextField15.Text;
            string password = materialSingleLineTextField10.Text;

            FileStream ambildata = new FileStream("Akun.txt", FileMode.Open, FileAccess.Read);
            StreamReader bacadata = new StreamReader(ambildata);
            string linee = bacadata.ReadLine();
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

            //validasi email
            string vemail = materialSingleLineTextField12.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(vemail);

            //Load Data
            declaredata1();

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
                                                        this.Hide();
                                                        var ad = new Technic();
                                                        ad.Closed += (s, args) => this.Close();
                                                        ad.Show();
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


        //MENU COMBO BOX
        private void menucombobox()
        {
            //Combo Box 1
            comboBox1.Items.Add("- Select Room Class -");
            comboBox1.Items.Add("VIP");
            comboBox1.Items.Add("Bussiness");
            comboBox1.Items.Add("Economy");
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Add("- Select Room Status -");
            comboBox2.Items.Add("Available");
            comboBox2.Items.Add("Not Available");
            comboBox2.SelectedIndex = 0;

            comboBox3.Items.Add("- Select Room Condition -");
            comboBox3.Items.Add("Good");
            comboBox3.Items.Add("Maintenance");
            comboBox3.Items.Add("Cleaned Up");
            comboBox3.SelectedIndex = 0;

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
        }

        private void Technic_Load(object sender, EventArgs e)
        {
            //Load Combo Box
            menucombobox();

            //Load Nama
            label3.Text = LoginForm.nama;

            //Load Auto ID
            autoid();

            //Text Box AutoID
            materialSingleLineTextField1.Text = kodebaru;

            //Load Data Akun
            loaddata();

            isidtgv();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            RoomNumber= materialSingleLineTextField1.Text;
            Roomclass = comboBox1.Text;
            Capacityroom = materialSingleLineTextField2.Text;
            Price= materialSingleLineTextField3.Text;
            Roomstatus = comboBox2.Text;
            Roomcondition= comboBox3.Text; 
        }

        private void materialRaisedButton6_Click(object sender, EventArgs e)
        {
            //Untuk Validasi Room
            FileStream bd = new FileStream("Room.txt", FileMode.Open, FileAccess.Read);
            StreamReader bdd = new StreamReader(bd);
            string line = bdd.ReadLine();
            string[] dataroom2;
            int flag = 0;
            while (line != null)
            {
                dataroom2 = line.Split('#');
                if (materialSingleLineTextField1.Text == dataroom2[0])
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

            //Membersihkan Error
            errorProvider1.Clear();

            //Check Data Kosong
            if (RoomNumber.Trim().Length != 0)
            {
                if (comboBox1.Text != "- Select Room Class -")
                {
                    if (Capacityroom.Trim().Length != 0)
                    {
                        if (Price.Trim().Length != 0)
                        {
                            if (comboBox2.Text != "- Select Room Status -")
                            {
                                if (comboBox3.Text != "- Select Room Condition -")
                                {
                                    if (flag != 1)
                                    {
                                        FileStream fs = new FileStream("Room.txt", FileMode.Append, FileAccess.Write);
                                        StreamWriter sw = new StreamWriter(fs);
                                        string savedata = RoomNumber + "#" + Roomclass + "#" + Capacityroom + "#" + Price + "#" + Roomstatus + "#" + Roomcondition + "#";
                                        sw.WriteLine(savedata);
                                        sw.Close();
                                        fs.Close();
                                        MessageBox.Show("Data has been added.", "SUCCESS!");
                                        this.Hide();
                                        var tc = new Technic();
                                        tc.Closed += (s, args) => this.Close();
                                        tc.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Sorry room already exists!","FAILED!");
                                        this.Hide();
                                        var tc = new Technic();
                                        tc.Closed += (s, args) => this.Close();
                                        tc.Show();
                                    }
                                }
                                else
                                {
                                    errorProvider1.SetError(comboBox3, "Please select room condition!");
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(comboBox2, "Please select room status!"); 
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(materialSingleLineTextField3, "Must be filled!");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(materialSingleLineTextField2, "Must be filled!");
                    }
                }
                else
                {
                    errorProvider1.SetError(comboBox1, "Please select roomclass!");
                }
            }
            else
            {
                errorProvider1.SetError(materialSingleLineTextField1, "Must be filled!");
            }
        }

        //BUAT ID OTOMATIS
        public string autoid()
        {
            FileStream F = new FileStream("Room.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(F);

            while ((Str = sr.ReadLine()) != null)
            {
                string lastLine = File.ReadLines("Room.txt").Last();
                if (lastLine != null)
                {
                    string[] isi = lastLine.Split('#');
                    Code = Convert.ToInt32(isi[0]);
                    Code = Code + 1;
                    kodebaru = Convert.ToString(Code);
                    sr.Close();
                    F.Close();
                    return kodebaru;
                }
            }
            kodebaru = "1";
            sr.Close();
            F.Close();
            return kodebaru;
        }

        //Search Pake Enter
        private void search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchenter();
            }
        }

        private void searchenter()
        {
            string room = materialSingleLineTextField6.Text;
            FileStream ambildata = new FileStream("Room.txt", FileMode.Open, FileAccess.Read);
            StreamReader bacadata = new StreamReader(ambildata);
            string linee = bacadata.ReadLine();
            while (linee != null)
            {
                // Console.Clear();
                string[] dataroom = linee.Split('#');
                if (room == dataroom[0])
                {
                    dataroom0 = dataroom[0];
                    dataroom1 = dataroom[1];
                    dataroom2 = dataroom[2];
                    dataroom3 = dataroom[3];
                    dataroom4 = dataroom[4];
                    dataroom5 = dataroom[5];
                }
                else
                {
                }
                linee = bacadata.ReadLine();
            }
            bacadata.Close();
            ambildata.Close();

            if (room == dataroom0)
            {
                materialSingleLineTextField1.Text = dataroom0;
                comboBox1.Text = dataroom1;
                materialSingleLineTextField2.Text = dataroom2;
                materialSingleLineTextField3.Text = dataroom3;
                comboBox2.Text = dataroom4;
                comboBox3.Text = dataroom5;

            }
            else
            {
                MessageBox.Show("Data not found, Try again!", "WRONG DATA!");
                this.Hide();
                var tc = new Technic();
                tc.Closed += (s, args) => this.Close();
                tc.Show();
            }
        }

        //Load Data Akun
        private void loaddata()
        {
            FileStream ambildata = new FileStream("Akun.txt", FileMode.Open, FileAccess.Read);
            StreamReader bacadata = new StreamReader(ambildata);
            string linee = bacadata.ReadLine();
            while (linee != null)
            {
                // Console.Clear();
                string[] dataakun = linee.Split('#');
                if (LoginForm.username == dataakun[8])
                {
                    materialSingleLineTextField15.Text = dataakun[0];
                    materialSingleLineTextField14.Text = dataakun[1];
                    dateTimePicker2.Value = DateTime.Parse(dataakun[2]);
                    if (dataakun[3] == materialRadioButton1.Text)
                    {
                        materialRadioButton1.Checked = true;
                    }
                    else
                    {
                        materialRadioButton2.Checked = true;
                    }
                    comboBox9.Text = dataakun[4];
                    textBox2.Text = dataakun[5];
                    materialSingleLineTextField13.Text = dataakun[6];
                    materialSingleLineTextField12.Text = dataakun[7];
                    materialSingleLineTextField11.Text = dataakun[8];

                    //DI DECRYPT DULU PASSNYA
                    materialSingleLineTextField10.Text = Decrypt(dataakun[9]);
                    comboBox7.Text = dataakun[10];
                    comboBox8.Text = dataakun[11];
                    comboBox6.Text = dataakun[12];

                    //DI DECRYPT DULU ANSWERNYA
                    materialSingleLineTextField9.Text = Decrypt(dataakun[13]);
                }
                else
                {
                }
                linee = bacadata.ReadLine();
            }
            bacadata.Close();
            ambildata.Close();  
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

        //Supaya text box multiline tidak kebawah ketika di enter
        private void enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        //declare data
        private void declaredata1()
        {
            nama = materialSingleLineTextField14.Text;
            ttl = Convert.ToString(dateTimePicker2.Value.ToString("dd/MM/yyyy"));
            bool isChecked = materialRadioButton1.Checked;
            if (isChecked)
                gender = materialRadioButton2.Text;
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

        private void isidtgv()
        {
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "Room Number";
            dataGridView1.Columns[1].Name = "Room Class";
            dataGridView1.Columns[2].Name = "Number of Mattresses";
            dataGridView1.Columns[3].Name = "Price";
            dataGridView1.Columns[4].Name = "Room Condition";
            dataGridView1.Columns[5].Name = "Room Status";

            String line = "";
            int row = 0;
            FileStream F = new FileStream("Room.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(F);
            while ((line = sr.ReadLine()) != null)
            {
                string[] elemen = line.Split('#');
                dataGridView1.Rows.Add();
                for (int i = 0; i < elemen.Length - 1; i++)
                {
                    dataGridView1[i, row].Value = elemen[i];
                }
                row++;
            }
            sr.Close();
            F.Close();
        }
    }
}
