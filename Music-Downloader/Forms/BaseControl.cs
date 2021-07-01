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
        private readonly Color _ligthenBoxesColor = Color.FromArgb(0, 0, 50);
        public BaseControl()
        {
            InitializeComponent();
            AutoSize = true;
            DefaultConfigurations();
        }

        protected void DefaultConfigurations()
        {
            SetForeColor();
            ConfigureButtons();
            SetBackColorsAndNotBold();
        }

        protected void MaximizeWindow() => ((Window) Parent).WindowState = FormWindowState.Maximized;

        private static Color ColorAdd(Color color1, Color color2)
        {
            var r = (byte) (color1.R + color2.R);
            var g = (byte) (color1.G + color2.G);
            var b = (byte) (color1.B  +color2.B);
            return Color.FromArgb(r, g, b);
        }

        private void SetBackColorsAndNotBold()
        {
            foreach (var listBox in Controls.OfType<ListBox>())
            {
                listBox.BackColor = ColorAdd(((Window)Parent).BackColor, _ligthenBoxesColor);
                listBox.Font = new Font(listBox.Font, FontStyle.Regular);
            }

            foreach (var textBox in Controls.OfType<TextBox>())
            {
                textBox.BackColor = ColorAdd(((Window) Parent).BackColor, _ligthenBoxesColor);
                textBox.Font = new Font(textBox.Font, FontStyle.Regular);
                if (!textBox.Multiline) textBox.Size=new Size(textBox.Size.Width,textBox.Size.Height-1);
            }

            foreach (var textBox in Controls.OfType<RichTextBox>())
            {
                textBox.BackColor = ColorAdd(((Window)Parent).BackColor, _ligthenBoxesColor);
                textBox.Font = new Font(textBox.Font, FontStyle.Regular);
                if (!textBox.Multiline) textBox.Size = new Size(textBox.Size.Width, textBox.Size.Height - 1);
            }
        }

        private void SetForeColor()
        {
            try
            {
                foreach (Control control in Controls)
                {
                    control.ForeColor = ForeColor;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void ConfigureButtons()
        {
            foreach (var button in Controls.OfType<Button>())
            {
                button.FlatStyle = FlatStyle.Flat;
                button.BackColor=Color.Transparent;
                button.FlatAppearance.MouseDownBackColor = button.BackColor;
                button.FlatAppearance.MouseOverBackColor = button.BackColor;
                button.FlatAppearance.BorderSize = 0;
            }
        }

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


        protected void ClearAllTextboxesPlaceholderText()
        {
            foreach (var textBox in Controls.OfType<TextBox>())
            {
                textBox.PlaceholderText = "";
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            MoveToScreen(PreviousScreen, PreviousScreen.PreviousScreen);
        }
    }
}