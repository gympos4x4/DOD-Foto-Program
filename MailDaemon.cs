using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace PhotoMail
{
	class MailDaemon
	{
		private static MailAddress _senderAddress;
		private static SmtpClient _smtpClient;

		static MailDaemon()
		{
			_senderAddress = new MailAddress(Config.MailAccount, Config.MailDisplayName);

			_smtpClient = new SmtpClient(Config.SmtpServer, Config.SmtpPort)
			{
				EnableSsl = Config.SmtpSsl,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(Config.MailAccount, Config.MailPasswd),
				DeliveryMethod = SmtpDeliveryMethod.Network
			};

		}

		public static bool IsEmailAddrValid(string email)
		{
			try
			{
				new MailAddress(email);
				return true;
			}
			catch {
				return false;
			}
		}

		private static void SaveBitmap(Bitmap bmp, out string path, out string guid)
		{
			if (bmp == null) throw new ArgumentNullException(nameof(bmp));

			string photoName = "", guidStr = "";
			do
			{
				guidStr = Guid.NewGuid().ToString();
				photoName = "photos/" + guidStr + ".jpeg";
			} while (File.Exists(photoName));

			bmp.Save(photoName, ImageFormat.Jpeg);

			path = photoName;
			guid = guidStr;

			//Nasty hack - 
			ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) => true;
		}

		public static void SendEMail(string address, Bitmap image)
		{
			var reciever = new MailAddress(address);

			string photoPath, guidStr;
			SaveBitmap(image, out photoPath, out guidStr);

			var mail = new MailMessage(_senderAddress, reciever)
			{
				HeadersEncoding = Encoding.UTF8,
				SubjectEncoding = Encoding.UTF8,
				BodyEncoding = Encoding.UTF8,
				Subject = Config.MailSubject,
			};

			var pic = new Attachment(photoPath, new ContentType("image/jpeg"))
			{
				Name = Config.MailPhotoName,
				ContentDisposition = {Inline = true}
			};


			var plainTextView = AlternateView.CreateAlternateViewFromString(Config.MailPlainContent, Encoding.UTF8,
				MediaTypeNames.Text.Plain);
			var htmlView = AlternateView.CreateAlternateViewFromString(Config.MailHtmlContent, Encoding.UTF8,
				MediaTypeNames.Text.Html);

			var inline = new LinkedResource(photoPath, MediaTypeNames.Image.Jpeg) {ContentId = "photo"};
			htmlView.LinkedResources.Add(inline);

			mail.AlternateViews.Add(plainTextView);
			mail.AlternateViews.Add(htmlView);

			mail.Attachments.Add(pic);

#if DEBUG
			_smtpClient.Send(mail);
#else
			var task = _smtpClient.SendMailAsync(mail);
			task.GetAwaiter().OnCompleted(() => MessageBox.Show(@"Message sent."));
#endif
		}
	}
}
