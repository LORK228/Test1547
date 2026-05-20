using System.Drawing;

namespace SceneObjects
{
    public class Triangle : Object
    {
        public int X1 { get; }
        public int Y1 { get; }
        public int X2 { get; }
        public int Y2 { get; }
        public int X3 { get; }
        public int Y3 { get; }

        public Triangle(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }

        public override void Draw(Graphics g, Pen pen)
        {
            System.Drawing.Point[] points = {
                new System.Drawing.Point(X1, Y1),
                new System.Drawing.Point(X2, Y2),
                new System.Drawing.Point(X3, Y3)
            };
            g.DrawPolygon(pen, points);
        }
    }
}