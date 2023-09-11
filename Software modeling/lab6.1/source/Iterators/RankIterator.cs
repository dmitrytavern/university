using App.Enums;
using App.Collections;
using App.Interfaces;

namespace App.Iterators
{
    class RankIterator : Iterator
    {
        private readonly SoldiersCollection _collection;

        private RanksEnum _target = 0;

        private int _position = -1;

        public RankIterator(SoldiersCollection collection)
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
            int updatedPosition = _position;

            while(true)
            {
                updatedPosition++;
                
                List<ISoldier> items = _collection.getItems();

                // When reached end
                if (updatedPosition >= items.Count)
                {
                    // Start finding next rank
                    _target++;

                    // If next rank exists - start again with next rank
                    if (Enum.IsDefined(typeof(RanksEnum), _target))
                    {
                        updatedPosition = -1;
                        continue;
                    }

                    return false;
                }

                // Find soldier by target rank
                if (items[updatedPosition].Rank == _target)
                {
                    _position = updatedPosition;
                    return true;
                }
            }
        }

        public override void Reset()
        {
            _target = 0;
            _position = -1;
        }
    }
}
