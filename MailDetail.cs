using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoMail
{
	public partial class MailDetail : Form
	{
		private readonly Settings _settings;

		public MailDetail(Settings settings)
		{
			_settings = settings;

			InitializeComponent();
		}

		private void btnSendMail_Click(object sender, EventArgs e)
		{
			var s = new Student(tbEMail.Text, tbName.Text, tbSchool.Text, "");
#if !DEBUG
			if (s.EMail == "" || s.Skola == "" || s.Meno == "")
			{
				MessageBox.Show(@"Prosím, vyplň všetky políčka.", @"Y U DO THIS?", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			if (!MailDaemon.IsEmailAddrValid(s.EMail))
			{
				MessageBox.Show(@"Prosím, zadaj reálnu e-mailovú adresu.", @"Y U DO THIS?", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}
#endif

			string photo = MailDaemon.SendEMail(s, _settings.GetImage());
			s.Photo = photo;
			DatabaseController.LogStudent(s);
		}
	}
}
