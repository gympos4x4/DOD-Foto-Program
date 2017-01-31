﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PhotoMail
{
	class DatabaseController
	{
		private static StreamWriter sw;

		static DatabaseController()
		{
			if (File.Exists(Config.CsvDbPath)) return;

			using (var sw = File.AppendText(Config.CsvDbPath))
				sw.WriteLine("meno,skola,email");
		}

		public static void LogStudent(Student s)
		{
			using (var sw = File.AppendText(Config.CsvDbPath))
				sw.WriteLine($"{s.Meno},{s.Skola},{s.EMail}");
		}
	}
}
