using App.Collections;
using App.Interfaces;

namespace App.Iterators
{
    class MinimalSalaryIterator : Iterator
    {
        private readonly EmployeeCollection _collection;

        private int _position = -1;

        public MinimalSalaryIterator(EmployeeCollection collection)
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
            List<IEmployee> employees = _collection.getItems();

            for (int i = _position + 1; i < employees.Count; i++)
            {
                if (employees[i].Salary == 6500)
                {
                    _position = i;
                    return true;
                }
            }

            return false;
        }

        public override void Reset()
        {
            _position = -1;
        }
    }
}
