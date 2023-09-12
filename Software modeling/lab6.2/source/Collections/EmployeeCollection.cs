using App.Enums;
using App.Interfaces;
using App.Iterators;
using System.Collections;

namespace App.Collections
{
    class EmployeeCollection : Collection
    {
        private IteratorsEnum currectIterator = IteratorsEnum.ByDefault;
        private readonly List<IEmployee> _collection = new();

        public List<IEmployee> getItems()
        {
            return _collection;
        }

        public void AddItem(IEmployee item)
        {
            _collection.Add(item);
        }

        public void RemoveItem(IEmployee item)
        {
            _collection.Remove(item);
        }

        public void SetIterator(IteratorsEnum iterator)
        {
            currectIterator = iterator;
        }

        public override IEnumerator GetEnumerator()
        {
            switch (currectIterator)
            {
                case IteratorsEnum.ByDefault:
                    return _collection.GetEnumerator();
                case IteratorsEnum.BySalaryOrder:
                    return new SalaryOrderIterator(this);
                case IteratorsEnum.ByMinimalSalary:
                    return new MinimalSalaryIterator(this);
                default:
                    throw new Exception("Iterator is invalid.");
            }
        }
    }
}
