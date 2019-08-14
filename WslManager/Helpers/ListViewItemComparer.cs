using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WslManager.Helpers
{
    public sealed class ListViewItemComparer<T> : IComparer
    {
        public ListViewItemComparer(Func<T, T, int> comparer, SortOrder sortOrder) : base()
        {
            _comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
            _sortOrder = sortOrder;
        }

        private readonly Func<T, T, int> _comparer;
        private readonly SortOrder _sortOrder;

        private T ExtractTagFromLVItem(object o)
            => (o is T) ? (T)o : (T)((ListViewItem)o).Tag;

        private int ApplySortOrder(int result)
            => _sortOrder == SortOrder.Descending ? result * (-1) : result;

        public int Compare(object x, object y)
            => ApplySortOrder(_comparer.Invoke(ExtractTagFromLVItem(x), ExtractTagFromLVItem(y)));

        private int Compare(T x, T y)
            => ApplySortOrder(_comparer.Invoke(x, y));
    }
}
