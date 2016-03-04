using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEntity;

namespace CivilizationEntity
{
    public class QueryEntity
    {
        static private CIVElements CivElements { set; get; } 

        static public GameElements GameEntity 
        {
            set
            {
                CivElements = value as CIVElements;
            }          
        }

        static public Human GetHumanPlayerClone()
        {
            Human player = CivElements.GetPlayer() as Human;
            return player.Clone() as Human;
        }

        public static List<Alive> GetAllAliveButPlayer()
        {
            List<Alive> allAlive = CivElements.GetAllAlive();
            allAlive.Remove(CivElements.GetPlayer());
            return allAlive;
        }
    }
}
