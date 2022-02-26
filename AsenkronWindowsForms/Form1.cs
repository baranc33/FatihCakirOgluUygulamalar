using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsenkronWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnOku_Click(object sender, EventArgs e)
        {
           string data= await ReadFileAsync2();
            richTextBox1.Text = data;
        }


        int Sayac = 0;
        private void btnCounter_Click(object sender, EventArgs e)
        {
            Sayac++;
            textBox1.Text = Sayac.ToString();

        }


        private string ReadFile()
        {
            string path = "dosya.txt";
            string Data = string.Empty;

            using (StreamReader sr = new StreamReader(path))
            {
                Data = sr.ReadToEnd();
            }

            return Data;
        }

        private async Task<string> ReadFileAsync()
        {
            string path = "dosya.txt";
            string Data = string.Empty;

            using (StreamReader sr = new StreamReader(path))
            {
                Task<string> myData = sr.ReadToEndAsync();

                // Burda dataya bağlı olmiyan işlemlerimizi yaparız şuanda data çekiliyor
                // metot asenkron olduğundan o işlemini yaparken biz farklı işlemler yaparız 

                Data = await myData;// bu data artık bana lazım bunu bana verene kadar bekle
           
            return Data;
            }
        }


        private Task<string> ReadFileAsync2()
        {
            string path = "dosya.txt";
            string Data = string.Empty;
            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEndAsync();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }



}
