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
using System.Data.OleDb;

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

		public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Projects.mdb;";
		private OleDbConnection myConnection;

		public Form1()
		{
			InitializeComponent();

			myConnection = new OleDbConnection(connectString);
			myConnection.Open();

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
			string query = "INSERT INTO Projects (name, x, y, z, weight, material, de, kt, fp, d, d0, Diam) VALUES ";
			string data = "('" + textBox1.Text	+	"', '"	+ textBox2.Text		+	"', '" + textBox4.Text	+	"', '" 
							   + textBox3.Text	+	"', '"	+ textBox8.Text		+	"', '" + textBox7.Text	+	"', '"
							   + textBox6.Text	+	"', '"	+ textBox5.Text		+	"', '" + textBox12.Text +	"', '" 
							   + textBox11.Text +	"', '"	+ textBox10.Text	+	"', '" + textBox9.Text 	+	"')";
			query = query + data;

			try
			{
				OleDbCommand command = new OleDbCommand(query, myConnection);
				command.ExecuteNonQuery();
			}
			catch
			{
				MessageBox.Show("Отсутвует база данных");
			}
		}
		void ExitFromApp(object sr, EventArgs e)
		{
			this.Close();
		}
		void AppSettings(object sr, EventArgs e)
		{

		}
		void AppInfo(object sr, EventArgs e)
		{
			Form4 InfPage = new Form4();
			InfPage.ShowDialog();
		}
		public static void ShowData(
			string name, string x, string y, string z, string weight,
			string material, string de, string kt, string fp, string d,
			string d0, string D
		)
		{
			Form1 project = new Form1();
			project.textBox1.Text = name;
			project.textBox2.Text = x;
			project.textBox4.Text = y;
			project.textBox3.Text = z;
			project.textBox8.Text = weight;
			project.textBox7.Text = material;
			project.textBox6.Text = de;
			project.textBox5.Text = kt;
			project.textBox12.Text = fp;
			project.textBox11.Text = d;
			project.textBox10.Text = d0;
			project.textBox9.Text = D;
			project.ShowDialog();
		}
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			myConnection.Close();
		}
	}
}
