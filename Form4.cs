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
	public partial class Form4 : Form
	{
		public static Font font;

		public static void SetFont(Font newfont)
		{
			font = newfont;
		}
		public Form4()
		{
			InitializeComponent();
			this.Font = font;

			label2.Text = "Автором данной программы является:\n" +
				"выпускник 2020 года КНИТУ-КАИ\n" +
				"Давлятшин Рамис Валиянович\n" +
				"Дата рождение - 29.04.1996.\n" +
				"Данная программа преднзначеная\n " +
				"для расчета конструкторских параметров:\n" +
				"Параметры для расчета вибропрочности  - \n" +
				"рассчитывается коэффициент вибропрочности\n" +
				"Расчет диаметра монтажных отверстий - \n" +
				"расcчитывается номинальный коэффициент диаметра\n" +
				"монтажного отверстия и минимальный диаметр \n" +
				"металлизированного монтажного отверстия\n" +
				"Расчет диаметра контактных площадок - \n" +
				"рассчитывается наименьшее минимальное \n" +
				"значение контактных площадок\n";
		}

		private void Form4_Paint(object sender, PaintEventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
