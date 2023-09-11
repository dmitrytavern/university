using App.Enums;
using App.Collections;
using App.Interfaces;
using System.Diagnostics;

namespace App.Iterators
{
    class RangIterator : Iterator
    {
        private readonly SoldiersCollection _collection;

        private RangsEnum _target;

        private int _position = -1;

        public RangIterator(SoldiersCollection collection)
        {
            _collection = collection;
            ResetTarget();
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
            int updatedPosition = _position;

            while(true)
            {
                updatedPosition++;
                
                List<ISoldier> items = _collection.getItems();

                // When reached end
                if (updatedPosition >= items.Count)
                {
                    // Start finding next rank
                    _target--;

                    // If next rank exists - start again with next rank
                    if (Enum.IsDefined(typeof(RangsEnum), _target))
                    {
                        updatedPosition = -1;
                        continue;
                    }

                    return false;
                }

                // Find soldier by target rank
                if (items[updatedPosition].Rang == _target)
                {
                    _position = updatedPosition;
                    return true;
                }
            }
        }

        public override void Reset()
        {
            ResetTarget();
            _position = -1;
        }

        private void ResetTarget()
        {
            _target = Enum.GetValues(typeof(RangsEnum)).Cast<RangsEnum>().Last();
        }
    }
}
