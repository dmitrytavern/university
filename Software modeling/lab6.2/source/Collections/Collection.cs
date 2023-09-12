using System.Collections;

namespace App.Collections
{
    abstract class Collection : IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
    }
}
