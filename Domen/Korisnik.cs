using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
	[Serializable]
	public class Korisnik
	{
		public string Username { get; set; }
		public string Ime { get; set; }
		public string Prezime { get; set; }
	}
}
