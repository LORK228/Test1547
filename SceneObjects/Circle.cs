using System.Drawing;

namespace SceneObjects
{
    public class Circle : Object
    {
        public int X { get; }
        public int Y { get; }
        public int Radius { get; }

        public Circle(int x, int y, int radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2);
        }
    }
}