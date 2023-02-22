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
using System.Xml.Linq;

namespace SRB
{
	/// <summary>
	/// Логика взаимодействия для Admin.xaml
	/// </summary>
	public partial class Admin : Window
	{
		private Patients choosenPatient;
		private User choosenUser;
		SRBContext db = new SRBContext();
		public Admin()
		{
			InitializeComponent();
			patientObnov();
			spetsObnov();
		}
		private void patientObnov()
		{
			patientsList.Items.Clear();
			foreach (var patient in db.Patient)
			{
				patientsList.Items.Add(patient.Surname);
			}
		}
		private void spetsObnov()
		{
			spetsList.Items.Clear();
			foreach (var user in db.Users)
			{
				spetsList.Items.Add(user.login);
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			TextBox[] textBoxes = { login, password, role };
			foreach (var textBox in textBoxes)
			{
				if (String.IsNullOrEmpty(textBox.Text))
				{
					MessageBox.Show("Введите что нибудь");
					return;
				}
			}
			var newUser = new User()
			{
				login = login.Text,
				password = password.Text,
				role = role.Text
			};
			db.Users.Add(newUser);
			db.SaveChanges();
			MessageBox.Show("Пациент добавлен");
			spetsObnov();
		}

		private void deleteSpets_Click(object sender, RoutedEventArgs e)
		{
			

			if (choosenUser == null)
			{
				MessageBox.Show("Выберите того, кого хотите уволить");
				return;
			}

			db.Users.Remove(choosenUser);
			db.SaveChanges();
			MessageBox.Show("уволен!!!");
			spetsObnov();
		}

		private void spetsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				choosenUser = (User)db.Users.Where(x => x.login == spetsList.SelectedItem.ToString()).First();
			}
			catch
			{
				return;
			}
			login.Text = choosenUser.login;	
			password.Text = choosenUser?.password;
			role.Text = choosenUser.role;
			
		}

		private void patientsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void exit_Click(object sender, RoutedEventArgs e)
		{
			Authorization auth = new Authorization();
			auth.Show();
			this.Close();
		}

		private void newPatient_Click(object sender, RoutedEventArgs e)
		{
			if (choosenPatient == null)
			{
				MessageBox.Show("Выберите того, кого хотите уволить");
				return;
			}

			db.Patient.Remove(choosenPatient);
			db.SaveChanges();
			MessageBox.Show("пациент удален");
			spetsObnov();
		}

		private void otchet_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Отчета нет увы и ах");
		}
	}
}
