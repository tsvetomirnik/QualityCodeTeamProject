using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoredBattleField.View
{
    interface IUserInput
    {

        int[] GetFieldSize();

        int[] GetCellPosition();
    }
}
