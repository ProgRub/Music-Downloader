using System;
using System.Collections.Generic;
using System.Linq;
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
			BusinessFacade.Instance.LoadDatabase();
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Window());
			BusinessFacade.Instance.KillDeemix();
			BusinessFacade.Instance.SaveChanges();
			BusinessFacade.Instance.EndMusicServiceLink();
		}
	}
}