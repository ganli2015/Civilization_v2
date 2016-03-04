using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEntity;
using Point = System.Drawing.Point;

namespace CivilizationEntity
{
    public class Player:Human
    {
        public Player(bool init=true):base(init)
        {
            _myColor = GlobalParameter.PlayerColor;
        }

        public Player(Point p, bool init = true):base(p,init)
        {
            _myColor = GlobalParameter.PlayerColor;       
        }

        public Player(int i, int j, bool init = true):base(i,j,init)
        {
            _myColor = GlobalParameter.PlayerColor;            
        }
    }
}
