using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PhotoMail
{
	class Config
	{
		public static string CsvDbPath { get; private set; }

		public static string SmtpServer { get; private set; }
		public static int SmtpPort { get; private set; }
		public static bool SmtpSsl { get; private set; }

		public static string MailAccount { get; private set; }
		public static string MailPasswd { get; private set; }
		public static string MailDisplayName { get; private set; }

		public static string MailHtmlContent { get; private set; }
		public static string MailPlainContent { get; private set; }
		public static string MailSubject { get; private set; }
		public static string MailPhotoName { get; private set; }

		static Config()
		{
			JToken token = JObject.Parse(File.ReadAllText("config.json"));

			CsvDbPath = (string) token.SelectToken("CsvDbPath");

			SmtpServer  = (string) token.SelectToken("SmtpServer");
			SmtpPort = (int) token.SelectToken("SmtpPort");
			SmtpSsl = (bool) token.SelectToken("SmtpSsl");

			MailAccount = (string) token.SelectToken("MailAccount");
			MailPasswd  = (string) token.SelectToken("MailPasswd");
			MailDisplayName = (string) token.SelectToken("MailDisplayName");
			MailPhotoName = (string) token.SelectToken("MailPhotoName");

			try
			{
				MailHtmlContent = File.ReadAllText((string) token.SelectToken("MailHtmlContentFile"));
				MailPlainContent = File.ReadAllText((string) token.SelectToken("MailPlainContentFile"));
			} catch
			{
				MessageBox.Show(@"Invalid path set for mail body. SET IT UP!");
				Application.Exit();
			}

			MailSubject = (string) token.SelectToken("MailSubject");
		}
	}
}