using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SRB
{
	public class SRBContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Patients> Patient { get; set; }
		
		public SRBContext() : base("DefaultConnection") { }
	}
}
