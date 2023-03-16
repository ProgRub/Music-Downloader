using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;

namespace Forms
{
	static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Debug.WriteLine(RemoveDiacritics("Cl�udia"));
			Debug.WriteLine(RemoveDiacritics("qu�"));
			Debug.WriteLine(RemoveDiacritics("Cora��o"));
			Debug.WriteLine(RemoveDiacritics("zone~"));
			BusinessFacade.Instance.LoadDatabase();
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Window());
			BusinessFacade.Instance.KillDeemix();
			BusinessFacade.Instance.SaveChanges();
			BusinessFacade.Instance.EndMusicServiceLink();
		}

		public static string RemoveDiacritics(string text)
		{
			string normalized = text.Normalize(NormalizationForm.FormD);
			StringBuilder sb = new StringBuilder();

			foreach (char c in normalized)
			{
				if (CharUnicodeInfo.GetUnicodeCategory(c) == UnicodeCategory.UppercaseLetter || CharUnicodeInfo.GetUnicodeCategory(c) == UnicodeCategory.LowercaseLetter)
				{
					sb.Append(c);
				}
			}

			return sb.ToString();
		}
	}
}