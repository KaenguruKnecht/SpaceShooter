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
        public double X_Position { get; set; }
        public double Y_Position { get; set; }
        public int X_Vector { get; set; }
        public int Y_Vector { get; set; }
        public bool Alive { get; set; }

        public void Move()
        {
            X_Position = X_Position + X_Vector;
            Y_Position = Y_Position + Y_Vector;
        }
        public void Show()
        {
            if (Alive)
            {
                Canvas.SetLeft(_shape, X_Position);
                Canvas.SetTop(_shape, Y_Position);
                Global.SpaceCanvas.Children.Add(_shape);
            }
        }
        public void RemoveFromCanvas()
        {
            Global.SpaceCanvas.Children.Remove(_shape);
        }
        public void Collision()
        {

        }
    }
}
