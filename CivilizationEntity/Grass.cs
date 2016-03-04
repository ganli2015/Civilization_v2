using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using GameEntity;

namespace CivilizationEntity
{
    public class Grass:Environ
    {
        int _x, _y;
        Color _myColor;
        GameDisplay _gameDisplay;


        public double GrowthRate
        {
            get;
            set;
        }

        public int Fruit
        {
            get;
            set;
        }

        public Grass()
        {
            InitializeAttribute();
        }

        public Grass(Point p)
        {
            _x = p.X;
            _y = p.Y;
            InitializeAttribute();
        }

        public Grass(int i, int j)
        {
            _x = i;
            _y = j;
            InitializeAttribute();
        }

        void InitializeAttribute()
        {
            _myColor = GlobalParameter.GrassColor;

            Fruit=GameParameter.Grass_Init_Food;
            GrowthRate = GameParameter.Grass_Init_GrowthRate;
        }

        public Point GetLocationIndex()
        {
            return new Point(_x, _y);
        }

        public void SetLocationIndex(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void SetPictureBox(ref GameDisplay gameDisplay)
        {
            _gameDisplay = gameDisplay;
        }


        public void Draw()
        {
            Color myColor =GlobalParameter.GrassColor;


            if (_myColor != myColor)
            {
                _gameDisplay.DrawSquare(myColor, _x, _y, GlobalParameter.GridLength);
                _myColor = myColor;
            }
        }

        public void Paint()
        {
            _gameDisplay.DrawSquare(_myColor, _x, _y, GlobalParameter.GridLength);
        }

        public Environ Clone()
        {
            Grass environ = new Grass();
            environ._x = _x;
            environ._y = _y;
            environ._gameDisplay = _gameDisplay;
            environ.Fruit = Fruit;

            return environ;
        }

        public void Save(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Append);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(Convert.ToInt32(Element.Grass));
            bw.Write(_x);
            bw.Write(_y);
            bw.Write(Fruit);
            bw.Write(GrowthRate);

            bw.Flush();
            bw.Close();
            fs.Close();
        }

        public Color GetColor()
        {
            return _myColor;
        }

        public Element GetElementType()
        {
            return Element.Grass;
        }
    }
}
