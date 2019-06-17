using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace PansiyonKayıt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-LQ9NQVA;Initial Catalog=panssiyon;Integrated Security=True");

        private void verilerigoster()
        {
            listView1.Items.Clear();
            SqlCommand komut = new SqlCommand("Select *from musteriler", baglan);
            baglan.Open();
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["GTarih"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Hesap"].ToString());
                ekle.SubItems.Add(oku["CTarih"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();




        }


      
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into musteriler (id,Ad,Soyad,OdaNo,GTarih,Telefon,Hesap,CTarih) values ('"
                +textBox1.Text.ToString()+ "', '"+textBox2.Text.ToString()+"','"+textBox3.Text.ToString()+"','"
                +textBox4.Text.ToString()+"', '"+dateTimePicker1.Text.ToString()+"','"+textBox6.Text.ToString()+"', '"
                +textBox7.Text.ToString()+"', '"+dateTimePicker2.Text.ToString()+"')",baglan);

            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
           
        }

        int id = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("delete from musteriler where id =(" + id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster();
           

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id= int.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            dateTimePicker1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox7.Text = listView1.SelectedItems[0].SubItems[6].Text;
            dateTimePicker2.Text = listView1.SelectedItems[0].SubItems[7].Text;



           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Update musteriler  set  id ='" + textBox1.Text.ToString() + "', Ad='"
               + textBox2.Text.ToString() + "',Soyad='" + textBox3.Text.ToString() + "', OdaNo='" + textBox4.Text.ToString() + "',GTarih='"
               + dateTimePicker1.Text.ToString() + "',  Telefon='" + textBox6.Text.ToString() + "', Hesap='" + textBox7.Text.ToString() + "', CTarih='"
               + dateTimePicker2.Text.ToString() + "'where id =  "+id+"", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster();



        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            SqlCommand komut = new SqlCommand("Select *from musteriler where Ad like '%" + textBox5.Text +"%'", baglan);
            baglan.Open();
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["GTarih"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Hesap"].ToString());
                ekle.SubItems.Add(oku["CTarih"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();

        }
    }
}
