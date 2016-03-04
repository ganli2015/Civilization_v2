using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using GameEntity;
using CivilizationEntity.CivilizationProperty;

namespace CivilizationEntity
{
    public class Human:Alive
    {
        int _x, _y;
        protected Color _myColor;
        GameDisplay _gameDisplay;

        virtual public int Population
        {
            get;
            set;
        }

        private Element Environ
        {
            get;
            set;
        }

        public Human(bool init=true)
        {
            if(init)
                InitializeAttribute();
        }

        public Human(Point p, bool init = true)
        {
            _x = p.X;
            _y = p.Y;

            if (init)
                InitializeAttribute();
        }

        public Human(int i, int j, bool init = true)
        {
            _x = i;
            _y = j;

            if (init)
                InitializeAttribute();
        }

        void InitializeAttribute()
        {
            _myColor = GlobalParameter.HumanColor;

            Population = GameParameter.Human_Init_Population;

            Environ = Element.None;
        }

        virtual public Point GetLocationIndex()
        {
            return new Point(_x, _y);
        }

        virtual public void SetLocationIndex(int x, int y)
        {
            _x = x;
            _y = y;
        }

        virtual public Element GetEnviron()
        {
            return Environ;
        }

        virtual public void SetEnviron(Element environ)
        {
            Environ = environ;
        }

        virtual public void Draw()
        {
            Color myColor=GenerateColor(Population);
            

            if (_myColor != myColor)
            {
                _gameDisplay.DrawCircle(myColor, _x, _y, GlobalParameter.GridLength);
                _myColor = myColor;
            }
            
        }

        virtual public void Paint()
        {
            _gameDisplay.DrawCircle(_myColor, _x, _y, GlobalParameter.GridLength);
        }

        virtual public void SetPictureBox(ref GameDisplay gameDisplay)
        {
            _gameDisplay = gameDisplay;
        }

        virtual public Alive Clone()
        {
            Human clone = new Human();
            clone._x = _x;
            clone._y = _y;
            clone.Population = Population;
            clone._gameDisplay = _gameDisplay;
            clone._myColor = _myColor;
           

            return clone;
        }

        virtual public void Save(string filename)
        {
            FileStream fs = new FileStream(filename,FileMode.Append);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(Convert.ToInt32(Element.Human));
            bw.Write(_x);
            bw.Write(_y);
            bw.Write(Population);

            bw.Write(Convert.ToInt32(Environ));

            bw.Flush();
            bw.Close();
            fs.Close();
        }


        virtual public Color GetColor()
        {
            return _myColor;
        }

        virtual public Element GetElementType()
        {
            return Element.Human;
        }

        virtual public MessageSet Update()
        {
            Population--;

            return new MessageSet();
        }

        private Color GenerateColor(double population)
        {
//             ColorManager cm = ColorManager.GetInstance();
// 
//             Color myColor=cm.GetHumanColor(_civIndex);
            

            return _myColor;

        }



    }
}
