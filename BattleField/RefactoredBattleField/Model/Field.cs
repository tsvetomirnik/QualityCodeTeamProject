using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoredBattleField.Model
{
	public class Field
	{
		public const int MaxSize=10;

		private int _size;
		private List<Bomb> _bombs;

		public Field(int size)
		{
			this.Size = size;
			_bombs = new List<Bomb>();
		}

		public int Size
		{
			get { return _size; }
			set
			{
				if(value <= 0 && value > Field.MaxSize)
				{
					throw new ArgumentOutOfRangeException("Size",
						string.Format("Size must be in range of [{0}:{1}].", 1, Field.MaxSize));
				}

				_size = value;
			}
		}

		public void AddBomb(Bomb bomb)
		{
			if (bomb == null)
			{
				throw new ArgumentNullException("Value for Bomb cannot be Null.");
			}

			if (!IsInRange(bomb.Position))
			{
				throw new ArgumentOutOfRangeException("The Bomb's position is out of range.");
			}

			if (ContainsBomb(bomb.Position))
			{
				throw new ArgumentException("Already exists element on this position."); //TODO: Add new exception type
			}

			_bombs.Add(bomb);
		}

		public FieldObject GetBomb(Cell position)
		{
			if (!IsInRange(position))
			{
				throw new ArgumentOutOfRangeException("position");
			}

            Console.WriteLine("Bomb Count:", _bombs.Count);

            foreach (var bomb in _bombs)
            {
                if (bomb.Position.Row == position.Row &&
                    bomb.Position.Col == position.Col)
                {
                    return bomb;
                }
            }

            return null;
            
            //return _bombs.Where(x => 
            //    x.GetPosition().Col == position.Col 
            //    && x.GetPosition().Row == position.Row).First();
            
		}

		// public bool ContainsBomb(Bomb bomb)
        public bool ContainsBomb(Cell position)
		{
            foreach (var bomb in _bombs)
            {
                if (bomb.Position.Row == position.Row &&
                    bomb.Position.Col == position.Col)
                {
                    return true;
                }
            }

            return false;
            //return _bombs.Any(x => 
            //    x.GetPosition().Col == bomb.GetPosition().Col 
            //    && x.GetPosition().Row == bomb.GetPosition().Row);
		}

        


		public int BombsCount
		{
			get
			{
				return _bombs.Count;
			}
		}

        public char GetSymbolInPosition(Cell position)
        {
            if (!IsInRange(position))
            {
                throw new ArgumentOutOfRangeException("position");
            }

            char symbol = ' ';

            if (this.ContainsBomb(position))
            {
                symbol = 'x';
            }

            return symbol;
        }



		private bool IsInRange(Cell position)
		{
			if (position.Col < 0 ||
				position.Col >= _size ||
				position.Row < 0 ||
				position.Row >= _size)
			{
				return false;
			}

			return true;
		}

        
	}
}
