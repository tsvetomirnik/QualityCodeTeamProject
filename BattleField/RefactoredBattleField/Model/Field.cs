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
		private List<FieldObject> _fieldObjects;

		public Field(int size)
		{
			Size = size;
			_fieldObjects = new List<FieldObject>();
		}

		public int Size
		{
			get { return _size; }
			private set
			{
				if(value <= 0 && value > Field.MaxSize)
				{
					throw new ArgumentOutOfRangeException("Size",
						string.Format("Size must be in range of [{0}:{1}].", 1, Field.MaxSize));
				}

				_size = value;
			}
		}

		public void AddFieldObjects(FieldObject fieldObject)
		{
			if (fieldObject == null)
			{
				throw new ArgumentNullException("fieldObjects");
			}

			if (!IsInRange(fieldObject.GetPosition()))
			{
				throw new ArgumentOutOfRangeException("fieldObjects");
			}

			if (ContainsFieldObject(fieldObject))
			{
				throw new Exception("Already exists element on this position."); //TODO: Add new exception type
			}

			_fieldObjects.Add(fieldObject);
		}

		public List<FieldObject> GetFieldObjects()
		{
			return _fieldObjects;
		}

		public FieldObject GetFieldObject(Cell position)
		{
			if (!IsInRange(position))
			{
				throw new ArgumentOutOfRangeException("position");
			}

			return _fieldObjects.Where(x => 
				x.GetPosition().Col == position.Col 
				&& x.GetPosition().Row == position.Row).First();
		}

		public bool ContainsFieldObject(FieldObject fieldObject)
		{
			return _fieldObjects.Any(x => 
				x.GetPosition().Col == fieldObject.GetPosition().Col 
				&& x.GetPosition().Row == fieldObject.GetPosition().Row);
		}

		public int FieldObjectsCount
		{
			get
			{
				return _fieldObjects.Count();
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
