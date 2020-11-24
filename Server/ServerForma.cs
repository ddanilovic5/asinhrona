using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
	public partial class ServerForma : Form
	{
		Server s;
		public ServerForma()
		{
			InitializeComponent();
		}

		private void ServerForma_Load(object sender, EventArgs e)
		{
			s = new Server();
			if(s.PokreniServer())
			{
				this.Text = "Server je pokrenut!";
			}
		}
	}
}
