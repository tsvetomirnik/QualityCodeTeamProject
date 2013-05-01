using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoredBattleField
{
    public interface IUserOutput
    {
        void DisplayMessage();

        void DisplayWarning();

        void DisplayException();
    }
}
