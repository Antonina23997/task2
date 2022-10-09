using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace Курсовая_через_файл
{

    class Список_товаров
    {
        private int n;
        private Товар[] Product;
        public Список_товаров()
        {
            int k = 1;
            Product = new Товар[k];
            Product[0] = new Товар("Начало", 0);
            n = 1;
        }
        public Список_товаров(string f) { prin(); }
        public void prin()
        {
            int i;
            n = CountFile();
            Product = new Товар[n];
                StreamReader file2 = new StreamReader("Spisok_tek.txt");
                i = 0;
                while (!file2.EndOfStream)
                {
                    Product[i] = new Товар(file2);
                    i++;
                }
                file2.Close();
        }
        private int CountFile()
        {

            StreamReader file = new StreamReader("Spisok_tek.txt");
            int i = 0;
            while (!file.EndOfStream)
            {
                file.ReadLine();
                i++; //считает кол-во товаров 
            }
            file.Close();
            return i;
        }
        public int Count()
        {
            return n;
        }
        public Товар items(int s)
        {
            return Product[s];
        }
        public void model_to_file(String p)
        {
            System.IO.StreamWriter file =
               new System.IO.StreamWriter(p);
            for (int j = 0; j < n; j++)
            {
                Product[j].tovar_to_file(file);
                file.WriteLine("");
            }
            file.Close();
        }
        public void add_item(string k, int c)
        {
            Товар[] d2;
            int y;
            y = n + 1;
            d2 = new Товар[y];
            for (int i = 0; i < n; i++)
            {
                d2[i] = new Товар(Product[i].prinname(), Product[i].prinkol());
            }
            d2[y - 1] = new Товар(k, c);
            Product = d2;
            n = y;
        }
        public void delet_item(int v)
        {
            Товар[] d3;
            int y, i;
            bool r= true;
            y = n - 1 ;
            d3 = new Товар[y];
            for( i=0;i<v;i++)
            {
                     d3[i] = new Товар(Product[i].prinname(), Product[i].prinkol()); 
            }
            i++;
            for (int s = v ; s < y; s++, i++)
            {
                d3[s] = new Товар(Product[i].prinname(), Product[i].prinkol());
            }
            Product = d3;
            n = y;
        }
    }

}
