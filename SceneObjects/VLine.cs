using System.Drawing;

namespace SceneObjects
{
    public class VLine : Object
    {
        public int Y1 { get; }
        public int Y2 { get; }
        public int X { get; }

        public VLine(int y1, int y2, int x)
        {
            Y1 = y1;
            Y2 = y2;
            X = x;
        }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawLine(pen, X, Y1, X, Y2);
        }
    }
}