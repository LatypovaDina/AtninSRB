using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRB
{
	public class Patients
	{
		public int ID { get; set; }
		public string LastName { get; set; }
		public string Surname { get; set; }
		public string Patronymic { get; set; }
		public string DateOfBirth { get; set; }
		public string Info { get; set; }
		public int Enp { get; set; }
		public int Factor_ID { get; set; }
		public int Kontingent_ID { get; set; }
		public int Selo_ID { get; set; }
		public int Street_ID { get; set; }

		public Patients() { }
		public Patients(string lastName, string surname, string patronymic, string dateOfBirth, string info, int enp)
		{
			LastName = lastName;
			Surname = surname;
			Patronymic = patronymic;
			DateOfBirth = dateOfBirth;
			Info = info;
			Enp = enp;
		}

		//public override string ToString()
		//{
		//	return Surname;
		//}
	}
}
