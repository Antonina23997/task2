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

namespace Курсовая_через_файл
{
    public partial class Form1 : Form
    {
        private Список_товаров a;
        private Списоктоваровсценой b;//купили
        private Списоктоваровсценой c;//продали
        private int val, flo;
        private string str;
        private bool h;
        public Form1()
        {
            InitializeComponent();
            if (read())
            {
                string h, j, f;
                f = "Spisok_tek.txt";
                h = "Spisok_kyp.txt";
                j = "Spisok_pro.txt";
                a = new Список_товаров(f);
                b = new Списоктоваровсценой(h);
                c = new Списоктоваровсценой(j);
                model_to_view(a);
            }
            else
            {
                a = new Список_товаров();
                b = new Списоктоваровсценой();
                c = new Списоктоваровсценой();
                model_to_view(a);
            }
        }
        private bool read()
        {
            string ff;
            StreamReader file2 = new StreamReader("Spisok_tek.txt");
            ff = file2.ReadLine();
            file2.Close();
            if (String.IsNullOrEmpty(ff))
            {  return false; }
            else  return true; 
        }
        private void model_to_view(Список_товаров a)
        {
            int d;
            d = a.Count();
            dataGridView1.Rows.Clear();
            for (int i = 0; i < d; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = a.items(i).prinname();
                dataGridView1.Rows[i].Cells[1].Value = a.items(i).prinkol();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string d, g, t;
            int number1, number2;
            d = textBox1.Text;
            str = d.Replace(' ', '_');
            g = textBox2.Text;
            t = textBox3.Text;
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals(""))
            {
                MessageBox.Show("Вы заполнили не все поля!");
                CleanAllText(this);
            }
            else
            {
                if (Int32.TryParse(g, out number1) && Int32.TryParse(t, out number2))
                {
                    val = number1;
                    flo = number2;
                    h = false;
                    if (val < 0 || flo < 0)
                    {
                        MessageBox.Show("Данные не могут быть отрицательными!");
                        CleanAllText(this);
                        h = true;
                    }
                    if (h == false)
                    {
                        for (int i = 0; i < (a.Count()); i++)
                        {
                            if (str == a.items(i).prinname())
                            {
                                h = true;
                                a.items(i).addkol(val);
                                b.add(str, val, flo);
                                model_to_view(a);
                                CleanAllText(this);
                            }
                        }
                        if (h == false)
                        {
                            a.add_item(str, val);
                            //если товара такого нет добавляет в конец списка
                            b.add(str, val, flo);
                            model_to_view(a);
                            CleanAllText(this);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Количество и цена товара должны быть числами!");
                    CleanAllText(this);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            str = dataGridView1.CurrentCell.Value.ToString();
            textBox1.Text = str;
            //flo = dataGridView1.
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //сохранение
            string file, file1, file2;
            file = "Spisok_tek.txt";
            file1 = "Spisok_kyp.txt";
            file2 = "Spisok_pro.txt";
            a.model_to_file(file);
            b.model_to_file(file1);
            c.model_to_file(file2);
            label1.Text = ("Сохранено в базу");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
        private static void CleanAllText(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                    c.Text = string.Empty;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int v, d, f;
            d = 0;
            f = 0;
            v = 0;
            for (int t = 0; t < c.Count(); t++)
            {
                d += (c.itemss(t).ctoim());
            }
            for (int s = 0; s < b.Count(); s++)
            {
                f += ((b.itemss(s).ctoim()));
            }
            v = d - f;
            textBox4.Text = (Convert.ToString(v));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool d;
            string g, t;
            int number1, number2;
            g = textBox2.Text;
            t = textBox3.Text;
            if (Int32.TryParse(g, out number1) && Int32.TryParse(t, out number2))
            {
                val = number1;
                flo = number2;
                h = false;
                d = false;
                for (int i = 0; i < (a.Count()); i++)
                {
                    if (str == a.items(i).prinname())
                    {
                        h = true;
                        if (val > a.items(i).prinkol())
                        {
                            d = true;
                            MessageBox.Show("Вы требуйте кол-во больше чем имеется");
                        }
                        if (val < 0 || flo <0)
                        {
                            d = true;
                            MessageBox.Show("Данные не могут быть отрицательными!");
                            CleanAllText(this);
                        }
                        if (d == false)
                        {
                            a.items(i).subkol(val);
                            if (a.items(i).prinkol() == 0)
                            {
                                a.delet_item(i);
                            }
                            c.add(str, val, flo);
                            model_to_view(a);
                            CleanAllText(this);

                        }
                    }
                }
                if (h == false)
                {
                    MessageBox.Show("Товар отсутствует");
                    CleanAllText(this);
                }
            }
            else
                MessageBox.Show("Количество и цена товара должны быть числами!");
                CleanAllText(this);
        }
    }
}
