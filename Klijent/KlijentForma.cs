using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent
{
	public delegate void Delegat(TransferKlasa transfer);
	public partial class KlijentForma : Form
	{
		Komunikacija k;
		public KlijentForma()
		{
			InitializeComponent();
		}

		private void KlijentForma_Load(object sender, EventArgs e)
		{
			k = new Komunikacija();
			if(k.PoveziSeNaServer())
			{
				this.Text = "Povezan";
				ThreadStart ts = PrimiPoruku;
				new Thread(ts).Start();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Korisnik korisnik = new Korisnik();
			korisnik.Username = textBox1.Text;

			TransferKlasa tk = new TransferKlasa();
			tk.korisnik = korisnik;
			tk.Poruka = textBox2.Text;

			textBox3.Text += "\r\n" + DateTime.Now.ToString("HH:mm") + "\t" + tk.Poruka;

			k.PosaljiPoruku(tk);

		}

		void PrimiPoruku()
		{
			while (true)
			{
				TransferKlasa tk = k.PrimiPoruku();
				Delegat d = new Delegat(PrikaziPoruku);
				Invoke(d, tk);
			}
		}

		void PrikaziPoruku (TransferKlasa transfer)
		{
			textBox3.Text += "\r\n" + DateTime.Now.ToString("HH:mm") + "\t" + transfer.Odgovor;

		}
	}
}
