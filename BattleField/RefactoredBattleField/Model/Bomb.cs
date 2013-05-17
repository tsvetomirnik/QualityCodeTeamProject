namespace RefactoredBattleField.Model
{
    using RefactoredBattleField.Exceptions;
    using System;
    using System.Linq;

	public class Bomb : FieldObject
	{
		public const int MinSize = 1;
		public const int MaxSize = 5;
		private bool isExploded;

		private int size;
        private Explosion explosion;

		public Bomb(Cell position, int size)
			: base(position)
		{
			Size = size;
            
            this.SetExplosion(size);

            isExploded = false;
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
			get { return size; }
			private set
			{
				if (value <= 0 || value > MaxSize)
				{
					throw new ArgumentOutOfRangeException("Size",
						string.Format("Size must be in range of [{0}:{1}]", Bomb.MinSize, Bomb.MaxSize));
				}

				size = value;
			}
		}

		public Explosion Explosion
		{
			get { return explosion; }
			private set
			{
				if (value == null)
				{
					throw new ArgumentNullException("Explosion",
                        "Explosion cannot be null.");
				}

				explosion = value;
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
            else if (size == 4)
            {
                explosionBody = new[,]
				{
					{0, 1, 1, 1, 0},
					{1, 1, 1, 1, 1},
					{1, 1, 1, 1, 1},
					{1, 1, 1, 1, 1},
					{0, 1, 1, 1, 0},
				};
            }
            else if (size == 5)
            {
                explosionBody = new[,]
				{
					{1, 1, 1, 1, 1},
					{1, 1, 1, 1, 1},
					{1, 1, 1, 1, 1},
					{1, 1, 1, 1, 1},
					{1, 1, 1, 1, 1},
				};
            }


			Explosion = new Explosion(this.Position, explosionBody);

			Cell explosionPosition = new Cell
			{
                Col = this.Position.Row - (explosionBody.GetLength(0) / 2),
				Row = this.Position.Col - (explosionBody.GetLength(1)/2)
			};
			Explosion = new Explosion(explosionPosition, explosionBody);
		}

		public void Explode()
		{
			if(isExploded)
			{
                throw new AlreadyExplodedBombException(this);
			}

			OnBombExploded(new EventArgs());
			isExploded = true;
		}
	}
}
