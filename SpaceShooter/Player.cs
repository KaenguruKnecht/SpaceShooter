using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpaceShooter
{
    internal class Player : Ship
    {
        public void SetMovingDirection()
        {
            switch (Global.LastButton)
            {
                case Key.Left:
                    X_Vector = -10;
                    Y_Vector = 0;
                    break;
                case Key.Right:
                    X_Vector = 10;
                    Y_Vector = 0;
                    break;
                case Key.Down:
                    X_Vector = 0;
                    Y_Vector = 10;
                    break;
                case Key.Up:
                    X_Vector = 0;
                    Y_Vector = -10;
                    break;
            }
        }
    }
}
