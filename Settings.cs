using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace PhotoMail
{
	public partial class Settings : Form
	{
		private VideoCaptureDevice camera = null;

		public Settings()
		{
			InitializeComponent();
			DatabaseController.InitDatabaseController();
		}

		public Bitmap GetImage()
		{
			return (Bitmap)pictureBox1.Image.Clone();
		}

		private void Settings_Load(object sender, EventArgs e)
		{
			var form = new VideoCaptureDeviceForm();
			if (form.ShowDialog() == DialogResult.OK)
			{
				camera = form.VideoDevice;
				camera.NewFrame += CameraOnNewFrame;

				SetClientSizeCore(form.CaptureSize.Width, form.CaptureSize.Height);

				camera.Start();
			}
			else
			{
				MessageBox.Show("Nabuduce stlac OK");
				Application.Exit();
			}

			new MailDetail(this).Show();
		}

		private void CameraOnNewFrame(object sender, NewFrameEventArgs eventArgs)
		{
			try
			{
				pictureBox1.Image = (Bitmap) eventArgs.Frame.Clone();
			}
			catch { }
		}

		private void Settings_ResizeEnd(object sender, EventArgs e)
		{
			pictureBox1.Width = Width;
			pictureBox1.Height = Height;
		}

		private void Settings_FormClosed(object sender, FormClosedEventArgs e)
		{
			if(camera?.IsRunning == true) camera.Stop();
		}
	}
}
