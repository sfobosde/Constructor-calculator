using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
			this.Font = font;

			myConnection = new OleDbConnection(connectString);
			myConnection.Open();
		}

		public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Params.mdb;";
		private static OleDbConnection myConnection;

		public static Font font;

		public static void SetFont(Font newfont)
		{
			font = newfont;
		}
		public class PLATA
		{
			public string name;
			public double x, y, z, weight;
			public string material;
			public double de;
			public int kt;
			double xy;
			double B = 0;
			double plot = 0;
			double m;
			double Kv;
			double Km = 0;
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
				this.xy = x / y;

				string query = "SELECT relat, B FROM XYrelat";
				OleDbCommand ToGetXYRelCmd = new OleDbCommand(query, myConnection);
				OleDbDataReader reader1 = ToGetXYRelCmd.ExecuteReader();

				while ((reader1.Read()) && (reader1[0].Equals(xy.ToString()) == false)) ;
				B = Convert.ToDouble(reader1[1].ToString());

				query = "SELECT material, plot, km FROM MaterialData";
				OleDbCommand ToGetMaterData = new OleDbCommand(query, myConnection);
				OleDbDataReader reader2 = ToGetMaterData.ExecuteReader();

				while ((reader2.Read()) && (reader2[0].Equals(material) == false));
				plot = Convert.ToDouble(reader2[1].ToString());
				Km = Convert.ToDouble(reader2[2].ToString());

				Kv = 1 / Math.Pow((1+(weight/(x*y*z*plot))),0.5);
				f1 = Km * Kv * B * z * 10000 / (x * x);
				p = f1 * 0.8 / 9.8;
				nmax = (f1 / 9.8) - B;
				f2 = Math.Pow(p*9.8*nmax/(3*y), 0.66);
				VP = f1 > f2;
				if(VP==true)
					fp = f2 * 100 / f1;

				query = "SELECT kt, dno, O, dvo, gp, tvo, tno, TD1,TD2 FROM KTData";
				OleDbCommand ToGetKTData = new OleDbCommand(query, myConnection);
				OleDbDataReader reader3 = ToGetKTData.ExecuteReader();

				while ((reader3.Read()) && (reader3[0].Equals(kt.ToString()) == false));
				dno =	Convert.ToDouble(reader3[1].ToString());
				O =		Convert.ToDouble(reader3[2].ToString());
				dvo =	Convert.ToDouble(reader3[3].ToString());
				gp =	Convert.ToDouble(reader3[4].ToString());
				tvo =	Convert.ToDouble(reader3[5].ToString());
				tno =	Convert.ToDouble(reader3[6].ToString());
				TD =	Convert.ToDouble(reader3[7].ToString());
				Td =	Convert.ToDouble(reader3[8].ToString());

				d = dno + de + 0.4;
				d0 = z * O;
				D = d + dvo + 2 * gp + tvo + 2 * dtr + Math.Pow(Td*Td + TD*TD + tno*tno, 0.5);
			}
		}

		delegate void PrintProjectData(string name, string x, string y, 
									   string z, string weight, string material, 
									   string de, string kt, string fp, 
									   string d, string d0, string D);
		private void button1_Click(object sender, EventArgs e)
		{
			PrintProjectData PrintData = new PrintProjectData(Form1.ShowData);
			PLATA plata;
			try
			{
				Hide();

				plata = new PLATA(textBox1.Text, Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox7.Text), 
					Convert.ToDouble(textBox5.Text), Convert.ToDouble(textBox4.Text), textBox6.Text, 
					Convert.ToDouble(textBox3.Text), Convert.ToInt32(textBox8.Text));

				PrintData(plata.name, plata.x.ToString(), plata.y.ToString(), plata.z.ToString(), 
					plata.weight.ToString(), plata.material, plata.de.ToString(), plata.kt.ToString(), 
					plata.fp.ToString(), plata.d.ToString(), plata.d0.ToString(), plata.D.ToString());
			}
			catch
			{
				MessageBox.Show("Данные введены неправильно");
			}
		}

		private void Form2_FormClosing(object sender, FormClosingEventArgs e)
		{
			myConnection.Close();
		}
	}
}
