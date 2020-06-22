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
	public partial class Form5 : Form
	{
		public Form5()
		{
			InitializeComponent();

			comboBox1.Items.Add("Arial");
			comboBox1.Items.Add("Arial Black");
			comboBox1.Items.Add("Comic Sans MS");
			comboBox1.Items.Add("Courier New");
			comboBox1.Items.Add("Franklin Gothic Medium");
			comboBox1.Items.Add("Georgia");
			comboBox1.Items.Add("Impact");
			comboBox1.Items.Add("Lucida Console");
			comboBox1.Items.Add("Lucida Sans Unicode");
			comboBox1.Items.Add("Microsoft Sans Serif");
			comboBox1.Items.Add("Palatino Linotype");
			comboBox1.Items.Add("Sylfaen");
			comboBox1.Items.Add("Tahoma");
			comboBox1.Items.Add("Times New Romana");
			comboBox1.Items.Add("Trebuchet MS");
			comboBox1.Items.Add("Verdana");

			for (int i = 0; i < 26; i++)
			{
				comboBox2.Items.Add(i.ToString());
			}

			comboBox1.Text = "Arial";
			comboBox2.Text = "12";
		}

		Font selectedfont;

		private void button1_Click(object sender, EventArgs e)
		{
			selectedfont = new Font(comboBox1.SelectedItem.ToString(), Convert.ToInt32(comboBox2.SelectedItem.ToString()));
			this.Font = selectedfont;
		}
		delegate void OnChangeFont(Font font);
		private void button2_Click(object sender, EventArgs e)
		{
			OnChangeFont ChangeFont = new OnChangeFont(Form1.SetFont);
			ChangeFont += new OnChangeFont(Form2.SetFont);
			ChangeFont += new OnChangeFont(Form3.SetFont);
			ChangeFont += new OnChangeFont(Form4.SetFont);
			ChangeFont(this.Font);
			Close();
		}
	}
}
