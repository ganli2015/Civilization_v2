using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace GameEntity
{
    public delegate void DeadEvent(System.Drawing.Point p);

    public interface Alive
    {
        int Population
        {
            get;
            set;
        }

        Point GetLocationIndex();
        void SetLocationIndex(int x, int y);

        void Draw();//conditional
        void Paint();//non-conditional
        Alive Clone();
        void SetPictureBox(ref GameDisplay gameDisplay);
        Color GetColor();
        Element GetElementType();

        void Save(string filename);

        Element GetEnviron();
        void SetEnviron(Element environ);

        MessageSet Update();
    }
}
