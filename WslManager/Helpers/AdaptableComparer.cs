using System;
using System.Collections;
using System.Collections.Generic;

namespace WslManager.Helpers
{
    public sealed class AdaptableComparer<T> : IComparer, IComparer<T>
    {
        public AdaptableComparer(Func<T, T, int> comparer) : base()
        {
            _comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        }

        private readonly Func<T, T, int> _comparer;

        public int Compare(object x, object y)
            => _comparer.Invoke((T)x, (T)y);

        public int Compare(T x, T y)
            => _comparer.Invoke(x, y);
    }
}
