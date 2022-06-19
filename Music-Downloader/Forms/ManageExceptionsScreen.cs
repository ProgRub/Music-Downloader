using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Business.Commands;
using Business.Commands.ManageExceptions;
using Business.DTOs;
using Business.Enums;
using Forms.Commands.DownloadMusic;
using Forms.Commands.ManageExceptions;

namespace Forms
{
	public partial class ManageExceptionsScreen : BaseControl
	{
		private IList<ExceptionDTO> _exceptions;
		private IDictionary<string, int> _comboBoxItemsToIntegerEnum;
		private ExceptionDTO _selectedException;
		private IEnumerable<Control> _currentlyShownControls;
		private ExceptionType _selectedExceptionType;

		internal ExceptionType SelectedExceptionType
		{
			get => _selectedExceptionType;
			set
			{
				_selectedExceptionType = value;
				var text = "";
				foreach (var key in _comboBoxItemsToIntegerEnum.Keys)
				{
					if (_comboBoxItemsToIntegerEnum[key] != (int)_selectedExceptionType) continue;
					text = key;
					break;
				}

				ComboBoxExceptionTypes.Text = text;
			}
		}

		public ManageExceptionsScreen()
		{
			InitializeComponent();
		}

		private void ButtonUndo_Click(object sender, EventArgs e)
		{
			CommandsManager.Instance.Undo();
			GetSelectedException();
			FillTextBoxesWithValuesOfSelectedException();
		}

		private void ButtonRedo_Click(object sender, EventArgs e)
		{
			CommandsManager.Instance.Redo();
			GetSelectedException();
			FillTextBoxesWithValuesOfSelectedException();
		}

		private void ManageExceptionsScreen_Enter(object sender, EventArgs e)
		{
			SetFormAcceptButton(ButtonAddChange);
			CommandsManager.Instance.Notify += (_, _) => { ButtonUndo.Enabled = CommandsManager.Instance.HasUndo; };
			CommandsManager.Instance.Notify += (_, _) => { ButtonRedo.Enabled = CommandsManager.Instance.HasRedo; };
			_exceptions = BusinessFacade.Instance.GetAllExceptions().ToList();
			_comboBoxItemsToIntegerEnum = new Dictionary<string, int>();
			var index = 0;
			foreach (var item in ComboBoxExceptionTypes.Items)
			{
				_comboBoxItemsToIntegerEnum.Add(item.ToString(), index++);
			}
			SetWindowMinimumSizeBasedOnTableLayout(tableLayoutPanelMain, false);
			ButtonBack.BringToFront();
		}


		private void ComboBoxExceptionTypes_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectedExceptionType = (ExceptionType)_comboBoxItemsToIntegerEnum[ComboBoxExceptionTypes.Text];
			ListBoxExceptions.Items.Clear();
			var exceptionsOfSelectedType = _exceptions.Where(e => e.Type == SelectedExceptionType);
			ListBoxExceptions.Enabled = true;
			FillListBoxWithExceptions(exceptionsOfSelectedType);
			ShowSelectedExceptionTypeControls();
			ClearAllTextboxes();
		}

		private void FillListBoxWithExceptions(IEnumerable<ExceptionDTO> exceptions)
		{
			foreach (var exception in exceptions)
			{
				ListBoxExceptions.Items.Add(GetExceptionString(exception));
			}
		}

		private string GetExceptionString(ExceptionDTO exception)
		{
			var lineToAdd = exception.Type switch
			{
				ExceptionType.ChangeDetailsForAlbumYear =>
					$"{exception.Id} - {exception.OriginalArtist} | {exception.OriginalAlbum}",
				ExceptionType.SkipAlbumYear =>
					$"{exception.Id} - {exception.OriginalArtist} | {exception.OriginalAlbum}",
				ExceptionType.ChangeDetailsForLyrics =>
					$"{exception.Id} - {exception.OriginalArtist} | {exception.OriginalAlbum} | {exception.OriginalTitle}",
				ExceptionType.SkipLyrics =>
					$"{exception.Id} - {exception.OriginalArtist} | {exception.OriginalTitle}",
				_ => throw new ArgumentOutOfRangeException()
			};
			return lineToAdd;
		}

		private ExceptionDTO GetExceptionFromString(string exceptionString)
		{
			return _exceptions.First(e =>
				e.Id.ToString() ==
				exceptionString.Split(" - ", StringSplitOptions.RemoveEmptyEntries).First());
		}

