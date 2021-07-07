using System.Collections;
using System.Windows.Forms;

namespace Forms
{
	public class ListViewColumnSorter : IComparer
	{
		private int _columnToSort;
		private SortOrder _orderOfSort;
		private readonly CaseInsensitiveComparer _objectCompare;
		internal int SortColumn
		{
			set => _columnToSort = value;
			get => _columnToSort;
		}
		internal SortOrder Order
		{
			set => _orderOfSort = value;
			get => _orderOfSort;
		}
		public ListViewColumnSorter()
		{
			_columnToSort = 0;
			_orderOfSort = SortOrder.None;
			_objectCompare = new CaseInsensitiveComparer();
		}
		public int Compare(object x, object y)
		{
			var listViewX = (ListViewItem) x;
			var listViewY = (ListViewItem) y;
			
			var compareResult = _objectCompare.Compare(listViewX.SubItems[_columnToSort].Text,
				listViewY.SubItems[_columnToSort].Text);

			return _orderOfSort switch
			{
				SortOrder.Ascending => compareResult,
				SortOrder.Descending => (-compareResult),
				_ => 0
			};
		}
	}
}