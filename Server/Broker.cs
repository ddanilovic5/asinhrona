using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;
using System.Data;
using System.Data.SqlClient;

namespace Server
{
	public class Broker
	{
		SqlCommand komanda;
		SqlConnection konekcija;
		SqlTransaction transakcija;

		void KonektujSe()
		{
			konekcija = new SqlConnection(@"");
			komanda = konekcija.CreateCommand();
		}

		public Broker()
		{
			KonektujSe();
		}

		static Broker instanca;
		public static Broker DajSesiju()
		{
			if (instanca == null) instanca = new Broker();
			return instanca;
		}
	}
}
