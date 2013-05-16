using System;
using System.Linq;

namespace RefactoredBattleField.Model
{
	public class Bomb : FieldObject
	{
		public const int MinSize = 1;
		public const int MaxSize = 5;
		private bool _isExploded;

		private int _size;
		private Explosion _explosion;

		public Bomb(Cell position, int size)
			: base(position)
		{
			Size = size;

			SetExplosion(size);

			_isExploded = false;
		}

		public event EventHandler BombExploded;
		protected void OnBombExploded(EventArgs args)
		{
			EventHandler handler = BombExploded;
			if (handler != null)
			{
				handler(this, args);
			}
		}

		public int Size
		{
			get { return _size; }
			private set
			{
				if (value <= 0 || value > MaxSize)
				{
					throw new ArgumentOutOfRangeException("Size",
						string.Format("Size must be in range of [{0}:{1}]", Bomb.MinSize, Bomb.MaxSize));
				}

				_size = value;
			}
		}

		public Explosion Explosion
		{
			get { return _explosion; }
			private set
			{
				if (value == null)
				{
					throw new ArgumentNullException("Explosion");
				}

				_explosion = value;
			}
		}
		
		protected void SetExplosion(int size)
		{
			int[,] explosionBody = new int[,]{};
			Cell explosionCenter;

			//TODO: Create better scheme to set explosion body
			if (size == 1)
			{
				explosionBody = new[,]
				{
					{1, 0, 1},
					{0, 1, 0},
					{1, 0, 1},
				};
			}
			else if(size == 2)
			{
				explosionBody = new[,]
				{
					{1, 1, 1},
					{1, 1, 1},
					{1, 1, 1},
				};
			}
			else if (size == 3)
			{
				explosionBody = new[,]
				{
					{0, 0, 1, 0, 0},
					{0, 1, 1, 1, 0},
					{1, 1, 1, 1, 1},
					{0, 1, 1, 1, 0},
					{0, 0, 1, 0, 0},
				};
			}
			else
			{
				throw new Exception("Invalid size"); //TODO: Write better exception
			}

			//TODO: Add 4 and 5

			Cell explosionPosition = new Cell
			{
				Col = this.position.Row - (explosionBody.GetLength(0)/2),
				Row = this.position.Col - (explosionBody.GetLength(1)/2)
			};
			Explosion = new Explosion(explosionPosition, explosionBody);
		}

		public void Explode()
		{
			if(_isExploded)
			{
				throw new Exception(); //Add custom exception
			}

			OnBombExploded(new EventArgs());
			_isExploded = true;
		}
	}
}
