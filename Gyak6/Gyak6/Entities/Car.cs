using Gyak6.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyak6.Entities
{
    public class Car : Toy
    {
        protected override void DrawImage(Graphics g)
        {
            Image img = Image.FromFile("Images/car.png");
            g.DrawImage(img, 0, 0, Width, Height);
        }
    }
}
