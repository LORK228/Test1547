using System.Drawing;

namespace SceneObjects
{
    public class Rect : Object
    {
        public int X1 { get; }
        public int Y1 { get; }
        public int X2 { get; }
        public int Y2 { get; }

        public Rect(int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public override void Draw(Graphics g, Pen pen)
        {
            int x = System.Math.Min(X1, X2);
            int y = System.Math.Min(Y1, Y2);
            int width = System.Math.Abs(X2 - X1);
            int height = System.Math.Abs(Y2 - Y1);
            g.DrawRectangle(pen, x, y, width, height);
        }
    }
}