using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SRB
{
	/// <summary>
	/// Логика взаимодействия для Pati.xaml
	/// </summary>
	public partial class Pati : Window
	{
		Specialist spec = new Specialist();
		public Pati()
		{
			InitializeComponent();
		}
		private void exit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
			Authorization authorization = new Authorization();
			authorization.Show();
		}

		private void fluographyOk_Click(object sender, RoutedEventArgs e)
		{
			Phluorography phu = new Phluorography();
			phu.Show();
			this.Close();
        }
    }
}
