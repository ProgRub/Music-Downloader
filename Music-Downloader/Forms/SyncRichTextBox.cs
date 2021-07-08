using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Forms
{
	class SyncRichTextBox : RichTextBox
	{
		public SyncRichTextBox()
		{
			Multiline = true;
			ScrollBars = RichTextBoxScrollBars.Vertical;
		}

		public Control[] Buddies { get; set; }

		private static bool scrolling; // In case buddy tries to scroll us

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			// Trap WM_VSCROLL message and pass to buddy
			if (Buddies == null) return;
			foreach (var buddy in Buddies)
			{
				if (buddy == this) continue;
				if ((m.Msg != 0x115 && m.Msg != 0x20a) || scrolling || !buddy.IsHandleCreated) continue;
				scrolling = true;
				SendMessage(buddy.Handle, m.Msg, m.WParam, m.LParam);
				scrolling = false;
			}
		}
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

	}
}