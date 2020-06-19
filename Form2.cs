using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}
		public class PLATA
		{
			public string name;
			public double x, y, z, weight;
			public string material;
			public double de;
			public int kt;
			double B;
			double plot;
			double m;
			double Kv;
			double Km;
			double f1;
			double f2;
			public double fp = 0;
			double p;
			double nmax;
			bool VP;
			double dno;
			public double d;
			double O;
			public double d0;
			double dvo;
			public double D;
			double gp;
			double tvo;
			double dtr = 0;
			double tno;
			double TD;
			double Td;
			public PLATA(string name, double x, double y, double z, double weight, string material, double de, int kt)
			{
				this.name = name;
				this.x = x;
				this.y = y;
				this.z = z;
				this.weight = weight;
				this.material = material;
				this.de = de;
				this.kt = kt;
				switch (x / y)
				{
					case 0.25:
						B = 9;
						break;
					case 0.5: 
						B = 11; 
						break;
					case 1: 
						B = 18; 
						break;
					case 1.5: 
						B = 28; 
						break;
					case 2: 
						B = 43; 
						break;
					case 2.5: 
						B = 62; 
						break;
					case 3: 
						B = 85; 
						break;
					case 4: 
						B = 144; 
						break;
					default: 
						break;
				}
				if (material.Equals("Молибден"))
				{
					plot = 10.22;
					Km = 1.10;
				}
				else if (material.Equals("Фенольная_смола"))
				{
					plot = 7.82;
					Km = 0.47;
				}
				else if (material.Equals("Титан"))
				{
					plot = 4.5;
					Km = 0.93;
				}
				else if (material.Equals("Алюминиевые_сплавы"))
				{
					plot = 2.7;
					Km = 0.95;
				}
				else if (material.Equals("Гетинакс"))
				{
					plot = 2.47;
					Km = 0.54;
				}
				else if (material.Equals("Эпоксидная_смола"))
				{
					plot = 1.2;
					Km = 0.52;
				}
				f1 = Km * Kv * B * z * 10000 / (x * x);
				p = f1 * 0.8 / 9.8;
				nmax = (f1 / 9.8) - B;
				f2 = Math.Pow(p*9.8*nmax/(3*y),2/3);
				VP = f1 > f2;
				if(VP==true)
					fp = f2 * 100 / f1;
				switch(kt)
				{
					case 1: dno = -0.15; O = 0.4; dvo = 0.05; gp = 0.3; tvo = 0.25; tno = -0.2; TD = 0.25; Td = 0.4; break;
					case 2: dno = -0.15; O = 0.4; dvo = 0.05; gp = 0.2; tvo = 0.15; tno = -0.1; TD = 0.2; Td = 0.3; break;
					case 3: dno = -0.1; O = 0.33; dvo = 0; gp = 0.1; tvo = 0.10; tno = -0.1; TD = 0.1; Td = 0.2; break;
					case 4: dno = -0.1; O = 0.25; dvo = 0; gp = 0.5; tvo = 0.05; tno = -0.05; TD = 0.08; Td = 0.15; break;
					case 5: dno = -0.075; O = 0.2; dvo = 0; gp = 0.025; tvo = 0.03; tno = -0.03; TD = 0.08; Td = 0.08; break;
				}
				d = dno + de + 0.4;
				d0 = z * O;
				D = d + dvo + 2 * gp + tvo + 2 * dtr + Math.Pow(Td*Td + TD*TD + tno*tno, 0.5);
			}
		}
		private void label9_Click(object sender, EventArgs e)
		{

		}
		delegate void PrintProjectData(string name, double x, double y, double z, double weight, string material, double de, int kt, double fp, double d, double d0, double D);
		private void button1_Click(object sender, EventArgs e)
		{
			PrintProjectData PrintData = new PrintProjectData(Form1.ShowData);
			PLATA plata;
			try
			{
				Hide();
				plata = new PLATA(textBox1.Text, Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox7.Text), Convert.ToDouble(textBox5.Text), Convert.ToDouble(textBox4.Text), textBox6.Text, Convert.ToDouble(textBox3.Text), Convert.ToInt32(textBox8.Text));
				PrintData(plata.name, plata.x, plata.y, plata.z, plata.weight, plata.material, plata.de, plata.kt, plata.fp, plata.d, plata.d0, plata.D);
			}
			catch
			{
				MessageBox.Show("Данные введены неправильно");
			}
		}

		private void Form2_Load(object sender, EventArgs e)
		{

		}
	}
}
