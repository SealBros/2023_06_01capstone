using System.Collections.Specialized;

namespace EUV.Views
{
    internal class CollectionChangedEventArgs
    {
        public NotifyCollectionChangedAction Action { get; internal set; }
    }
}