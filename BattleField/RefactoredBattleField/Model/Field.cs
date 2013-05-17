namespace RefactoredBattleField.Model
{
    using System;
    using System.Collections.Generic;

	public class Field
	{
		public const int MaxSize=10;

		private int size;
		private List<FieldObject> fieldObjects;

		public Field(int size)
		{
			this.Size = size;
			Size = size;
			fieldObjects = new List<FieldObject>();
		}

		public int Size
		{
			get { return size; }
			private set
			{
				if(value <= 0 && value > Field.MaxSize)
				{
					throw new ArgumentOutOfRangeException("Size",
						string.Format("Size must be in range of [{0}:{1}].", 1, Field.MaxSize));
				}

				size = value;
			}
		}

		public void AddFieldObjects(FieldObject fieldObject)
		{
			if (fieldObject == null)
			{
				throw new ArgumentNullException("Value for Field Object cannot be Null.");
			}

			if (!IsInRange(fieldObject.Position))
			{
				throw new ArgumentOutOfRangeException("The Field Object's position is out of range.");
			}

			if (ContainsFieldObject(fieldObject.Position))
			{
				throw new ArgumentException("Already exists element on this position."); //TODO: Add new exception type
			}

			fieldObjects.Add(fieldObject);
		}

		public List<FieldObject> GetFieldObjects()
		{
			return fieldObjects;
		}

		public FieldObject GetFieldObject(Cell position)
		{
			if (!IsInRange(position))
			{
				throw new ArgumentOutOfRangeException("position");
			}

            foreach (var obj in fieldObjects)
            {
                if (obj.Position.Row == position.Row &&
                    obj.Position.Col == position.Col)
                {
                    return obj;
                }
            }

            return null;
		}

		// public bool ContainsBomb(Bomb bomb)
        public bool ContainsFieldObject(Cell position)
		{
            foreach (var obj in fieldObjects)
            {
                if (obj.Position.Row == position.Row &&
                    obj.Position.Col == position.Col)
                {
                    return true;
                }
            }

            return false;
		}

		public int FieldObjectsCount
		{
			get
			{
				return fieldObjects.Count;
			}
		}

        public char GetSymbolInPosition(Cell position)
        {
            if (!IsInRange(position))
            {
                throw new ArgumentOutOfRangeException("position");
            }

            char symbol = ' ';

            if (this.ContainsFieldObject(position))
            {
                symbol = 'x';
            }

            return symbol;
        }

		private bool IsInRange(Cell position)
		{
			if (position.Col < 0 ||
				position.Col >= this.Size ||
				position.Row < 0 ||
                position.Row >= this.Size)
			{
				return false;
			}

			return true;
		}
	}
}
