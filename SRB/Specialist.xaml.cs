using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
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
	/// Логика взаимодействия для Specialist.xaml
	/// </summary>
	public partial class Specialist : Window
	{
		private Patients choosenPatient;
		SRBContext db = new SRBContext();
		public Specialist()
		{
			InitializeComponent();
			ObnovList();
		}
		private void ObnovList()
		{
			patientsList.Items.Clear();
			foreach (var patient in db.Patient)
			{
				patientsList.Items.Add(patient.Surname);
			}
		}
		private void spisok_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
		{

		}

		private void spisok_Selected(object sender, RoutedEventArgs e)
		{
			
		}

		private void spisok_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void patientsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				choosenPatient = (Patients)db.Patient.Where(x => x.Surname == patientsList.SelectedItem.ToString()).First();
			}
			catch
			{
				return;
			}
			lastName.Text = choosenPatient.Surname;
			name.Text = choosenPatient.LastName;
			patronymic.Text = choosenPatient.Patronymic;
			dateOfBirth.Text = choosenPatient.DateOfBirth;
			enp.Text = choosenPatient.Enp.ToString();
			info.Text = choosenPatient.Info;

		}

		private void newPatient_Click(object sender, RoutedEventArgs e)
		{
			TextBox[] textBoxes = { lastName, name, patronymic, dateOfBirth, enp, info };
			foreach (var textBox in textBoxes)
			{
				if (String.IsNullOrEmpty(textBox.Text))
				{
					MessageBox.Show("Введите текст");
					return;
				}
			}
			var newPatient = new Patients()
			{
				LastName = name.Text,
				Surname = lastName.Text,
				Patronymic = patronymic.Text,
				DateOfBirth = dateOfBirth.Text,
				Info = info.Text,
				Enp = Convert.ToInt32(enp.Text)
			};
			db.Patient.Add(newPatient);
			db.SaveChanges();
			MessageBox.Show("Пациент добавлен");
			ObnovList();
		}

		private void exit_Click(object sender, RoutedEventArgs e)
		{
			Authorization aut = new Authorization();
			aut.Show();
			this.Close();
		}

		private void savePatient_Click(object sender, RoutedEventArgs e)
		{

		}

		private void fluographyOk_Click(object sender, RoutedEventArgs e)
		{
			Phluorography phluorography = new Phluorography();
			phluorography.Show();
		}

		private void savePatient_Click_1(object sender, RoutedEventArgs e)
		{
			
			if (choosenPatient == null)
			{
				MessageBox.Show("Выберите пациента!");
				return;
			}
			choosenPatient.Surname = lastName.Text;
			choosenPatient.LastName = name.Text;
			choosenPatient.Patronymic = patronymic.Text;
			choosenPatient.DateOfBirth = dateOfBirth.Text;
			choosenPatient.Info= info.Text;
			choosenPatient.Enp = int.Parse(enp.Text);
			db.Patient.Add(choosenPatient);
			db.SaveChanges();
			MessageBox.Show("Данные о пациенте успешно изменены");
			ObnovList();
		}
	}
}
