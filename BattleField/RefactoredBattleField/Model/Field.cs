using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoredBattleField.Model
{
	public class Field
	{
		public const int MaxSize;

		private int _size;
		private List<Bomb> _bombs;

		public Field(int size)
		{
			Size = size;
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
			};
		}

		public void AddBomb(Bomb bomb)
		{
			if (bomb == null)
			{
				throw new ArgumentNullException("bomb");
			}

			if (!IsInRange(bomb.GetPosition()))
			{
				throw new ArgumentOutOfRangeException("bomb");
			}

			if (ContainsBombObject(bomb))
			{
				throw new Exception("Already exists element on this position."); //TODO: Add new exception type
			}

			_bombs.Add(bomb);
		}

		public FieldObject GetBomb(Cell position)
		{
			if (!IsInRange(position))
			{
				throw new ArgumentOutOfRangeException("position");
			}

			return _bombs.Where(x => 
				x.GetPosition().Col == position.Col 
				&& x.GetPosition().Row == position.Row).First();
		}

		public bool ContainsBomb(Bomb bomb)
		{
			return _bombs.Any(x => 
				x.GetPosition().Col == bomb.GetPosition().Col 
				&& x.GetPosition().Row == bomb.GetPosition().Row);
		}

		public int BombsCount
		{
			get
			{
				return _bombs.Count();
			}
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
