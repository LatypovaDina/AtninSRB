using Microsoft.SqlServer.Server;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SRB
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class Authorization : Window
	{
		SRBContext db;
		public Authorization()
		{
			InitializeComponent();
			db = new SRBContext();
		}

		private void logIn_Click(object sender, RoutedEventArgs e)
		{
			using (SRBContext db = new SRBContext())
			{
				foreach (User user in db.Users)
				{
					if (user.login == login.Text)
					{
						if (user.password == password.Text)
						{
							MessageBox.Show("Успешный вход");


							if (user.role == "admin")
							{
								Admin admin = new Admin();
								admin.Show();
								this.Close();
							}

							if (user.role == "spets")
							{
								Specialist specialist = new Specialist();
								specialist.Show();
								this.Close();
							}
						}
						else
						{
							MessageBox.Show("Пароль неверный");
							return;
						}
					}
					
				}
			}
		}
	}
}