		private void ListBoxExceptions_SelectedIndexChanged(object sender, EventArgs e)
		{
			GetSelectedException();
			ButtonDeleteSelected.Enabled = ListBoxExceptions.SelectedItems.Count > 0;
			ButtonDeleteSelected.Visible = ButtonDeleteSelected.Enabled;
			if (ListBoxExceptions.SelectedItems.Count == 0) return;

			FillTextBoxesWithValuesOfSelectedException();
		}

		private void GetSelectedException()
		{
			if (ListBoxExceptions.SelectedItems.Count == 0)
			{
				_selectedException = null;
				ClearAllTextboxes();
				return;
			}

			_selectedException =
				GetExceptionFromString(ListBoxExceptions.Items[ListBoxExceptions.SelectedIndex].ToString());
		}

		private void ShowSelectedExceptionTypeControls()
		{
			switch (SelectedExceptionType)
			{
				case ExceptionType.ChangeDetailsForAlbumYear:
					MakeControlsVisible(
						new List<Control>
						{
							LabelOriginalAlbum, LabelOriginalArtist, LabelNewArtist, LabelNewAlbum,
							TextBoxOriginalArtist, TextBoxOriginalAlbum, TextBoxNewArtist, TextBoxNewAlbum
						});
					break;
				case ExceptionType.ChangeDetailsForLyrics:
					MakeControlsVisible(
						new List<Control>
						{
							LabelOriginalTitle, LabelOriginalArtist, LabelOriginalAlbum, LabelNewArtist, LabelNewTitle,
							TextBoxOriginalArtist, TextBoxOriginalTitle, TextBoxOriginalAlbum, TextBoxNewArtist, TextBoxNewTitle
						});
					break;
				case ExceptionType.SkipAlbumYear:
					MakeControlsVisible(
						new List<Control>
						{
							LabelOriginalAlbum, LabelOriginalArtist,
							TextBoxOriginalArtist, TextBoxOriginalAlbum
						});
					break;
				case ExceptionType.SkipLyrics:
					MakeControlsVisible(
						new List<Control>
						{
							LabelOriginalTitle, LabelOriginalArtist,
							TextBoxOriginalArtist, TextBoxOriginalTitle
						});
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void MakeControlsVisible(IEnumerable<Control> controls)
		{
			if (_currentlyShownControls != null)
			{
				foreach (var control in _currentlyShownControls)
				{
					control.Visible = false;
				}

				ButtonDeleteSelected.Enabled = false;
				ButtonDeleteSelected.Visible = false;
			}

			var toShowControls = controls.ToList();
			foreach (var control in toShowControls)
			{
				control.Visible = true;
			}

			_currentlyShownControls = toShowControls;
			ButtonAddChange.Enabled = true;
			ButtonAddChange.Visible = true;
			RelocateButtonsToBelowLowestTextBox(tableLayoutPanelMain.GetRow(toShowControls.Last()));
		}

		private void FillTextBoxesWithValuesOfSelectedException()
		{
			if (_selectedException == null) return;
			_selectedException = _exceptions.First(e => e.Id == _selectedException.Id);
			switch (_selectedException.Type)
			{
				case ExceptionType.ChangeDetailsForAlbumYear:
					TextBoxOriginalArtist.Text = _selectedException.OriginalArtist;
					TextBoxOriginalAlbum.Text = _selectedException.OriginalAlbum;
					TextBoxNewArtist.Text = _selectedException.NewArtist;
					TextBoxNewAlbum.Text = _selectedException.NewAlbum;
					break;
				case ExceptionType.ChangeDetailsForLyrics:
					TextBoxOriginalArtist.Text = _selectedException.OriginalArtist;
					TextBoxOriginalAlbum.Text = _selectedException.OriginalAlbum;
					TextBoxOriginalTitle.Text = _selectedException.OriginalTitle;
					TextBoxNewArtist.Text = _selectedException.NewArtist;
					TextBoxNewTitle.Text = _selectedException.NewTitle;
					break;
				case ExceptionType.SkipAlbumYear:
					TextBoxOriginalArtist.Text = _selectedException.OriginalArtist;
					TextBoxOriginalAlbum.Text = _selectedException.OriginalAlbum;
					break;
				case ExceptionType.SkipLyrics:
					TextBoxOriginalArtist.Text = _selectedException.OriginalArtist;
					TextBoxOriginalTitle.Text = _selectedException.OriginalTitle;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void RelocateButtonsToBelowLowestTextBox(int rowOfLowestTextBox)
		{
			tableLayoutPanelMain.SetRow(ButtonAddChange, rowOfLowestTextBox + 1);
			tableLayoutPanelMain.SetRow(ButtonDeleteSelected, rowOfLowestTextBox + 2);
		}

		private void ButtonDeleteSelected_Click(object sender, EventArgs e)
		{
			var macro = new MacroCommand();
			macro.Add(new CommandSetSelectedExceptionType(SelectedExceptionType, this));
			macro.Add(new CommandDeleteException(_selectedException));
			macro.Add(new CommandDeleteSelectedListBoxItem(ListBoxExceptions));
			CommandsManager.Instance.Execute(macro);
		}

		private void ButtonAddChange_Click(object sender, EventArgs e)
		{
			var macro = new MacroCommand();
			if (ListBoxExceptions.SelectedItems.Count == 0) _selectedException = null;
			if (_selectedException != null)
			{
				var newException = _selectedException.Type switch
				{
					ExceptionType.ChangeDetailsForAlbumYear => new ExceptionDTO
					{
						Id = _selectedException.Id,
						OriginalArtist = TextBoxOriginalArtist.Text.Trim(),
						OriginalAlbum = TextBoxOriginalAlbum.Text.Trim(),
						OriginalTitle = _selectedException.OriginalTitle,
						NewArtist = TextBoxNewArtist.Text.Trim(),
						NewAlbum = TextBoxNewAlbum.Text.Trim(),
						Type = _selectedException.Type
					},
					ExceptionType.ChangeDetailsForLyrics => new ExceptionDTO
					{
						Id = _selectedException.Id,
						OriginalArtist = TextBoxOriginalArtist.Text.Trim(),
						OriginalAlbum = TextBoxOriginalAlbum.Text.Trim(),
						OriginalTitle = TextBoxOriginalTitle.Text.Trim(),
						NewArtist = TextBoxNewArtist.Text.Trim(),
						NewTitle = TextBoxNewTitle.Text.Trim(),
						Type = _selectedException.Type
					},
					ExceptionType.SkipAlbumYear => new ExceptionDTO
					{
						Id = _selectedException.Id,
						OriginalArtist = TextBoxOriginalArtist.Text.Trim(),
						OriginalAlbum = TextBoxOriginalAlbum.Text.Trim(),
						OriginalTitle = _selectedException.OriginalTitle,
						Type = _selectedException.Type
					},
					ExceptionType.SkipLyrics => new ExceptionDTO
					{
						Id = _selectedException.Id,
						OriginalArtist = TextBoxOriginalArtist.Text.Trim(),
						OriginalAlbum = _selectedException.OriginalAlbum,
						OriginalTitle = TextBoxOriginalTitle.Text.Trim(),
						Type = _selectedException.Type
					},
					_ => throw new ArgumentOutOfRangeException()
				};

				macro.Add(new CommandSetSelectedExceptionType(SelectedExceptionType, this));
				macro.Add(new CommandChangeExceptionInList(ref _exceptions, _selectedException, newException));
				macro.Add(new CommandChangeException(_selectedException, newException));
				macro.Add(new CommandRenameSelectedListBoxItem(GetExceptionString(newException), ListBoxExceptions));
			}
			else
			{
				var newException = new ExceptionDTO
				{
					Id = _exceptions.Count > 0 ? _exceptions.Max(e => e.Id) + 1 : 1,
					OriginalArtist = TextBoxOriginalArtist.Text.Trim(),
					OriginalAlbum = TextBoxOriginalAlbum.Text.Trim(),
					OriginalTitle = TextBoxOriginalTitle.Text.Trim(),
					NewArtist = TextBoxNewArtist.Text.Trim(),
					NewAlbum = TextBoxNewAlbum.Text.Trim(),
					NewTitle = TextBoxNewTitle.Text.Trim(),
					Type = SelectedExceptionType
				};
				macro.Add(new CommandSetSelectedExceptionType(SelectedExceptionType, this));
				macro.Add(new CommandAddException(newException, ref _exceptions));
				macro.Add(new CommandAddExceptionToListBox(GetExceptionString(newException), ListBoxExceptions,
					SelectedExceptionType, this));
			}

			CommandsManager.Instance.Execute(macro);
		}

	}
}