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
    public partial class Home : Form
    {
        private readonly MaterialSkinManager materialSkinManager;

        private string Str, kodebaru, nama, ttl, gender, warganegara, alamat, hp, email, username, status, type, quest;
        private string dataakun0, dataakun1, dataakun2, dataakun3, dataakun4, dataakun5, dataakun6, dataakun7, dataakun8, dataakun9, dataakun10, dataakun11, dataakun12, dataakun13, dataakun14, dataakun15, dataakun16, dataakun17, dataakun18, dataakun19;
        private string cusid, idnum, typeid, namecus, kelamin, birthday, address, phone, emailcus, citicus, numpeo, booking, ood, tilldate, rclass, room, stcus, harga;
        DataTable dt = new DataTable();

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt.Clear();

            int jml = File.ReadAllLines("Customer.txt").Count();
            string[] hasil = new string[jml];

            string[] data = result.ToArray(typeof(string)) as string[];
            
            if (comboBox10.Text == "Name")
            {
                BubbleSort bs = new BubbleSort();
                hasil = bs.bubbleNameAsc(data);
            }

            if (comboBox10.Text == "Date")
            {
                BubbleSort bs = new BubbleSort();
                hasil = bs.tanggalDesc(data);
            }

            if (comboBox10.Text == "Price")
            {
                BubbleSort bs = new BubbleSort();
                hasil = bs.hargaDesc(data);
            }

            foreach (var x in hasil)
            {
                string[] isi = x.Split('#');
                dt.Rows.Add(isi[0], isi[1], isi[2], isi[3], isi[4], isi[5], isi[6], isi[7], isi[8], isi[10], isi[11], isi[12], isi[13], isi[14], isi[15], isi[16], isi[17], isi[18]);
            }

            dataGridView1.DataSource = dt;
        }

        private void materialRaisedButton12_Click(object sender, EventArgs e)
        {
            dt.Clear();

            LinearSearch ls = new LinearSearch();
            result = ls.SearchCustomer(materialSingleLineTextField8.Text);

            foreach (var x in result)
            {
                string[] isi = x.ToString().Split('#');
                dt.Rows.Add(isi[0], isi[1], isi[2], isi[3], isi[4], isi[5], isi[6], isi[7], isi[8], isi[10], isi[11], isi[12], isi[13], isi[14], isi[15], isi[16], isi[17], isi[18]);
            }

            dataGridView1.DataSource = dt;
        }

        private void materialRaisedButton9_Click_1(object sender, EventArgs e)
        {
            ReportCustomer rc = new ReportCustomer();
            rc.Show();
        }

        ArrayList result = new ArrayList();
        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            declaredata();
            FileStream ambildata1 = new FileStream("Customer.txt", FileMode.Open, FileAccess.Read);
            StreamReader bacadata1 = new StreamReader(ambildata1);
            string linee = bacadata1.ReadLine();
            while (linee != null)
            {
                // Console.Clear();
                string[] dataakun = linee.Split('#');
                if (cusid == dataakun[0])
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
                    dataakun14 = dataakun[14];
                    dataakun15 = dataakun[15];
                    dataakun16 = dataakun[16];
                    dataakun17 = dataakun[17];
                    dataakun18 = dataakun[18];
                    dataakun19 = dataakun[19];
                }
                else
                {
                }
                linee = bacadata1.ReadLine();
            }
            bacadata1.Close();
            ambildata1.Close();

            if (cusid == dataakun0)
            {
                //Load Data
                declaredata();
                if (MessageBox.Show("Are you sure want to delete data?" + " " + dataakun3, "DELETE DATA!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string path = ("Customer.txt");
                    var oldlinelogin = File.ReadAllLines(path);
                    var newline = oldlinelogin.Where(line => !line.Contains(cusid + "#"));
                    File.WriteAllLines(path, newline);
                    MessageBox.Show("Data has been deleted.", "SUCCESS!");
                    this.Hide();
                    var hm = new Home();
                    hm.Closed += (s, args) => this.Close();
                    hm.Show();
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
                materialSingleLineTextField2.Text = "";
                materialSingleLineTextField2.Focus();
            }
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            declaredata();
            errorProvider1.Clear();
            //validasi email
            string vemail = materialSingleLineTextField12.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(vemail);

            FileStream ambildata1 = new FileStream("Customer.txt", FileMode.Open, FileAccess.Read);
            StreamReader bacadata1 = new StreamReader(ambildata1);
            string linee = bacadata1.ReadLine();
            while (linee != null)
            {
                // Console.Clear();
                string[] dataakun = linee.Split('#');
                if (cusid == dataakun[0])
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
                    dataakun14 = dataakun[14];
                    dataakun15 = dataakun[15];
                    dataakun16 = dataakun[16];
                    dataakun17 = dataakun[17];
                    dataakun18 = dataakun[18];
                    dataakun19 = dataakun[19];
                }
                else
                {
                }
                linee = bacadata1.ReadLine();
            }
            bacadata1.Close();
            ambildata1.Close();

            if (cusid == dataakun0)
            {
                if (idnum.Trim().Length != 0)
                {
                    if (typeid != "- Select Type of Identity -")
                    {
                        if (namecus.Trim().Length != 0)
                        {
                            if (address.Trim().Length != 0)
                            {
                                if (phone.Trim().Length != 0)
                                {
                                    if (match.Success)
                                    {
                                        if (citicus != "- Select Citizenship -")
                                        {
                                            if (numpeo.Trim().Length != 0)
                                            {
                                                if (dateTimePicker1.Value <= dateTimePicker3.Value)
                                                {
                                                    if (dateTimePicker3.Value <= dateTimePicker4.Value)
                                                    {
                                                        if (dateTimePicker4.Value >= dateTimePicker3.Value)
                                                        {
                                                            if (rclass != "- Select Class Room -")
                                                            {
                                                                if (room != "- Select Room Number -")
                                                                {
                                                                    //UPDATE ROOM
                                                                    FileStream ambildata2 = new FileStream("Room.txt", FileMode.Open, FileAccess.Read);
                                                                    StreamReader bacadata2 = new StreamReader(ambildata2);
                                                                    string linee2 = bacadata2.ReadLine();
                                                                    while (linee2 != null)
                                                                    {
                                                                        // Console.Clear();
                                                                        string[] dataroom = linee2.Split('#');
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
                                                                        linee2 = bacadata2.ReadLine();
                                                                    }
                                                                    bacadata2.Close();
                                                                    ambildata2.Close();
                                                                    if (room == dataroom0)
                                                                    {
                                                                        //Update
                                                                        string old1 = dataakun0 + "#" + dataakun1 + "#" + dataakun2 + "#" + dataakun3 + "#" + dataakun4 + "#" + dataakun5 + "#" + dataakun6 + "#" + dataakun7 + "#" + dataakun8 + "#" + dataakun9 + "#" + dataakun10 + "#" + dataakun11 + "#" + dataakun12 + "#" + dataakun13 + "#" + dataakun14 + "#" + dataakun15 + "#" + dataakun16 + "#" + dataakun17 + "#" + dataakun18 + "#";
                                                                        string neww1 = cusid + "#" + idnum + "#" + typeid + "#" + namecus + "#" + kelamin + "#" + birthday + "#" + address + "#" + phone + "#" + emailcus + "#" + citicus + "#" + numpeo + "#" + booking + "#" + ood + "#" + tilldate + "#" + rclass + "#" + room + "#" + stcus + "#" + harga + "#" + LoginForm.akunid + "#";
                                                                        string update1 = File.ReadAllText("Customer.txt");
                                                                        update1 = update1.Replace(old1, neww1);
                                                                        File.WriteAllText("Customer.txt", update1);

                                                                        //Update
                                                                        string old = dataroom0 + "#" + dataroom1 + "#" + dataroom2 + "#" + dataroom3 + "#" + dataroom4 + "#" + dataroom5 + "#";
                                                                        string neww = room + "#" + dataroom1 + "#" + dataroom2 + "#" + dataroom3 + "#" + staroom + "#" + coroom + "#";
                                                                        string update = File.ReadAllText("Room.txt");
                                                                        update = update.Replace(old, neww);
                                                                        File.WriteAllText("Room.txt", update);

                                                                        MessageBox.Show("Account has been Updated.", "SUCCESS!");
                                                                        this.Hide();
                                                                        var hm = new Home();
                                                                        hm.Closed += (s, args) => this.Close();
                                                                        hm.Show();
                                                                    }
                                                                    else
                                                                    {
                                                                        MessageBox.Show("Failed to add data!", "FAILED!");
                                                                        this.Hide();
                                                                        var hm = new Home();
                                                                        hm.Closed += (s, args) => this.Close();
                                                                        hm.Show();
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    errorProvider1.SetError(comboBox4, "Please select room number!");
                                                                }

                                                            }
                                                            else
                                                            {
                                                                errorProvider1.SetError(comboBox3, "Please select class room!");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            errorProvider1.SetError(dateTimePicker4, "Please enter correct date!");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        errorProvider1.SetError(dateTimePicker3, "Please enter correct date!");
                                                    }
                                                }
                                                else
                                                {
                                                    errorProvider1.SetError(dateTimePicker1, "Please enter correct date!");
                                                }
                                            }
                                            else
                                            {
                                                errorProvider1.SetError(materialSingleLineTextField5, "Must be filled!");
                                            }
                                        }
                                        else
                                        {
                                            errorProvider1.SetError(comboBox1, "Please select Citizenship!");
                                        }
                                    }
                                    else
                                    {
                                        errorProvider1.SetError(materialSingleLineTextField12, "Enter valid email!");
                                    }
                                }
                                else
                                {
                                    errorProvider1.SetError(materialSingleLineTextField4, "Must be filled!");
                                }

                            }
                            else
                            {
                                errorProvider1.SetError(textBox2, "Must be filled!");
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(materialSingleLineTextField1, "Must be filled!");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(comboBox2, "Please select type of identity!");
                    }

                }
                else
                {
                    errorProvider1.SetError(materialSingleLineTextField3, "Must be filled!");
                }
            }
            else
            {
                MessageBox.Show("Data not found!", "FAILED!");
                this.Hide();
                var hm = new Home();
                hm.Closed += (s, args) => this.Close();
                hm.Show();
            }
        }

        private void materialRaisedButton6_Click(object sender, EventArgs e)
        {
            string idcustomer = materialSingleLineTextField6.Text;
            FileStream ambildata = new FileStream("Customer.txt", FileMode.Open, FileAccess.Read);
            StreamReader bacadata = new StreamReader(ambildata);
            string linee = bacadata.ReadLine();
            while (linee != null)
            {
                // Console.Clear();
                string[] dataakun = linee.Split('#');
                if (idcustomer == dataakun[0])
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
                    dataakun14 = dataakun[14];
                    dataakun15 = dataakun[15];
                    dataakun16 = dataakun[16];
                    dataakun17 = dataakun[17];
                }
                else
                {
                }
                linee = bacadata.ReadLine();
            }
            bacadata.Close();
            ambildata.Close();

            if (idcustomer == dataakun0)
            {
                materialSingleLineTextField2.Text = dataakun0;
                materialSingleLineTextField3.Text = dataakun1;
                comboBox2.Text = dataakun2;
                materialSingleLineTextField1.Text = dataakun3;
                if (dataakun4 == materialRadioButton1.Text)
                {
                    materialRadioButton1.Checked = true;
                }
                else
                {
                    materialRadioButton2.Checked = true;
                }
                dateTimePicker2.Value = DateTime.Parse(dataakun5);
                textBox2.Text = dataakun6;
                materialSingleLineTextField4.Text = dataakun7;
                materialSingleLineTextField12.Text = dataakun8;
                comboBox1.Text = dataakun9;
                materialSingleLineTextField5.Text = dataakun10;
                dateTimePicker1.Value = DateTime.Parse(dataakun11);
                dateTimePicker3.Value = DateTime.Parse(dataakun12);
                dateTimePicker4.Value = DateTime.Parse(dataakun13);
                comboBox3.Text = dataakun14;
                comboBox4.Items.Add(dataakun15);
                comboBox4.SelectedItem = dataakun15;
                comboBox5.Text = dataakun16;
            }
            else
            {
                MessageBox.Show("Data not found, Try again!", "WRONG DATA!");
                this.Hide();
                var hm = new Home();
                hm.Closed += (s, args) => this.Close();
                hm.Show();
            }
        }

        private void materialRaisedButton11_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private string staroom, coroom;
        private string dataroom0, dataroom1, dataroom2, dataroom3, dataroom4, dataroom5;
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text == "Check In")
            {
                staroom = "Not Available";
                coroom = "Good";
            }
            if (comboBox5.Text == "Check Out")
            {
                staroom = "Available";
                coroom = "Cleaned Up";
            }
            if (comboBox5.Text == "Cancel")
            {
                staroom = "Available";
                coroom = "Cleaned Up";
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadharga();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            comboBox4.Items.Add("- Select Room Number -");
            loadroom();
            comboBox4.SelectedIndex = 0;
        }

        private int Code;
        public Home()
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

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var hm = new Home();
            hm.Closed += (s, args) => this.Close();
            hm.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

            isidtgv();
            //Load Isi Combobox
            menucombobox();

            //Load Nama Akun
            label3.Text = LoginForm.nama;

            //Load Data
            loaddata();

            //Load 17 Tahun
            supaya17tahun();

            //Load Auto ID
            autoid();

            //Text Box AutoID
            materialSingleLineTextField2.Text = kodebaru;

            //isitanggal
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
            dateTimePicker4.Value = DateTime.Now;

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var lf = new LoginForm();
            lf.Closed += (s, args) => this.Close();
            lf.Show();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (dateTimePicker3.Value > dateTimePicker4.Value)
            {
                errorProvider1.SetError(dateTimePicker3, "Please enter correct date");
            }
            loadharga();
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (dateTimePicker4.Value < dateTimePicker3.Value)
            {
                errorProvider1.SetError(dateTimePicker4, "Please enter correct date");
            }
            loadharga();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (dateTimePicker1.Value > dateTimePicker3.Value)
            {
                errorProvider1.SetError(dateTimePicker1, "Please enter correct date");
            }
            loadharga();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            declaredata();
            errorProvider1.Clear();
            //validasi email
            string vemail = materialSingleLineTextField12.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(vemail);

            FileStream ambildata1 = new FileStream("Customer.txt", FileMode.Open, FileAccess.Read);
            StreamReader bacadata1 = new StreamReader(ambildata1);
            string linee = bacadata1.ReadLine();
            while (linee != null)
            {
                // Console.Clear();
                string[] dataakun = linee.Split('#');
                if (cusid == dataakun[0])
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
                    dataakun14 = dataakun[14];
                    dataakun15 = dataakun[15];
                    dataakun16 = dataakun[16];
                    dataakun17 = dataakun[17];
                    dataakun18 = dataakun[18];
                    dataakun19 = dataakun[19];
                }
                else
                {
                }
                linee = bacadata1.ReadLine();
            }
            bacadata1.Close();
            ambildata1.Close();

            if (cusid != dataakun0)
            {
                if (idnum.Trim().Length != 0)
                {
                    if (typeid != "- Select Type of Identity -")
                    {
                        if (namecus.Trim().Length != 0)
                        {
                            if (address.Trim().Length != 0)
                            {
                                if (phone.Trim().Length != 0)
                                {
                                    if (match.Success)
                                    {
                                        if (citicus != "- Select Citizenship -")
                                        {
                                            if (numpeo.Trim().Length != 0)
                                            {
                                                if (dateTimePicker1.Value <= dateTimePicker3.Value)
                                                {
                                                    if (dateTimePicker3.Value <= dateTimePicker4.Value)
                                                    {
                                                        if (dateTimePicker4.Value >= dateTimePicker3.Value)
                                                        {
                                                            if (rclass != "- Select Class Room -")
                                                            {
                                                                if (room != "- Select Room Number -")
                                                                {
                                                                    //UPDATE ROOM
                                                                    FileStream ambildata2 = new FileStream("Room.txt", FileMode.Open, FileAccess.Read);
                                                                    StreamReader bacadata2 = new StreamReader(ambildata2);
                                                                    string linee2 = bacadata2.ReadLine();
                                                                    while (linee2 != null)
                                                                    {
                                                                        // Console.Clear();
                                                                        string[] dataroom = linee2.Split('#');
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
                                                                        linee2 = bacadata2.ReadLine();
                                                                    }
                                                                    bacadata2.Close();
                                                                    ambildata2.Close();
                                                                    if (room == dataroom0)
                                                                    {
                                                                        //CREATE
                                                                        FileStream fs = new FileStream("Customer.txt", FileMode.Append, FileAccess.Write);
                                                                        StreamWriter sw = new StreamWriter(fs);
                                                                        string savedata = cusid + "#" + idnum + "#" + typeid + "#" + namecus + "#" + kelamin + "#" + birthday + "#" + address + "#" + phone + "#" + emailcus + "#" + citicus + "#" + numpeo + "#" + booking + "#" + ood + "#" + tilldate + "#" + rclass + "#" + room + "#" + stcus + "#" + harga + "#" + LoginForm.akunid + "#";
                                                                        sw.WriteLine(savedata);
                                                                        sw.Close();
                                                                        fs.Close();

                                                                        //Update
                                                                        string old = dataroom0 + "#" + dataroom1 + "#" + dataroom2 + "#" + dataroom3 + "#" + dataroom4 + "#" + dataroom5 + "#";
                                                                        string neww = room + "#" + dataroom1 + "#" + dataroom2 + "#" + dataroom3 + "#" + staroom + "#" + coroom + "#";
                                                                        string update = File.ReadAllText("Room.txt");
                                                                        update = update.Replace(old, neww);
                                                                        File.WriteAllText("Room.txt", update);

                                                                        MessageBox.Show("Account has been added.", "SUCCESS!");
                                                                        this.Hide();
                                                                        var hm = new Home();
                                                                        hm.Closed += (s, args) => this.Close();
                                                                        hm.Show();
                                                                    }
                                                                    else
                                                                    {
                                                                        MessageBox.Show("Failed to add data!", "FAILED!");
                                                                        this.Hide();
                                                                        var hm = new Home();
                                                                        hm.Closed += (s, args) => this.Close();
                                                                        hm.Show();
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    errorProvider1.SetError(comboBox4, "Please select room number!");
                                                                }

                                                            }
                                                            else
                                                            {
                                                                errorProvider1.SetError(comboBox3, "Please select class room!");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            errorProvider1.SetError(dateTimePicker4, "Please enter correct date!");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        errorProvider1.SetError(dateTimePicker3, "Please enter correct date!");
                                                    }
                                                }
                                                else
                                                {
                                                    errorProvider1.SetError(dateTimePicker1, "Please enter correct date!");
                                                }
                                            }
                                            else
                                            {
                                                errorProvider1.SetError(materialSingleLineTextField5, "Must be filled!");
                                            }
                                        }
                                        else
                                        {
                                            errorProvider1.SetError(comboBox1, "Please select Citizenship!");
                                        }
                                    }
                                    else
                                    {
                                        errorProvider1.SetError(materialSingleLineTextField12, "Enter valid email!");
                                    }
                                }
                                else
                                {
                                    errorProvider1.SetError(materialSingleLineTextField4, "Must be filled!");
                                }

                            }
                            else
                            {
                                errorProvider1.SetError(textBox2, "Must be filled!");
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(materialSingleLineTextField1, "Must be filled!");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(comboBox2, "Please select type of identity!");
                    }

                }
                else
                {
                    errorProvider1.SetError(materialSingleLineTextField3, "Must be filled!");
                }
            }
            else
            {
                MessageBox.Show("Customer ID already exists!", "FAILED!");
                this.Hide();
                var hm = new Home();
                hm.Closed += (s, args) => this.Close();
                hm.Show();
            }
        }

        private void materialSingleLineTextField2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField4_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var lf = new LoginForm();
            lf.Closed += (s, args) => this.Close();
            lf.Show();
        }

        // combo box
        private void menucombobox()
        {
            //Combo Box 5
            comboBox5.Items.Add("Check In");
            comboBox5.Items.Add("Check Out");
            comboBox5.Items.Add("Cancel");
            comboBox5.SelectedIndex = 0;

            //Combo Box 3
            comboBox3.Items.Add("- Select Class Room -");
            comboBox3.Items.Add("VIP");
            comboBox3.Items.Add("Bussiness");
            comboBox3.Items.Add("Economy");
            comboBox3.SelectedIndex = 0;

            //Combo Box 2
            comboBox2.Items.Add("- Select Type of Identity -");
            comboBox2.Items.Add("Identity Card Indonesia");
            comboBox2.Items.Add("Driver License Indonesia");
            comboBox2.Items.Add("Visa");
            comboBox2.Items.Add("Pasport");
            comboBox2.SelectedIndex = 0;

            //Combo Box 1
            comboBox1.Items.Add("- Select Citizenship -");
            comboBox1.Items.Add("Indonesian Citizens");
            comboBox1.Items.Add("Foreign Nationals");
            comboBox1.SelectedIndex = 0;

            //Combo Box 9
            comboBox9.Items.Add("- Select Citizenship -");
            comboBox9.Items.Add("Indonesian Citizens");
            comboBox9.Items.Add("Foreign Nationals");
            comboBox9.SelectedIndex = 0;

            //Combo Box 10
            comboBox10.Items.Add("Name");
            comboBox10.Items.Add("Date");
            comboBox10.Items.Add("Price");
            comboBox10.SelectedIndex = 0;

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

        private void materialRaisedButton8_Click(object sender, EventArgs e)
        {
            var fs = new Fasilitas();
            fs.Show(this);
        }

        private int showpassword;
        private void button1_Click_1(object sender, EventArgs e)
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

        private int showanswer;
        private void button2_Click_1(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton9_Click(object sender, EventArgs e)
        {

        }

        private void hanyaangka_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void materialRaisedButton10_Click(object sender, EventArgs e)
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
            string vemail = materialSingleLineTextField7.Text;
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
                                                        var hm = new Home();
                                                        hm.Closed += (s, args) => this.Close();
                                                        hm.Show();
                                                    }
                                                    else
                                                    {
                                                        errorProvider1.SetError(materialSingleLineTextField7, "Please enter valid email!");
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
                                errorProvider1.SetError(materialSingleLineTextField7, "Must be filled!");
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(materialSingleLineTextField13, "Must be filled!");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(textBox1, "Must be filled!");
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

        //declare data
        private void declaredata1()
        {
            nama = materialSingleLineTextField14.Text;
            ttl = Convert.ToString(dateTimePicker5.Value.ToString("dd/MM/yyyy"));
            bool isChecked = materialRadioButton4.Checked;
            if (isChecked)
                gender = materialRadioButton4.Text;
            else
                gender = materialRadioButton3.Text;
            warganegara = comboBox9.Text;
            alamat = textBox1.Text;
            hp = materialSingleLineTextField13.Text;
            email = materialSingleLineTextField7.Text;
            username = materialSingleLineTextField11.Text;
            status = comboBox7.Text;
            type = comboBox8.Text;
            quest = comboBox6.Text;
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
                    dateTimePicker5.Value = DateTime.Parse(dataakun[2]);
                    if (dataakun[3] == materialRadioButton4.Text)
                    {
                        materialRadioButton4.Checked = true;
                    }
                    else
                    {
                        materialRadioButton3.Checked = true;
                    }
                    comboBox9.Text = dataakun[4];
                    textBox1.Text = dataakun[5];
                    materialSingleLineTextField13.Text = dataakun[6];
                    materialSingleLineTextField7.Text = dataakun[7];
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

        //tanggal supaya 17tahun
        private void supaya17tahun()
        {
            dateTimePicker2.Value = DateTime.Now.AddYears(-17);
        }

        //BUAT ID OTOMATIS
        public string autoid()
        {
            FileStream F = new FileStream("Customer.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(F);

            while ((Str = sr.ReadLine()) != null)
            {
                string lastLine = File.ReadLines("Customer.txt").Last();
                if (lastLine != null)
                {
                    string[] isi = lastLine.Split('#');
                    Code = Convert.ToInt32(isi[0].Substring(1, 4));
                    Code = Code + 1;
                    if (Code < 10)
                    {
                        kodebaru = "C000" + Code;
                    }
                    else if (Code >= 10 && Code < 99)
                    {
                        kodebaru = "C00" + Code;
                    }
                    else if (Code >= 100 && Code < 999)
                    {
                        kodebaru = "C0" + Code;
                    }
                    else if (Code >= 1000 && Code < 9999)
                    {
                        kodebaru = "C" + Code;
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
            kodebaru = "C0001";
            sr.Close();
            F.Close();
            return kodebaru;
        }

        private void loadroom()
        {
            string[] lineOfContents = File.ReadAllLines("Room.txt");
            foreach (var line in lineOfContents)
            {
                string[] dataroom = line.Split('#');
                if (comboBox3.Text == dataroom[1] && dataroom[4] == "Available" && dataroom[5] == "Good")
                {
                    comboBox4.Items.Add(dataroom[0]);
                }
            }
        }

        private void loadharga()
        {
            errorProvider1.Clear();
            int NumberOfDays = (dateTimePicker4.Value - dateTimePicker3.Value).Days;
            string[] lineOfContents = File.ReadAllLines("Room.txt");
            foreach (var line in lineOfContents)
            {
                string[] dataroom = line.Split('#');
                if (comboBox4.Text == dataroom[0])
                {
                    if (NumberOfDays == 0)
                    {
                        int hasil = Convert.ToInt32(dataroom[3]) * (NumberOfDays + 1);
                        label18.Text = Convert.ToString(hasil);
                        label24.Text = dataroom[2];
                    }
                    else
                    {
                        int hasil = Convert.ToInt32(dataroom[3]) * (NumberOfDays);
                        label18.Text = Convert.ToString(hasil);
                        label24.Text = dataroom[2];
                    }

                }
            }
        }

        //declare data
        private void declaredata()
        {
            cusid = materialSingleLineTextField2.Text;
            idnum = materialSingleLineTextField3.Text;
            typeid = comboBox2.Text;
            namecus = materialSingleLineTextField1.Text;
            bool isChecked = materialRadioButton1.Checked;
            if (isChecked)
                kelamin = materialRadioButton1.Text;
            else
                kelamin = materialRadioButton2.Text;
            birthday = Convert.ToString(dateTimePicker2.Value.ToString("dd/MM/yyyy"));
            address = textBox2.Text;
            phone = materialSingleLineTextField4.Text;
            emailcus = materialSingleLineTextField12.Text;
            citicus = comboBox1.Text;
            numpeo = materialSingleLineTextField5.Text;
            booking = Convert.ToString(dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            ood = Convert.ToString(dateTimePicker3.Value.ToString("dd/MM/yyyy"));
            tilldate = Convert.ToString(dateTimePicker4.Value.ToString("dd/MM/yyyy"));
            rclass = comboBox3.Text;
            room = comboBox4.Text;
            stcus = comboBox5.Text;
            harga = label18.Text;
        }

        //Search Pake Enter
        private void searchenter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchenter();
            }
        }

        private void searchenter()
        {
            string idcustomer = materialSingleLineTextField6.Text;
            FileStream ambildata = new FileStream("Customer.txt", FileMode.Open, FileAccess.Read);
            StreamReader bacadata = new StreamReader(ambildata);
            string linee = bacadata.ReadLine();
            while (linee != null)
            {
                // Console.Clear();
                string[] dataakun = linee.Split('#');
                if (idcustomer == dataakun[0])
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
                    dataakun14 = dataakun[14];
                    dataakun15 = dataakun[15];
                    dataakun16 = dataakun[16];
                    dataakun17 = dataakun[17];
                }
                else
                {
                }
                linee = bacadata.ReadLine();
            }
            bacadata.Close();
            ambildata.Close();

            if (idcustomer == dataakun0)
            {
                materialSingleLineTextField2.Text = dataakun0;
                materialSingleLineTextField3.Text = dataakun1;
                comboBox2.Text = dataakun2;
                materialSingleLineTextField1.Text = dataakun3;
                if (dataakun4 == materialRadioButton1.Text)
                {
                    materialRadioButton1.Checked = true;
                }
                else
                {
                    materialRadioButton2.Checked = true;
                }
                dateTimePicker2.Value = DateTime.Parse(dataakun5);
                textBox2.Text = dataakun6;
                materialSingleLineTextField4.Text = dataakun7;
                materialSingleLineTextField12.Text = dataakun8;
                comboBox1.Text = dataakun9;
                materialSingleLineTextField5.Text = dataakun10;
                dateTimePicker1.Value = DateTime.Parse(dataakun11);
                dateTimePicker3.Value = DateTime.Parse(dataakun12);
                dateTimePicker4.Value = DateTime.Parse(dataakun13);
                comboBox3.Text = dataakun14;
                comboBox4.Items.Add(dataakun15);
                comboBox4.SelectedItem = dataakun15;
                comboBox5.Text = dataakun16;
            }
            else
            {
                MessageBox.Show("Data not found, Try again!", "WRONG DATA!");
                this.Hide();
                var hm = new Home();
                hm.Closed += (s, args) => this.Close();
                hm.Show();
            }
        }

        private void isidtgv()
        {
            dt.Columns.Add("Customer ID");
            dt.Columns.Add("Identity Number");
            dt.Columns.Add("Type of Indentity");
            dt.Columns.Add("Name");
            dt.Columns.Add("Gender");
            dt.Columns.Add("Date of Birth");
            dt.Columns.Add("Address");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Email");
            dt.Columns.Add("Citizenship");
            dt.Columns.Add("Booking Date");
            dt.Columns.Add("Check In");
            dt.Columns.Add("Check Out");
            dt.Columns.Add("Room Class");
            dt.Columns.Add("Room Number");
            dt.Columns.Add("Status");
            dt.Columns.Add("Total Price");
            dt.Columns.Add("Staff Hotel");

            LinearSearch ls = new LinearSearch();
            result = ls.SearchCustomer(materialSingleLineTextField8.Text);

            foreach (var x in result)
            {
                string[] isi = x.ToString().Split('#');
                dt.Rows.Add(isi[0], isi[1], isi[2], isi[3], isi[4], isi[5], isi[6], isi[7], isi[8], isi[10], isi[11], isi[12], isi[13], isi[14], isi[15], isi[16], isi[17],isi[18]);
            }

            dataGridView1.DataSource = dt;
        }
    }
}
