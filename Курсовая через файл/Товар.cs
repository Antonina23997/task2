using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Курсовая_через_файл
{
    public class Товар
    {
        public string name;
        public int kol;
        public string[] array;
        public Товар(string namee, int koll) { name = namee; kol = koll; }
        public Товар(StreamReader a)
        {
            string str = a.ReadLine();
            array = str.Split(' ');
            name = array[0];
            kol = Convert.ToInt32(array[1]);
        }
        public string prinname() { return name; }
        public int prinkol() { return kol; }
        public int addkol(int s)
        {
            kol = kol + s;
            return kol;
        }
        public int subkol(int s)
        {
            kol = kol - s;
            return kol;
        }
        public void tovar_to_file(StreamWriter g)
        {
            
            g.Write(name);
            g.Write(" ");
            g.Write(kol);
        }
    }

}
