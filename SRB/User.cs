using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRB
{
	/// <summary>
	/// класс модели
	/// </summary>
	public class User
	{
		public int ID { get; set; }
		public string login { get; set; }
		public string password { get; set; }
		public string role { get; set; }
		public User() { }
		/// <summary>
		/// установка параметров
		/// </summary>
		/// <param name="login"></param>
		/// <param name="password"></param>
		public User(string login, string password, string role)
		{
			this.login = login;
			this.password = password;
			this.role = role;
		}
	}
}
