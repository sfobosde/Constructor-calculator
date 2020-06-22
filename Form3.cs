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
	public partial class Form3 : Form
	{
		public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Projects.mdb;";
		private OleDbConnection myConnection;
		public Form3()
		{
			InitializeComponent();
			myConnection = new OleDbConnection(connectString);
			myConnection.Open();

			string query = "SELECT name FROM Projects ORDER BY p_id ";

			try
			{
				OleDbCommand command = new OleDbCommand(query, myConnection);

				OleDbDataReader reader = command.ExecuteReader();

				listBox1.Items.Clear();

				while (reader.Read())
				{
					listBox1.Items.Add(reader[0].ToString());
				}
			}
			catch
			{
				MessageBox.Show("Отсутсвует база данных проектов");
			}
		}

		static string preview;

		private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int index = this.listBox1.IndexFromPoint(e.Location);
			if (index != System.Windows.Forms.ListBox.NoMatches)
				textBox2.Text = this.listBox1.Text;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			//предварительный просмотр
			try
			{
				string query = "SELECT name, x, y, z, weight, material FROM Projects ORDER BY p_id";

				OleDbCommand command = new OleDbCommand(query, myConnection);

				OleDbDataReader reader = command.ExecuteReader();

				listBox2.Items.Clear();

				while ((reader.Read()) && (reader[0].Equals(textBox2.Text) == false));

				listBox2.Items.Add("Название:" + reader[0].ToString());
				listBox2.Items.Add("Размеры:" + reader[1].ToString() + "x" + reader[2].ToString() + "x" + reader[3].ToString());
				listBox2.Items.Add("Масса:" + reader[4].ToString());
				listBox2.Items.Add("Материал основания:" + reader[5].ToString());
			}
			catch
			{
				MessageBox.Show("Выберите проект");
			}
		}
		delegate void PrintProjectData(string name, string x, string y, string z, 
									   string weight, string material, string de, 
									   string kt, string fp, string d, string d0, string D);
		private void button4_Click(object sender, EventArgs e)
		{
			//кнопка открыть
			string query = "SELECT name, x, y, z, weight, material, de, kt, fp, d, d0, Diam FROM Projects ORDER BY p_id";

			OleDbCommand command = new OleDbCommand(query, myConnection);

			OleDbDataReader reader = command.ExecuteReader();

			while ((reader.Read()) && (reader[0].Equals(textBox2.Text) == false)) ;

			PrintProjectData PrintData = new PrintProjectData(Form1.ShowData);
			Hide();
			PrintData(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
				reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(),
				reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), reader[11].ToString());
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//КНОПКА УДАЛИТЬ
			string query = "DELETE FROM Projects WHERE name = '" + textBox2.Text + "'";

			OleDbCommand command = new OleDbCommand(query, myConnection);

			command.ExecuteNonQuery();
			

			OleDbDataReader reader = command.ExecuteReader();

			listBox1.Items.Clear();
		}

		private void Form3_FormClosing(object sender, FormClosingEventArgs e)
		{
			myConnection.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			//кнопка обновить
			string query = "SELECT name FROM Projects ORDER BY p_id ";

			OleDbCommand command = new OleDbCommand(query, myConnection);

			OleDbDataReader reader = command.ExecuteReader();

			listBox1.Items.Clear();

			while (reader.Read())
			{
				listBox1.Items.Add(reader[0].ToString());
			}
		}
	}
}
