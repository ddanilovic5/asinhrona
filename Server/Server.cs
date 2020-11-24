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

namespace Server
{
	public class Server
	{
		public static List<NetworkStream> tokovi = new List<NetworkStream>();
		Socket soket;
		public bool PokreniServer()
		{
			try
			{
				soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				IPEndPoint ep = new IPEndPoint(IPAddress.Any, 20000);
				soket.Bind(ep);

				ThreadStart ts = Osluskuj;
				new Thread(ts).Start(); // na ovaj nacin se metoda Osluskuj odvija u drugoj niti i ne smeta glavnom programu
				// koliko niti ima u programu?? Broj ulogovanih klijenata + 1 (glavna programska nit)

				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool ZaustaviServer()
		{
			try
			{
				soket.Close();
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		void Osluskuj()
		{
			try
			{
				while (true)
				{
					soket.Listen(8);
					Socket klijent = soket.Accept(); // posmartamo soket na kome se prijavio klijent - prihvati soket za tog kklijenta
					NetworkStream tok = new NetworkStream(klijent);
					new NitKlijenta(tok);
					tokovi.Add(tok);
				}
			}
			catch (Exception)
			{

				
			}
		}
	}
}
