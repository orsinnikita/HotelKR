using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotel
{
    class BubbleSort
    {
        //sort by name desc
        public string[] bubbleNameDesc(string[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int x = 0; x < data.Length - 1; x++)
                {
                    string[] nama1 = data[x].Split('#');
                    string[] nama2 = data[x + 1].Split('#');

                    if (nama1[1].CompareTo(nama2[1]) != 1)
                    {
                        string swap = data[x];
                        data[x] = data[x + 1];
                        data[x + 1] = swap;
                    }
                }
            }
            return data;
        }

        //sort by name asc
        public string[] bubbleNameAsc(string[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int x = 0; x < data.Length - 1; x++)
                {
                    string[] nama1 = data[x].Split('#');
                    string[] nama2 = data[x + 1].Split('#');

                    if (nama1[1].CompareTo(nama2[1]) == 1)
                    {
                        string swap = data[x];
                        data[x] = data[x + 1];
                        data[x + 1] = swap;
                    }
                }
            }
            return data;
        }

        //sort by price asc
        public string[] bubblePriceAsc(string[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int x = 0; x < data.Length - 1; x++)
                {
                    string[] harga1 = data[x].Split('#');
                    string[] harga2 = data[x + 1].Split('#');

                    if (Convert.ToInt32(harga1[3]) > Convert.ToInt32(harga2[3]))
                    {
                        string swap = data[x];
                        data[x] = data[x + 1];
                        data[x + 1] = swap;
                    }
                }
            }
            return data;
        }

        //sort by price desc
        public string[] bubblePriceDesc(string[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int x = 0; x < data.Length - 1; x++)
                {
                    string[] harga1 = data[x].Split('#');
                    string[] harga2 = data[x + 1].Split('#');

                    if (Convert.ToInt32(harga1[16]) < Convert.ToInt16(harga2[16]))
                    {
                        string swap = data[x];
                        data[x] = data[x + 1];
                        data[x + 1] = swap;
                    }
                }
            }
            return data;
        }

        public string[] tanggalDesc(string[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int x = 0; x < data.Length - 1; x++)
                {
                    string[] nama1 = data[x].Split('#');
                    string[] nama2 = data[x + 1].Split('#');

                    if (nama1[10].CompareTo(nama2[10]) != 1)
                    {
                        string swap = data[x];
                        data[x] = data[x + 1];
                        data[x + 1] = swap;
                    }
                }
            }
            return data;
        }

        public string[] hargaDesc(string[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int x = 0; x < data.Length - 1; x++)
                {
                    string[] nama1 = data[x].Split('#');
                    string[] nama2 = data[x + 1].Split('#');

                    if (nama1[16].CompareTo(nama2[16]) != 1)
                    {
                        string swap = data[x];
                        data[x] = data[x + 1];
                        data[x + 1] = swap;
                    }
                }
            }
            return data;
        }
    }
}
