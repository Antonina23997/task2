using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Курсовая_через_файл
{
    class Списоктоваровсценой
    {
        private Товарсценой[] Product_price;
        private int n;
        private string h;
        public Списоктоваровсценой(string f) 
        {
            h = string.Copy(f);
            prin(); 
        }
        public Списоктоваровсценой()
        {
            int b = 1;
            Product_price = new Товарсценой[b];
            Product_price[0] = new Товарсценой("Начало",0,0);
            n = 1;
        }
        public void prin()
        {
            int i;
            n = CountFile();
            Product_price = new Товарсценой[n];
                StreamReader file2 = new StreamReader(h);
                i = 0;
                while (!file2.EndOfStream)
                {
                    Product_price[i] = new Товарсценой(file2);
                    i++;
                }
                file2.Close();
        }
        public void model_to_file(String p)
        {
            System.IO.StreamWriter file =
               new System.IO.StreamWriter(p);
            for (int j = 0; j < n; j++)
            {
                Product_price[j].tovar_to_file(file);
                file.WriteLine("");
            }

            file.Close();
        }
        private int CountFile()
        {
            StreamReader file = new StreamReader(h);
            int i = 0;
            while (!file.EndOfStream)
            {
                file.ReadLine();
                i++; //считает кол-во товаров 
            }
            file.Close();
            return i;
        }
        public Товарсценой itemss(int s)
        {
            return Product_price[s];
        }
        public int Count()
        {
            return n;
        }
        public void add(string k, int c, int f)
        {
            Товарсценой[] d2;
            int y;
            y = n + 1;
            d2 = new Товарсценой[y];
            for (int i = 0; i < n; i++)
            {
                d2[i] = new Товарсценой(Product_price[i].prinnamee(), Product_price[i].prinkoll(),Product_price[i].prinflo() );
            }
            d2[y - 1] = new Товарсценой(k, c,f);
             Product_price = d2;
            n = y;
        }
    }
}
