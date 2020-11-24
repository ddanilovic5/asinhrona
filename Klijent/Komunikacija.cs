using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Klijent
{
	public class Komunikacija
	{
		TcpClient klijent;
		NetworkStream tok;
		BinaryFormatter formater;

		public bool PoveziSeNaServer()
		{
			try
			{
				klijent = new TcpClient("localhost", 20000);
				tok = klijent.GetStream(); // kad se desi ova linija koda, onda se izvrsava u Serveru soket.Accept() i server pamti isti tok
				formater = new BinaryFormatter();
				return true;
			}
			catch (Exception)
			{

				return false ;
			}
		}

		public void Kraj()
		{
			// slanje podataka serveru
			TransferKlasa transfer = new TransferKlasa();
			transfer.Operacije = Operacije.Kraj;
			formater.Serialize(tok, transfer);
		}

		internal void PosaljiPoruku(TransferKlasa tk)
		{
			//slanje
			tk.Operacije = Operacije.SlanjePoruke;
			formater.Serialize(tok, tk);
		}

		internal TransferKlasa PrimiPoruku()
		{
			return formater.Deserialize(tok) as TransferKlasa;

		}
	}
}
