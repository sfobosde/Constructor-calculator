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

namespace WindowsFormsApp1
{
	public partial class Form3 : Form
	{
		public Form3()
		{
			InitializeComponent(); 
			string ffolder = @"C:\Users\Admin\Desktop\project.txt";
			using (StreamReader prf = new StreamReader(ffolder, System.Text.Encoding.Default))
			{
				string line;
				while((line = prf.ReadLine()) != null)
				{
					string[] dt = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
					try
					{
						listBox1.Items.Add(dt[0]);
						totalprojects++;
					}
					catch
					{

					}
				}
			}
		}
		class Project
		{
			public string name;
			public double x;
			public double y;
			public double z;
			public double weight;
			public string material;
			public double de;
			public int kt;
			public double fp;
			public double d;
			public double d0;
			public double D;
			public Project(
				string name, double x, double y, double z, double weight,
				string material, double de, int kt, double fp, double d,
				double d0, double D
			)
			{
				this.name = name;
				this.x = x;
				this.y = y;
				this.z = z;
				this.weight = weight;
				this.material = material;
				this.de = de;
				this.kt = kt;
				this.fp = fp;
				this.d = d;
				this.d0 = d0;
				this.D = D;
			}
		}
		Project Selected;
		static string preview;
		static string sn;
		static int totalprojects = 0;
		private void Form3_Load(object sender, EventArgs e)
		{

		}

		private void listBox1_DoubleClick(object sender, EventArgs e)
		{

		}

		private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int index = this.listBox1.IndexFromPoint(e.Location);
			if (index != System.Windows.Forms.ListBox.NoMatches)
				textBox2.Text = this.listBox1.Text;

			string ffolder = @"C:\Users\Admin\Desktop\project.txt";
			using (StreamReader prf = new StreamReader(ffolder, System.Text.Encoding.Default))
			{
				string line;
				while ((line = prf.ReadLine()) != null)
				{
					string[] dt = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
					try
					{
						if (dt[0].Equals(textBox2.Text))
						{
							Selected = new Project(dt[0], Convert.ToDouble(dt[1]), Convert.ToDouble(dt[2]), Convert.ToDouble(dt[3]),
								Convert.ToDouble(dt[4]), dt[5], Convert.ToDouble(dt[6]), Convert.ToInt32(dt[7]), Convert.ToDouble(dt[8]),
								Convert.ToDouble(dt[9]), Convert.ToDouble(dt[10]), Convert.ToDouble(dt[11]));
							preview = "Название:" + dt[0] + " Размеры:" + dt[1] + "x" + dt[2] + "x" + dt[3] + " Масса:" + dt[4] + " Материал основания:" + dt[5];
						}
					}
					catch
					{
						textBox2.Text = "";

					}
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			textBox3.Text = preview;
		}
		delegate void PrintProjectData(string name, double x, double y, double z, double weight, string material, double de, int kt, double fp, double d, double d0, double D);
		private void button4_Click(object sender, EventArgs e)
		{
			try
			{
				PrintProjectData PrintData = new PrintProjectData(Form1.ShowData);
				Hide();
				PrintData(Selected.name, Selected.x, Selected.y, Selected.z, 
					Selected.weight,Selected.material, Selected.de, Selected.kt, 
					Selected.fp, Selected.d, Selected.d0, Selected.D);
			}
			catch
			{
				MessageBox.Show("Выберите проект");
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string[] projects = new string[totalprojects];
			string ffolder = @"C:\Users\Admin\Desktop\project.txt";
			using (StreamReader prf = new StreamReader(ffolder, System.Text.Encoding.Default))
			{
				string line;
				int i = 0;
				while ((line = prf.ReadLine()) != null)
				{
					string[] dt = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
					if (dt[0].Equals(textBox2.Text) == false)
						projects[i] = line;
					i++;
				}
			}
			try
			{
				using (StreamWriter prf = new StreamWriter(ffolder, false, System.Text.Encoding.Default))
				{
					int i = 0;
					prf.WriteLine(projects[i]);
				}
			}
			catch
			{

			}
			Invalidate();
		}

		private void listBox1_Click(object sender, EventArgs e)
		{

		}

		private void textBox2_MouseClick(object sender, MouseEventArgs e)
		{
			int index = this.listBox1.IndexFromPoint(e.Location);
			if (index != System.Windows.Forms.ListBox.NoMatches)
				sn = this.listBox1.Text;
		}
	}
}
