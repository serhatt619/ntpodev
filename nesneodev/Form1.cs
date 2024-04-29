using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace nesneodev
{
    
    public partial class Form1 : Form
    {
        public string FirstString;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double girilensayi = double.Parse(textBox1.Text);
            FirstString = textBox1.Text;
            double mutlakDeger = MathSinifi.MutlakDeger(girilensayi);
            textBox1.Text = mutlakDeger.ToString(); 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double girilensayi=double.Parse(textBox1.Text);
            FirstString = textBox1.Text;    
            double deger=MathSinifi.SinDegeri(girilensayi); 
            textBox1.Text = deger.ToString();   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double girilensayi=double.Parse(textBox1.Text);
            FirstString= textBox1.Text; 
            double karekok=MathSinifi.KareKok(girilensayi);
            textBox1.Text = karekok.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double girilensayi= double.Parse(textBox1.Text);    
            FirstString= textBox1.Text;
            double deger=MathSinifi.CosDegeri(girilensayi);
            textBox1.Text = deger.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string metin = textBox1.Text;
            FirstString = textBox1.Text;
            string[] parcalar = metin.Split(',');
            double ilksayi = double.Parse(parcalar[0]);
            double ikincisayi = double.Parse(parcalar[1]);
            double maks=MathSinifi.MaksBul(ilksayi, ikincisayi);
            textBox1 .Text = maks.ToString();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(FirstString == null)
            {
                textBox1.Text = "Sayı Girin";
            }
            else
            {
                textBox1.Text = FirstString;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
           double deger1=double.Parse(textBox2.Text);
           double deger2=double.Parse(textBox3.Text);
            if (radioButton1.Checked)
            {
                MathSinifi.CizSinGrafigi(deger1, deger2);
            }
            if(radioButton2.Checked) {
                MathSinifi.CizCosGrafigi(deger1,deger2);
            }
        }
    }
    public class MathSinifi
    {
        public static double MutlakDeger(double sayi)
        {
            if (sayi < 0)
                return -sayi;
            else
                return sayi;
        }
        public static double MaksBul(double sayi1, double sayi2)
        {
            if (sayi1 > sayi2)
                return sayi1;
            else
                return sayi2;
        }
        public static double KareKok(double sayi1)
        {
            if (sayi1 < 0)
            {
                MessageBox.Show("Negatif sayıların kökü bulunmaz");
                Environment.Exit(0);    
            }

            double tahmin = sayi1 / 2;
            double eskiTahmin = 0;

            while (tahmin != eskiTahmin)
            {
                eskiTahmin = tahmin;
                tahmin = (tahmin + sayi1 / tahmin) / 2;
            }

            return tahmin;
        }
        public static double SinDegeri(double derece)
        {
            double radyan = derece * Math.PI / 180;
            double sin_degeri=Math.Sin(radyan); 
            return sin_degeri;  
        }
        public static double CosDegeri(double derece)
        {
            double radyan = derece * Math.PI / 180;
            double cos_degeri=Math.Cos(radyan);
            return cos_degeri;
        }
        public static void CizSinGrafigi(double baslangic, double bitis)
        {
            Chart grafik = new Chart();
            ChartArea grafikAlani = new ChartArea();
            grafik.ChartAreas.Add(grafikAlani);

            Series seri = new Series();
            seri.ChartType = SeriesChartType.Line;

            for (double x = baslangic; x <= bitis; x += 0.1)
            {
                seri.Points.AddXY(x, Math.Sin(x));
            }

            grafik.Series.Add(seri);
            grafikAlani.AxisX.Minimum = baslangic;
            grafikAlani.AxisX.Maximum = bitis;
            grafikAlani.AxisY.Minimum = -1;
            grafikAlani.AxisY.Maximum = 1;

            grafik.Titles.Add("Sinüs Grafiği");

            grafik.Dock = DockStyle.Fill;
            Form form = new Form();
            form.Text = "Sinüs Grafiği";
            form.Controls.Add(grafik);

            form.Show();
        }
        public static void CizCosGrafigi(double baslangic, double bitis)
        {
            Chart grafik = new Chart();
            ChartArea grafikAlani = new ChartArea();
            grafik.ChartAreas.Add(grafikAlani);

            Series seri = new Series();
            seri.ChartType = SeriesChartType.Line;

            for (double x = baslangic; x <= bitis; x += 0.1)
            {
                seri.Points.AddXY(x, Math.Cos(x));
            }

            grafik.Series.Add(seri);
            grafikAlani.AxisX.Minimum = baslangic;
            grafikAlani.AxisX.Maximum = bitis;
            grafikAlani.AxisY.Minimum = -1;
            grafikAlani.AxisY.Maximum = 1;

            grafik.Titles.Add("Kosinüs Grafiği");

            grafik.Dock = DockStyle.Fill;
            Form form = new Form();
            form.Text = "Kosinüs Grafiği";
            form.Controls.Add(grafik);

            form.Show();
        }

    }
}
