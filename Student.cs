using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMail
{
	struct Student {
		public string Meno { get; set; }
		public string Skola { get; set; }
		public string EMail { get; set; }
		public string Photo { get; set; }
		public string Guid { get; set; }

		public Student(string email, string name, string school, string photo)
		{
			Meno = name;
			Skola = school;
			EMail = email;
			Photo = photo;
			Guid = "";
		}
	}
}
