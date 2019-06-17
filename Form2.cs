using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PansiyonKayıt
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Giriş_Click(object sender, EventArgs e)
        {
           if(textBox1.Text=="Admin" && textBox2.Text == "aaaaa")
            {
                Form1 form = new Form1();
                form.Show();
                this.Hide();
            }

           else
            {
                MessageBox.Show("KullanıcAdı veya Parola Hatalı");
            }
        }
    }
}
