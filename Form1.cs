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
	public partial class Form1 : Form
	{
		MainMenu main_menu;
		MenuItem file_item;
		MenuItem settings_item;
		MenuItem info_item;

		MenuItem new_file;
		MenuItem load_file;
		MenuItem save_file;
		MenuItem exit;
		public Form1()
		{
			InitializeComponent();
			new_file = new MenuItem("Создать", new EventHandler(CreateNewProject));
			load_file = new MenuItem("Открыть", new EventHandler(LoadProject));
			save_file = new MenuItem("Сохранить", new EventHandler(SaveProject));
			exit = new MenuItem("Выход", new EventHandler(ExitFromApp));
			file_item = new MenuItem("Файл", new MenuItem[] { new_file, load_file, save_file, exit });
			settings_item = new MenuItem("Настройки", new EventHandler(AppSettings));
			info_item = new MenuItem("Информация", new EventHandler(AppInfo));
			main_menu = new MainMenu(new MenuItem[] { file_item, settings_item, info_item });
			this.Menu = main_menu;
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
			public static string data;
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
				data = name + " " + Convert.ToString(x) + " " + Convert.ToString(y) + " " + Convert.ToString(z) + " " + Convert.ToString(weight) + " " + material + " "
					+ Convert.ToString(de) + " " + Convert.ToString(kt) + " " + Convert.ToString(fp) + " " + Convert.ToString(d) + " " + Convert.ToString(d0) + " "
					+ Convert.ToString(D);
			}
			public static string dt()
			{
				return Project.data;
			}
		}
		delegate string ToGetConcastString();
		static Project Sardor;
		void CreateNewProject(object sr, EventArgs e)
		{
			Form2 LoadData = new Form2();
			LoadData.ShowDialog();
		}
		void LoadProject(object sr, EventArgs e)
		{
			Form3 OpenProject = new Form3();
			OpenProject.ShowDialog();
		}
		void SaveProject(object sr, EventArgs e)
		{
			string ffolder = @"C:\Users\Admin\Desktop\project.txt";
			ToGetConcastString GetConcastString = new ToGetConcastString(Project.dt);
			string data = GetConcastString();
			try
			{
				using(StreamWriter prf = new StreamWriter(ffolder, true, System.Text.Encoding.Default))
				{
					prf.WriteLine(data);
				}
			}
			catch
			{

			}
		}
		void ExitFromApp(object sr, EventArgs e)
		{

		}
		void AppSettings(object sr, EventArgs e)
		{

		}
		void AppInfo(object sr, EventArgs e)
		{

		}
		public static void ShowData(
			string name, double x, double y, double z, double weight,
			string material, double de, int kt, double fp, double d,
			double d0, double D
		)
		{
			Form1 project = new Form1();
			project.textBox1.Text = name;
			project.textBox2.Text = Convert.ToString(x);
			project.textBox4.Text = Convert.ToString(y);
			project.textBox3.Text = Convert.ToString(z);
			project.textBox8.Text = Convert.ToString(weight);
			project.textBox7.Text = material;
			project.textBox6.Text = Convert.ToString(de);
			project.textBox5.Text = Convert.ToString(kt);
			project.textBox12.Text = Convert.ToString(fp);
			project.textBox11.Text = Convert.ToString(d);
			project.textBox10.Text = Convert.ToString(d0);
			project.textBox9.Text = Convert.ToString(D);
			Sardor = new Project(
				name, x, y, z, weight, material,
				de, kt, fp, d, d0, D
			);
			project.ShowDialog();
		}
		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
