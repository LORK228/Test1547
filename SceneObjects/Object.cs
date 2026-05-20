using System.Drawing;

namespace SceneObjects
{
    public abstract class Object
    {
        public abstract void Draw(Graphics g, Pen pen);
    }
}