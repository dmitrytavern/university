using App.Collections;
using App.Interfaces;

namespace App.Iterators
{
    class SalaryOrderIterator : Iterator
    {
        private readonly List<IEmployee> handledEmployees = new();

        private readonly EmployeeCollection _collection;

        private IEmployee? _target;

        private int _position = -1;

        public SalaryOrderIterator(EmployeeCollection collection)
        {
            _collection = collection;
        }

        public override object Current()
        {
            return _collection.getItems()[_position];
        }

        public override int Key()
        {
            return _position;
        }

        public override bool MoveNext()
        {
            int index = 0;
            List<IEmployee> items = _collection.getItems();

            foreach (IEmployee item in items)
            {
                if (!handledEmployees.Contains(item))
                {
                    if (_target is null)
                    {
                        _target = item;
                        _position = index;
                    }

                    if (_target != item)
                    {
                        _target = item.Salary >= _target.Salary ? item : _target;
                        _position = item.Salary >= _target.Salary ? index : _position;
                    }
                }

                index++;
            }

            if (_target is null)
            {
                return false;
            }
            else
            {
                handledEmployees.Add(_target);
                _target = null;
                return true;
            }
        }

        public override void Reset()
        {
            _target = null;
            _position = -1;
            handledEmployees.Clear();
        }
    }
}
