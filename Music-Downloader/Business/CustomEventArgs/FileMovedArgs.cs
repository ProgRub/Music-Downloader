using System;
using Business.Enums;

namespace Business.CustomEventArgs
{
	public class FileMovedArgs : EventArgs
	{
		public string Filename { get; set; }
		public FileMovedCondition Condition { get; set; }
	}
}