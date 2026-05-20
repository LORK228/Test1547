using System.Drawing;

namespace SceneObjects
{
    public class Point : Object
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override void Draw(Graphics g, Pen pen)
        {
            using (Brush brush = new SolidBrush(pen.Color))
            {
                g.FillRectangle(brush, X, Y, 1, 1);
            }
        }
    }
}