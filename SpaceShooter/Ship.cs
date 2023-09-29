using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpaceShooter
{
    internal class Ship : SpaceObjekt
    {
        internal static List<PewPew> _pewpews = new List<PewPew>();
        internal void Design()
        {

        }
        internal void forEveryPewPew()
        {
            foreach (PewPew item in Ship._pewpews)
            {
                item.BorderCollision();
                item.RemoveFromCanvas();
                item.Move();
                item.Design();
                item.Show();
            }
        }// Entfernen, Bewegen, Designen und Anzeigen aller
        internal Ship() 
        {
            
        }
    }
}
