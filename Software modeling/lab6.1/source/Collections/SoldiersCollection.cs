using App.Interfaces;
using App.Iterators;
using App.Enums;
using System.Collections;

namespace App.Collections
{
    class SoldiersCollection : Collection
    {
        private IteratorsEnum currectIterator = 0;
        private readonly List<ISoldier> _collection = new();

        public List<ISoldier> getItems()
        {
            return _collection;
        }

        public void AddItem(ISoldier item)
        {
            _collection.Add(item);
        }

        public void RemoveItem(ISoldier item)
        {
            _collection.Remove(item);
        }

        public void SetIterator(IteratorsEnum iterator)
        {
            currectIterator = iterator;
        }

        public override IEnumerator GetEnumerator()
        {
            switch(currectIterator)
            {
                case IteratorsEnum.ByDefault:
                    return _collection.GetEnumerator();
                case IteratorsEnum.ByRank:
                    return new RankIterator(this);
                case IteratorsEnum.ByRang:
                    return new RangIterator(this);
                case IteratorsEnum.ByGroup:
                    return new GroupIterator(this);
                default:
                    throw new Exception("Iterator is invalid.");
            }
        }
    }
}
