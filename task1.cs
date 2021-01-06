using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace lab7
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private string path;
        
        private void CreateBinfiles(object sender, EventArgs e)
        {
            try
            {
                
                string[] surname = {"Иванов", "Петров", "Сидоров", "Воронин", "Кузнецов" };
                string[] numbers = { "9033486654", "4995509526", "4951064289", "4950218441", "9616829761"};


                FolderBrowserDialog direct = new FolderBrowserDialog();
                DialogResult result = direct.ShowDialog();
                path = direct.SelectedPath + "\\FolderLab7";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                BinaryWriter BINsurnames = new BinaryWriter(new FileStream(path + "\\surnames", FileMode.Create));
                BinaryWriter BINnumbers = new BinaryWriter(new FileStream(path + "\\numbers", FileMode.Create));

                BINsurnames.Flush();
                BINnumbers.Flush();

                foreach (string i in surname)
                { 
                    BINsurnames.Write(i);
                }
                BINsurnames.Close();

                foreach (string i in numbers)
                {
                    BINnumbers.Write(i);
                }
                BINnumbers.Close();
                
                
            }
            catch (Exception e1)
            {
                textBox2.Text += "Ошибка: " + e1.Message;
                return;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                textBox2.Text = "";
                if (path == null) throw new Exception("Файлы не были сформированы.");
                String s = textBox1.Text;
                
                String pattern = @"\d{10}";
                
                char[] symb = new Char[] { ' ', '+', ')', '(', '-' };
                
                foreach (char c in symb)
                {
                    s = s.Replace(c.ToString(), "");
                }
                
                if (s == "") throw new Exception("Не введен номер, либо введены только символы разделители.");
                
                s = s.Remove(0, 1);
                
                if (! Regex.IsMatch(s, pattern)) throw new Exception("Неверно задан номер.");
                
                
                BinaryReader BINsurnames = new BinaryReader(new FileStream(path + "\\surnames", FileMode.Open));
                BinaryReader BINnumbers = new BinaryReader(new FileStream(path + "\\numbers", FileMode.Open));

                int i = 0;
                bool flag = true;
                while (BINnumbers.PeekChar() > -1 && flag)
                {
                    if (s != BINnumbers.ReadString()) ++i;
                    else flag = false;
                }
                
                if (flag) throw new Exception("Ничего не найдено.");

                for (int j = 0; j < i; j++)
                    BINsurnames.ReadString();
                

                textBox2.Text = BINsurnames.ReadString();
                
                BINsurnames.Close();
                BINnumbers.Close();
            }
            catch (Exception e1)
            {
                textBox2.Text += "Ошибка: " + e1.Message;
                return;
            }

        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.BackColor = Color.AntiqueWhite;
            label4.Text = "Иванов\r\nПетров \r\nСидоров \r\nВоронин \r\nКузнецов\r\n";
        }


        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.BackColor = Color.Ivory;
            label4.Text = "Наведите на область, чтобы увидеть фамилии владельцев";
        }
    }
}