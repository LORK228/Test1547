using System.Drawing;

namespace SceneObjects
{
    public class HLine : Object
    {
        public int X1 { get; }
        public int X2 { get; }
        public int Y { get; }

        public HLine(int x1, int x2, int y)
        {
            X1 = x1;
            X2 = x2;
            Y = y;
        }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawLine(pen, X1, Y, X2, Y);
        }
    }
}