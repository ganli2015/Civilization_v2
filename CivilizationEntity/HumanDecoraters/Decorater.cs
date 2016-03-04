using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEntity;
using Point = System.Drawing.Point;
using Color = System.Drawing.Color;

namespace CivilizationEntity.HumanDecoraters
{
    public abstract class HumanDecorater:Human
    {
        protected Human _human;
        /// <summary>
        /// The round that this state start from
        /// </summary>
        public long StartRound { get; protected set; }

        override public int Population
        {
            get
            {
                return _human.Population;
            }
            set
            {
                _human.Population = value;
            }
        }

        public HumanDecorater(Human human, long startRound)
            : base(false)
        {
            _human = human;
            StartRound = startRound;
        }

        override public Point GetLocationIndex()
        {
            return _human.GetLocationIndex();
        }

        override public void SetLocationIndex(int x, int y)
        {
            _human.SetLocationIndex(x, y);
        }

        override public Element GetEnviron()
        {
            return _human.GetEnviron();
        }

        override public void SetEnviron(Element environ)
        {
            _human.SetEnviron(environ);
        }

        override public void Draw()
        {
            _human.Draw();
        }

        override public void Paint()
        {
            _human.Paint();
        }

        override public void SetPictureBox(ref GameDisplay gameDisplay)
        {
            _human.SetPictureBox(ref gameDisplay);
        }

        override abstract public Alive Clone();
        

        override public void Save(string filename)
        {
            _human.Save(filename);
        }

        override public MessageSet Update()
        {
            return _human.Update();
        }

        override public Color GetColor()
        {
            return _human.GetColor();
        }

        override public Element GetElementType()
        {
            return _human.GetElementType();
        }
    }
}
