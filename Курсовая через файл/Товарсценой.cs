using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Курсовая_через_файл
{
    public class Товарсценой : Товар
    {
        public int flo;
        public Товарсценой(string name, int kol, int flo): base(name, kol)
        {
            this.flo = flo;
            this.name = name;
            this.kol = kol;
        }
          public Товарсценой(StreamReader a): base(a)
        {
            flo = Convert.ToInt32(array[2]);
        }
          public void tovar_to_file(StreamWriter g)
          {
              base.tovar_to_file(g);
              g.Write(" ");
              g.Write(flo);
          }
        public string prinnamee() { return name; }
        public int prinkoll() { return kol; }
        public int prinflo() { return flo; }
        public int ctoim()
          {
              int k;
              k = flo * kol;
              return k;
          }
        
    }
}
