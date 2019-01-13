using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace ProjectHotel
{
    class LinearSearch
    {
        public ArrayList searchByName(string keyword)
        {
            ArrayList result = new ArrayList();
            FileStream fs = new FileStream("Akun.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string line = sr.ReadLine();
            while (line != null)
            {
                string[] isi = line.Split('#');
                if (isi[1].Contains(keyword))
                {
                    result.Add(line);
                }
                line = sr.ReadLine();
            }

            sr.Close();
            fs.Close();

            return result;
        }

        public ArrayList SearchCustomer(string keyword)
        {
            ArrayList result = new ArrayList();
            FileStream fs = new FileStream("Customer.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string line = sr.ReadLine();
            while (line != null)
            {
                string[] isi = line.Split('#');
                if (isi[3].Contains(keyword))
                {
                    result.Add(line);
                }
                line = sr.ReadLine();
            }

            sr.Close();
            fs.Close();

            return result;
        }
    }
}
