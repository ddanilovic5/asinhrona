using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
	public enum Operacije { Kraj = 1, SlanjePoruke }
	[Serializable]
    public class TransferKlasa
    {
		public Operacije Operacije;
		public string Poruka;
		public Korisnik korisnik;
		public string Odgovor;

		public Object TransferObjekat; // prenosi objekte do servera
		public Object Rezultat;
	}
}
