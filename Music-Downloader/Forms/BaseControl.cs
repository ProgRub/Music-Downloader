using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Forms
{
	public partial class BaseControl : UserControl
	{
		public BaseControl PreviousScreen { private get; set; }

		public BaseControl()
		{
			InitializeComponent();
			AutoSize = true;
		}

		protected void MaximizeWindow() => ((Window) Parent).WindowState = FormWindowState.Maximized;

		protected void MoveToScreen(BaseControl newControl, BaseControl previousControl)
		{
			newControl.PreviousScreen = previousControl;
			var window = (Window) Parent ?? (Window) newControl.Parent;
			window.Controls.Remove(this);
			newControl.Dock = DockStyle.Fill;
			window.Controls.Add(newControl);
			window.ActiveControl = newControl;
		}

		protected void ClearTextBox(TextBox textBox) => textBox.Text = "";

		protected void ShowTextBoxErrorMessage(TextBox textBox, string errorMessage)
		{
			if (string.IsNullOrWhiteSpace(textBox.PlaceholderText))
			{
				((Window) Parent).ActiveControl = null;
				ClearTextBox(textBox);
				textBox.PlaceholderText = errorMessage;
			}
		}

		protected void ShowInformationMessageBox(string message, string messageBoxTitle)
		{
			MessageBox.Show(message, messageBoxTitle, MessageBoxButtons.OK);
		}

		protected void SetFormAcceptButton(Button button)
		{
			((Window) Parent).AcceptButton = button;
		}


		protected void SetCheckedListBoxColumnWidth(CheckedListBox checkedListBox)
		{
			var columnWidth = 0;
			foreach (string item in checkedListBox.Items)
			{
				var width = TextRenderer.MeasureText(item, checkedListBox.Font).Width;
				if (width > columnWidth)
				{
					columnWidth = width + 20;
				}
			}

			checkedListBox.ColumnWidth = columnWidth;
		}


		protected void ClearAllTextboxes()
		{
			foreach (var textBox in Controls.OfType<TextBox>())
			{
				textBox.Text = "";
			}
		}

		protected void ButtonBack_Click(object sender, EventArgs e)
		{
			MoveToScreen(PreviousScreen, PreviousScreen.PreviousScreen);
		}
	}
}