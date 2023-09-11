using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace SpaceShooter
{
    internal class SpaceObjekt
    {
        private Polygon _shape = new Polygon();
        public Polygon Shape { get { return _shape; } set { _shape = value; } }
        public double X_Postion { get; set; }
        public double Y_Postion { get; set; }
        public int X_Vector { get; set; }
        public int Y_Vector { get; set; }

        public void Move()
        {
            X_Postion = X_Postion + X_Vector;
            Y_Postion = Y_Postion + Y_Vector;
        }
        public void Show()
        {
            Canvas.SetLeft(_shape, X_Postion);
            Canvas.SetTop(_shape, Y_Postion);
        }
        public void RemoveFromCanvas()
        {
            Global.SpaceCanvas.Children.Remove(_shape);
        }
    }
}
